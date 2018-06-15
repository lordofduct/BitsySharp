using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SPBitsy
{
    
    public class BitsyGame
    {

        public string VERSION = "4.8"; //this is the bitsy version we're currently ported from

        public const int MAPSIZE = 16;
        public const int TILESIZE = 8;
        public const int RENDERSIZE = MAPSIZE * TILESIZE;
        public const int PIXEL_SCALE = 2;
        public const int TEXT_SCALE = 1;
        public const int RESOLUTION = RENDERSIZE * PIXEL_SCALE;

        public const int FONT_WIDTH = 6;
        public const int FONT_HEIGHT = 8;

        public const int ANIM_TIME_MS = 400;
        public const int MOVE_TIME_MS = 200;

        public const string ID_PLAYER = "A";
        public const string ID_DEFAULT = "0";

        #region Fields
        
        private Environment _environment;
        private IRenderSurface _surface;
        
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

        public void Begin(Environment environment, IRenderSurface renderSurface)
        {
            _environment = environment;
            _surface = renderSurface;

            _environment.VariableChanged += this.OnVariableChanged;

            _environment.CurrentRoomId = _environment.GetPlayer().RoomId ?? ID_DEFAULT;

            this.StartNarrating(_environment.Title);
        }

        /// <summary>
        /// Tick the game.
        /// </summary>
        /// <param name="deltaTime">Number of milliseconds since last update.</param>
        public void Tick(int deltaTime)
        {
            try
            {
                _environment.Inputs.Update();

                if (!_environment.isNarrating && !_environment.isEnding)
                {
                    this.UpdateAnimation(deltaTime);
                    _environment.SceneRenderer.DrawRoom(_environment.GetCurrentRoom(), _surface);
                }
                else
                {
                    _surface.FillSurface(_environment.GetCurrentPalette().Colors[0]);
                }

                if (_environment.DialogBuffer.IsActive)
                {
                    _environment.DialogRenderer.Draw(_environment.DialogBuffer, deltaTime, _surface);
                    _environment.DialogBuffer.Update(deltaTime);
                }
                else if (!_environment.isEnding)
                {
                    this.MoveSprites(deltaTime);

                    if (_environment.GetPlayer().WalkingPath.Count > 0)
                    {
                        var dest = _environment.GetPlayer().WalkingPath.Last();
                        _surface.FillArea(Color.HalfWhite, dest.x * PIXEL_SCALE, dest.y * PIXEL_SCALE, TILESIZE * PIXEL_SCALE, TILESIZE * PIXEL_SCALE);
                    }
                }

                if (!_environment.DialogBuffer.IsActive && !_environment.isEnding)
                {
                    //handle inputs
                    var dir = this.GetInputDirection();
                    var last = _environment.lastMoveDirection;
                    _environment.lastMoveDirection = dir;

                    if (dir != Direction.None)
                    {
                        if (last != dir)
                        {
                            this.MovePlayer(dir);
                            _environment.moveHoldCounter = 500;
                        }
                        else
                        {
                            _environment.moveHoldCounter -= deltaTime;
                            if (_environment.moveHoldCounter <= 0)
                            {
                                _environment.moveHoldCounter = 150;
                                this.MovePlayer(dir);
                            }
                        }
                    }
                }
                else
                {
                    this.HandleGeneralInput();
                }

                if (_environment.didPlayerMoveThisFrame && _environment.onPlayerMoved != null) _environment.onPlayerMoved();
                _environment.didPlayerMoveThisFrame = false;
            }
            catch(System.Exception ex)
            {
                _environment.Inputs.Reset();
                _environment.DialogBuffer.Reset();
                _environment.isNarrating = false;
                _environment.didPlayerMoveThisFrame = false;
                throw new InvalidOperationException("Bitsy hit a bug...", ex);
            }
        }

        #endregion

        #region Private Methods

        private void HandleGeneralInput()
        {
            if (_environment.DialogBuffer.IsActive)
            {
                if (_environment.Inputs.GetInputState(BitsyInput.InputId.Any) == BitsyInput.InputState.Down)
                {
                    if (_environment.DialogBuffer.CanContinue)
                    {
                        bool hasMoreDialog = _environment.DialogBuffer.Continue();
                        if (!hasMoreDialog)
                            this.ExitDialog();
                    }
                    else
                    {
                        _environment.DialogBuffer.Skip();
                    }
                }
            }
            else if (_environment.isEnding)
            {
                if (_environment.Inputs.GetInputState(BitsyInput.InputId.Any) == BitsyInput.InputState.Down)
                {
                    //TODO - register if any input down and signal quit
                }
            }
        }

        private Direction GetInputDirection()
        {
            if (_environment.Inputs.GetInputState(BitsyInput.InputId.Up) > BitsyInput.InputState.None)
                return Direction.Up;
            else if (_environment.Inputs.GetInputState(BitsyInput.InputId.Down) > BitsyInput.InputState.None)
                return Direction.Down;
            else if (_environment.Inputs.GetInputState(BitsyInput.InputId.Right) > BitsyInput.InputState.None)
                return Direction.Right;
            else if (_environment.Inputs.GetInputState(BitsyInput.InputId.Left) > BitsyInput.InputState.None)
                return Direction.Left;

            return Direction.None;
        }

        private void UpdateAnimation(int deltaTime)
        {
            _environment.AnimCounter += deltaTime;

            if (_environment.AnimCounter > ANIM_TIME_MS)
            {
                int frameCount = _environment.AnimCounter / ANIM_TIME_MS;

                foreach (var spr in _environment.Sprites.Values)
                {
                    spr.Anim.Tick(frameCount);
                }
                foreach (var tile in _environment.Tiles.Values)
                {
                    tile.Anim.Tick(frameCount);
                }
                foreach (var item in _environment.Items.Values)
                {
                    item.Anim.Tick(frameCount);
                }

                _environment.AnimCounter %= ANIM_TIME_MS;
            }
        }

        private void MoveSprites(int deltaTime)
        {
            _environment.MoveCounter += deltaTime;

            if (_environment.MoveCounter >= MOVE_TIME_MS)
            {
                int frameCount = _environment.MoveCounter / MOVE_TIME_MS;

                foreach (var spr in _environment.Sprites.Values)
                {
                    if (spr.WalkingPath.Count > 0)
                    {
                        var nextPos = spr.WalkingPath.Dequeue();
                        spr.x = nextPos.x;
                        spr.y = nextPos.y;

                        Loc loc;
                        Exit exit;
                        int index;
                        if (spr.Id == ID_PLAYER && _environment.GetEndingAtLoc(spr.RoomId, spr.x, spr.y, out loc))
                        {
                            this.StartNarrating(_environment.Endings[loc.Id], true);
                        }
                        else if (_environment.GetExitAtLoc(spr.RoomId, spr.x, spr.y, out exit))
                        {
                            spr.RoomId = exit.Destination.Id;
                            spr.x = exit.Destination.x;
                            spr.y = exit.Destination.y;
                            if (spr.Id == ID_PLAYER)
                            {
                                _environment.CurrentRoomId = exit.Destination.Id;
                            }
                        }
                        else if ((index = _environment.GetItemIndexAtLoc(spr.RoomId, spr.x, spr.y)) >= 0)
                        {
                            var item = _environment.Rooms[spr.RoomId].Items[index];
                            _environment.Rooms[spr.RoomId].Items.RemoveAt(index);

                            if (spr.Inventory.ContainsKey(item.Id))
                                spr.Inventory[item.Id] += 1f;
                            else
                                spr.Inventory[item.Id] = 1f;

                            if (_environment.onInventoryChanged != null)
                                _environment.onInventoryChanged(item.Id);

                            if (spr.Id == ID_PLAYER)
                                this.StartItemDialog(item.Id);

                            // stop moving : is this a good idea?
                            spr.WalkingPath.Clear();
                        }

                        if (spr.Id == ID_PLAYER) _environment.didPlayerMoveThisFrame = true;
                    }
                }

                _environment.MoveCounter %= MOVE_TIME_MS;
            }
        }

        private void MovePlayer(Direction dir)
        {
            var player = _environment.GetPlayer();
            var room = _environment.GetCurrentRoom();
            Sprite spr = null;

            switch(dir)
            {
                case Direction.Up:
                    if(!this.IsLocWall(room, player.x, player.y - 1) && !_environment.GetSpriteAtLoc(room.Id, player.x, player.y - 1, out spr))
                    {
                        player.y -= 1;
                        _environment.didPlayerMoveThisFrame = true;
                    }
                    break;
                case Direction.Down:
                    if (!this.IsLocWall(room, player.x, player.y + 1) && !_environment.GetSpriteAtLoc(room.Id, player.x, player.y + 1, out spr))
                    {
                        player.y += 1;
                        _environment.didPlayerMoveThisFrame = true;
                    }
                    break;
                case Direction.Left:
                    if (!this.IsLocWall(room, player.x - 1, player.y) && !_environment.GetSpriteAtLoc(room.Id, player.x - 1, player.y, out spr))
                    {
                        player.x -= 1;
                        _environment.didPlayerMoveThisFrame = true;
                    }
                    break;
                case Direction.Right:
                    if (!this.IsLocWall(room, player.x + 1, player.y) && !_environment.GetSpriteAtLoc(room.Id, player.x + 1, player.y, out spr))
                    {
                        player.x += 1;
                        _environment.didPlayerMoveThisFrame = true;
                    }
                    break;
            }

            // do items first, because you can pick up an item AND go through a door
            int itemIndex = _environment.GetItemIndexAtLoc(room.Id, player.x, player.y);
            if(itemIndex >= 0)
            {
                var itm = room.Items[itemIndex];
                room.Items.RemoveAt(itemIndex);

                if (player.Inventory.ContainsKey(itm.Id))
                    player.Inventory[itm.Id] += 1f;
                else
                    player.Inventory[itm.Id] = 1f;

                if (_environment.onInventoryChanged != null)
                    _environment.onInventoryChanged(itm.Id);

                this.StartItemDialog(itm.Id);
            }

            Loc loc;
            Exit exit;

            if(_environment.GetEndingAtLoc(room.Id, player.x, player.y, out loc))
            {
                this.StartNarrating(_environment.Endings[loc.Id], true);
            }
            else if (_environment.GetExitAtLoc(room.Id, player.x, player.y, out exit))
            {
                player.RoomId = exit.Destination.Id;
                player.x = exit.Destination.x;
                player.y = exit.Destination.y;
                _environment.CurrentRoomId = exit.Destination.Id;
            }
            else if(spr != null)
            {
                this.StartSpriteDialog(spr.Id);
            }
        }

        private void StartNarrating(string dialog, bool isEnding = false)
        {
            _environment.isNarrating = true;
            _environment.isEnding = isEnding;
            this.StartDialog(dialog);
        }

        private void StartItemDialog(string itemId)
        {
            Item item;
            if(_environment.Items.TryGetValue(itemId, out item) && item != null && item.DialogId != null)
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
            _environment.DialogRenderer.IsCentered = _environment.isNarrating;
            _environment.DialogBuffer.Reset();

            if(scriptId == null)
            {
                _environment.ScriptInterpreter.Interpret(_environment, dialog, () =>
                {
                    if (!_environment.DialogBuffer.IsActive)
                        this.ExitDialog();
                });
            }
            else
            {
                if (!_environment.ScriptInterpreter.HasScript(scriptId))
                    _environment.ScriptInterpreter.Compile(_environment, scriptId, dialog);
                _environment.ScriptInterpreter.Run(_environment, scriptId, () =>
                {
                    if (!_environment.DialogBuffer.IsActive)
                        this.ExitDialog();
                });
            }
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
        


        private bool IsLocWall(Room room, int x, int y)
        {
            if (room == null) return false;
            if (x < 0 || x >= MAPSIZE) return false;
            if (y < 0 || y >= MAPSIZE) return false;

            var tileId = room.Tilemap[x, y];
            if (tileId == ID_DEFAULT) return false;

            Tile tile;
            if(_environment.Tiles.TryGetValue(tileId, out tile))
            {
                if(tile.IsWall == null)
                    return room.Walls != null && Array.IndexOf(room.Walls, tileId) >= 0;
                else
                    return tile.IsWall.Value;
            }

            return false;
        }
        
        #endregion

        #region Events

        private void OnVariableChanged(Environment env, string name)
        {

        }

        #endregion
        
        #region Special Types

        public enum Direction
        {
            None = -1,
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 3
        }

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
            public string Id;
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
            public List<Loc> Items;
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

        public class Anim
        {
            public bool IsAnimated;
            public int FrameIndex;
            public int FrameCount;

            public void Tick(int cnt)
            {
                if(this.IsAnimated)
                {
                    this.FrameIndex = (this.FrameIndex + cnt) % this.FrameCount;
                }
            }
        }
        
        public struct Color
        {
            public byte r;
            public byte g;
            public byte b;
            public byte a;

            public Color(byte r, byte g, byte b)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = 255;
            }

            public Color(byte r, byte g, byte b, byte a)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
            }

            public readonly static Color White = new Color(255, 255, 255, 255);
            public readonly static Color HalfWhite = new Color(255, 255, 255, 127);
            public readonly static Color Black = new Color(0, 0, 0, 255);

        }

        #endregion

    }

    public class Environment
    {

        public event System.Action<Environment, string> VariableChanged;

        #region Fields

        public readonly Random Rng;
        public IFont Font;

        public bool UseHandler = true;
        private Dictionary<string, object> _variables = new Dictionary<string, object>();

        public string Title;

        public readonly BitsyGame.NameTable Names = new BitsyGame.NameTable();
        public readonly Dictionary<string, BitsyGame.Palette> Palettes = new Dictionary<string, BitsyGame.Palette>();
        public readonly Dictionary<string, BitsyGame.Room> Rooms = new Dictionary<string, BitsyGame.Room>();
        public readonly Dictionary<string, BitsyGame.Tile> Tiles = new Dictionary<string, BitsyGame.Tile>();
        public readonly Dictionary<string, BitsyGame.Sprite> Sprites = new Dictionary<string, BitsyGame.Sprite>();
        public readonly Dictionary<string, BitsyGame.Item> Items = new Dictionary<string, BitsyGame.Item>();
        public readonly Dictionary<string, string> Dialog = new Dictionary<string, string>();
        public readonly Dictionary<string, string> Endings = new Dictionary<string, string>();
        public readonly Dictionary<string, GfxTileSheet> ImageStore = new Dictionary<string, GfxTileSheet>();

        public readonly ScriptInterpreter ScriptInterpreter;
        public readonly SceneRenderer SceneRenderer;
        public readonly DialogRenderer DialogRenderer;
        public readonly DialogBuffer DialogBuffer;

        public readonly BitsyInput Inputs = new BitsyInput();
        
        
        public bool isNarrating;
        public bool isEnding;
        public bool isDialogMode;
        public bool isDialogPreview;
        public System.Action onDialogPreviewEnd;

        public string CurrentRoomId = BitsyGame.ID_DEFAULT;

        public int AnimCounter = 0;
        public int MoveCounter = 0;

        public bool didPlayerMoveThisFrame = false;

        public BitsyGame.Direction lastMoveDirection = BitsyGame.Direction.None;
        public int moveHoldCounter = 0;

        public System.Action<string> onInventoryChanged;
        public System.Action onPlayerMoved;

        #endregion

        #region CONSTRUCTOR

        public Environment()
        {
            this.Rng = new Random();
            this.ScriptInterpreter = new ScriptInterpreter(this);
            this.SceneRenderer = new SceneRenderer(this);
            this.DialogRenderer = new DialogRenderer(this);
            this.DialogBuffer = new DialogBuffer();
            this.Palettes[BitsyGame.ID_DEFAULT] = new BitsyGame.Palette()
            {
                Id = BitsyGame.ID_DEFAULT,
                Name = BitsyGame.ID_DEFAULT,
                Colors = new BitsyGame.Color[]
                {
                    new BitsyGame.Color(0,0,0),
                    new BitsyGame.Color(255,0,0),
                    new BitsyGame.Color(255,255,255),
                }
            };
        }

        public Environment(Random rng)
        {
            this.Rng = rng;
            this.ScriptInterpreter = new ScriptInterpreter(this);
            this.SceneRenderer = new SceneRenderer(this);
            this.DialogRenderer = new DialogRenderer(this);
            this.DialogBuffer = new DialogBuffer();
            this.Palettes[BitsyGame.ID_DEFAULT] = new BitsyGame.Palette()
            {
                Id = BitsyGame.ID_DEFAULT,
                Name = BitsyGame.ID_DEFAULT,
                Colors = new BitsyGame.Color[]
                {
                    new BitsyGame.Color(0,0,0),
                    new BitsyGame.Color(255,0,0),
                    new BitsyGame.Color(255,255,255),
                }
            };
        }

        #endregion

        #region Methods

        public BitsyGame.Sprite GetPlayer()
        {
            return this.Sprites[BitsyGame.ID_PLAYER];
        }

        public BitsyGame.Palette GetPalette(string id)
        {
            BitsyGame.Palette pal;
            if (this.Palettes.TryGetValue(id, out pal))
                return pal;
            else if (this.Palettes.TryGetValue(BitsyGame.ID_DEFAULT, out pal))
                return pal;
            else
                return this.Palettes.Values.FirstOrDefault();
        }

        public BitsyGame.Palette GetCurrentPalette()
        {
            return this.GetRoomPalette(this.CurrentRoomId);
        }

        public BitsyGame.Palette GetRoomPalette(string roomId)
        {
            BitsyGame.Room room;
            BitsyGame.Palette pal;
            if (this.Rooms.TryGetValue(roomId, out room))
            {
                if (room.Palette != null && this.Palettes.TryGetValue(room.Palette, out pal))
                    return pal;
            }

            if (this.Palettes.TryGetValue(roomId, out pal))
                return pal; //there is a palette matching the name of the room
            else if (this.Palettes.TryGetValue(BitsyGame.ID_DEFAULT, out pal))
                return pal; //return default palette
            else
                return this.Palettes.Values.FirstOrDefault(); //return something
        }

        public BitsyGame.Room GetCurrentRoom()
        {
            BitsyGame.Room room;
            if (this.Rooms.TryGetValue(this.CurrentRoomId, out room))
                return room;
            else if (this.Rooms.TryGetValue(BitsyGame.ID_DEFAULT, out room))
                return room;
            else
                return this.Rooms.Values.FirstOrDefault();
        }

        public bool GetEndingAtLoc(string roomId, int x, int y, out BitsyGame.Loc loc)
        {
            BitsyGame.Room room;
            if (this.Rooms.TryGetValue(roomId, out room))
            {
                foreach (var e in room.Endings)
                {
                    if (x == e.x && y == e.y)
                    {
                        loc = e;
                        return true;
                    }
                }
            }

            loc = default(BitsyGame.Loc);
            return false;
        }

        public bool GetExitAtLoc(string roomId, int x, int y, out BitsyGame.Exit exit)
        {
            BitsyGame.Room room;
            if(this.Rooms.TryGetValue(roomId, out room))
            {
                foreach(var ex in room.Exits)
                {
                    if(x == ex.x && y == ex.y)
                    {
                        exit = ex;
                        return true;
                    }
                }
            }

            exit = null;
            return false;
        }

        public bool GetItemAtLoc(string roomId, int x, int y, BitsyGame.Loc loc)
        {
            BitsyGame.Room room;
            if (this.Rooms.TryGetValue(roomId, out room))
            {
                for (int i = 0; i < room.Items.Count; i++)
                {
                    if (room.Items[i].x == x && room.Items[i].y == y)
                    {
                        loc = room.Items[i];
                        return true;
                    }
                }
            }

            loc = default(BitsyGame.Loc);
            return false;
        }

        public int GetItemIndexAtLoc(string roomId, int x, int y)
        {
            if (roomId == null) return -1;
            BitsyGame.Room room;
            if (this.Rooms.TryGetValue(roomId, out room))
            {
                for(int i = 0; i < room.Items.Count; i++)
                {
                    if(room.Items[i].x == x && room.Items[i].y == y)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public bool GetSpriteAtLoc(string roomId, int x, int y, out BitsyGame.Sprite spr)
        {
            foreach(var s in this.Sprites.Values)
            {
                if(s.x == x && s.y == y && s.RoomId == roomId)
                {
                    spr = s;
                    return true;
                }
            }

            spr = null;
            return false;
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
        
        public void ClearVariables()
        {
            _variables.Clear();
        }

        #endregion

        #region Scripts

        #endregion

        #region Special Types

        #endregion

    }

    public class BitsyInput
    {

        #region Fields

        /// store InputId as int because the 'DefaultComparer' boxes enums when looking up by enum key.
        private Dictionary<int, InputState> _states = new Dictionary<int, InputState>();
        public PollInputActiveCallback GetInputActive;

        #endregion

        #region CONSTRUCTOR

        public BitsyInput()
        {
            this.Reset();
        }

        #endregion

        #region Methods

        public void Update()
        {
            if (this.GetInputActive != null)
            {
                _states[(int)InputId.Any] = GetNextState(_states[(int)InputId.Any], this.GetInputActive(InputId.Any));
                _states[(int)InputId.Up] = GetNextState(_states[(int)InputId.Up], this.GetInputActive(InputId.Up));
                _states[(int)InputId.Down] = GetNextState(_states[(int)InputId.Down], this.GetInputActive(InputId.Down));
                _states[(int)InputId.Right] = GetNextState(_states[(int)InputId.Right], this.GetInputActive(InputId.Right));
                _states[(int)InputId.Left] = GetNextState(_states[(int)InputId.Left], this.GetInputActive(InputId.Left));
                _states[(int)InputId.Action] = GetNextState(_states[(int)InputId.Action], this.GetInputActive(InputId.Action));
            }
            else
                this.Reset();
        }

        public void Reset()
        {
            _states[(int)InputId.Any] = InputState.None;
            _states[(int)InputId.Up] = InputState.None;
            _states[(int)InputId.Down] = InputState.None;
            _states[(int)InputId.Right] = InputState.None;
            _states[(int)InputId.Left] = InputState.None;
            _states[(int)InputId.Action] = InputState.None;
        }

        public InputState GetInputState(InputId id)
        {
            InputState st;
            if (_states.TryGetValue((int)id, out st))
                return st;
            else
                return InputState.None;
        }

        public static InputState GetNextState(InputState current, bool active)
        {
            if (active)
            {
                switch (current)
                {
                    case InputState.None:
                    case InputState.Released:
                        return InputState.Down;
                    case InputState.Down:
                    case InputState.Held:
                        return InputState.Held;
                }
            }
            else
            {
                switch (current)
                {
                    case InputState.None:
                    case InputState.Released:
                        return InputState.None;
                    case InputState.Down:
                    case InputState.Held:
                        return InputState.Released;
                }
            }

            return InputState.None;
        }

        #endregion

        #region Special Types

        public enum InputId
        {
            Any = -1,
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 3,
            Action = 4
        }

        public enum InputState : sbyte
        {
            None = 0,
            Down = 1,
            Held = 2,
            Released = -1
        }

        public delegate bool PollInputActiveCallback(InputId id);

        #endregion

    }

}
