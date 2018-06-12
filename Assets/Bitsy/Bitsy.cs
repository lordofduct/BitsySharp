using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SPBitsy
{
    
    public class BitsyGame
    {

        public const int MAPSIZE = 16;
        public const int TILESIZE = 8;

        public const string ID_PLAYER = "A";

        #region Fields

        private Environment _environment;
        private GetInputState _getInput;

        #endregion

        #region CONSTRUCTOR

        public BitsyGame()
        {

        }

        #endregion

        #region Properties

        public Environment Environment
        {
            get { return _environment; }
        }

        #endregion

        #region Methods

        public void Begin(Environment environment, GetInputState input)
        {
            _environment = environment;
            _getInput = input;

            _environment.VariableChanged += this.OnVariableChanged;
        }

        public void Tick()
        {

        }


        #endregion

        #region Private Methods

        private void StartNarrating(string dialog, bool isEnding = false)
        {
            _environment.isNarrating = true;
            _environment.isEnding = isEnding;
            this.StartDialog(dialog);
        }

        private void StartItemDialog(string itemId)
        {
            Item item;
            if(_environment.Items.TryGetValue(itemId, out item) && item != null)
            {
                string dialog;
                if (_environment.Dialog.TryGetValue(item.DialogId, out dialog))
                {
                    this.StartDialog(dialog, item.DialogId);
                }
            }
        }

        private void StartSpriteDialog(string spriteId)
        {
            Sprite sprite;
            if(_environment.Sprites.TryGetValue(spriteId, out sprite))
            {
                string dialogId = !string.IsNullOrEmpty(sprite.DialogId) ? sprite.DialogId : spriteId;
                string dialog;
                if(_environment.Dialog.TryGetValue(dialogId, out dialog))
                {
                    this.StartDialog(dialog, dialogId);
                }
            }
        }

        private void StartDialog(string dialog, string scriptId = null)
        {
            if(string.IsNullOrEmpty(dialog))
            {
                this.ExitDialog();
                return;
            }

            _environment.isDialogMode = true;
            _environment.DialogRenderer.Reset();
            _environment.DialogRenderer.SetCentered(_environment.isNarrating);
            _environment.DialogBuffer.Reset();
        }

        private void ExitDialog()
        {
            _environment.isDialogMode = false;
            _environment.isNarrating = false;
            if(_environment.isDialogPreview)
            {
                _environment.isDialogPreview = false;
                if (_environment.onDialogPreviewEnd != null)
                    _environment.onDialogPreviewEnd();
            }
        }

        #endregion

        #region Events

        private void OnVariableChanged(Environment env, string name)
        {

        }

        #endregion


        #region Special Types

        public enum InputId
        {
            Up,
            Down,
            Left,
            Right
        }

        public enum InputState : sbyte
        {
            None = 0,
            Down = 1,
            Held = 2,
            Released = -1
        }

        public delegate InputState GetInputState(InputId id);

        public class NameTable
        {
            public readonly Dictionary<string, string> rooms = new Dictionary<string, string>();
            public readonly Dictionary<string, string> tiles = new Dictionary<string, string>();
            public readonly Dictionary<string, string> sprites = new Dictionary<string, string>();
            public readonly Dictionary<string, string> items = new Dictionary<string, string>();

            public void Clear()
            {
                rooms.Clear();
                tiles.Clear();
                sprites.Clear();
                items.Clear();
            }
        }

        public class Palette
        {
            public string Name;
            public Color[] Colors;
        }

        public class Room
        {
            public string Id;
            public string Name;
            public string[,] Tilemap;
            public string[] Walls;
            public Exit[] Exits;
            public Loc[] Endings;
            public Loc[] Items;
            public string Palette;
        }

        public class Tile
        {
            public string Id;
            public string Name;
            public string DrawId;
            public int Color;
            public Anim Anim = new Anim();
            public bool? IsWall; //nullable so null can represent variance from room to room
        }

        public class Sprite
        {
            public string Id;
            public string Name;
            public string DrawId;
            public string DialogId;
            public int Color;
            public string RoomId;
            public int x;
            public int y;
            public Anim Anim = new Anim();
            public Queue<Loc> WalkingPath = new Queue<Loc>();
            public Dictionary<string, float> Inventory = new Dictionary<string, float>();
        }

        public class Item
        {
            public string Id;
            public string Name;
            public string DrawId;
            public string DialogId;
            public int Color;
            public Anim Anim = new Anim();
        }

        public struct Loc
        {
            public string Id; //can be used to id stuff, could be the room it's in, or the item it's for... this is arbitrary/contextual
            public int x;
            public int y;
        }

        public class Exit
        {
            public int x;
            public int y;
            public Loc Destination;
        }

        public class GfxTileSheet
        {
            public readonly int width;
            public readonly int height;
            public readonly int frameCount;
            private BitArray _pixels;

            public GfxTileSheet(int w, int h, int frameCount)
            {
                this.width = w;
                this.height = h;
                _pixels = new BitArray(w * h * frameCount);
            }

            public void SetPixels(IEnumerable<bool> pixels)
            {
                int i = 0;
                foreach(var p in pixels)
                {
                    if (i < _pixels.Length)
                        _pixels[i] = p;
                    else
                        break;
                    i++;
                }
            }

            public void SetPixels(params byte[] pixels)
            {
                int i = 0;
                foreach (var p in pixels)
                {
                    if (i < _pixels.Length)
                        _pixels[i] = (p != 0);
                    else
                        break;
                    i++;
                }
            }

            public static GfxTileSheet CreateStatic(int w, int h, params byte[] pixels)
            {
                var tile = new GfxTileSheet(w, h, 1);
                tile.SetPixels(pixels);
                return tile;
            }

        }

        public class Anim
        {
            public bool IsAnimated;
            public int FrameIndex;
            public int FrameCount;
        }

        public struct Color
        {
            public byte r;
            public byte g;
            public byte b;

            public Color(byte r, byte g, byte b)
            {
                this.r = r;
                this.g = g;
                this.b = b;
            }
        }

        #endregion

    }

    public class Environment
    {

        public event System.Action<Environment, string> VariableChanged;

        #region Fields

        public readonly ScriptInterpreter Interpreter;
        public readonly Random Rng;

        public bool UseHandler = true;
        private Dictionary<string, object> _variables = new Dictionary<string, object>();
        private Dictionary<string, string> _scripts = new Dictionary<string, string>();

        public string Title;

        public readonly BitsyGame.NameTable Names = new BitsyGame.NameTable();
        public readonly Dictionary<string, BitsyGame.Palette> Palettes = new Dictionary<string, BitsyGame.Palette>();
        public readonly Dictionary<string, BitsyGame.Room> Rooms = new Dictionary<string, BitsyGame.Room>();
        public readonly Dictionary<string, BitsyGame.Tile> Tiles = new Dictionary<string, BitsyGame.Tile>();
        public readonly Dictionary<string, BitsyGame.Sprite> Sprites = new Dictionary<string, BitsyGame.Sprite>();
        public readonly Dictionary<string, BitsyGame.Item> Items = new Dictionary<string, BitsyGame.Item>();
        public readonly Dictionary<string, string> Dialog = new Dictionary<string, string>();
        public readonly Dictionary<string, string> Endings = new Dictionary<string, string>();
        public readonly Dictionary<string, BitsyGame.GfxTileSheet> ImageStore = new Dictionary<string, BitsyGame.GfxTileSheet>();

        public readonly DialogRenderer DialogRenderer = new DialogRenderer();
        public readonly DialogBuffer DialogBuffer = new DialogBuffer();

        public bool isNarrating;
        public bool isEnding;
        public bool isDialogMode;
        public bool isDialogPreview;
        public System.Action onDialogPreviewEnd;

        #endregion

        #region CONSTRUCTOR

        public Environment()
        {
            this.Interpreter = new ScriptInterpreter(this);
            this.Rng = new Random();
        }

        public Environment(Random rng)
        {
            this.Interpreter = new ScriptInterpreter(this);
            this.Rng = rng;
        }

        #endregion

        #region Methods

        public BitsyGame.Sprite GetPlayer()
        {
            return this.Sprites[BitsyGame.ID_PLAYER];
        }

        #endregion

        #region Variables

        public IEnumerable<string> VariableNames
        {
            get { return _variables.Keys; }
        }

        public bool HasVariable(string key)
        {
            return _variables.ContainsKey(key);
        }

        public object GetVariable(string key)
        {
            object result;
            if (_variables.TryGetValue(key, out result))
                return result;
            else
                return null;
        }

        public void SetVariable(string key, object val)
        {
            _variables[key] = val;
            if (this.UseHandler && this.VariableChanged != null)
            {
                var d = this.VariableChanged;
                d(this, key);
            }
        }

        public void DeleteVariable(string key)
        {
            if (_variables.Remove(key) && this.UseHandler && this.VariableChanged != null)
            {
                var d = this.VariableChanged;
                d(this, key);
            }
        }

        public void Clear()
        {
            _variables.Clear();
            _scripts.Clear();
        }

        #endregion

    }

}
