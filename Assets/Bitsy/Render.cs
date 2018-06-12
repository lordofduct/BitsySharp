using System;
using System.Collections.Generic;

namespace SPBitsy
{

    public class SceneRenderer
    {

        #region Fields

        private Environment _env;

        #endregion

        #region CONSTRUCTOR

        public SceneRenderer(Environment environment)
        {
            if (environment == null) throw new System.ArgumentNullException("environment");
            _env = environment;
        }

        #endregion

        #region Methods

        public void DrawRoom(BitsyGame.Room room, IRenderSurface context)
        {
            context.FillSurface(_env.GetCurrentPalette().Colors[0]);

            for(int i = 0; i < room.Tilemap.GetLength(0); i++)
            {
                for(int j = 0; j < room.Tilemap.GetLength(1); j++)
                {
                    string id = room.Tilemap[i, j];
                    if(id != BitsyGame.ID_DEFAULT)
                    {
                        BitsyGame.Tile tile;
                        if(_env.Tiles.TryGetValue(id, out tile))
                        {
                            this.DrawTile(tile, i, j, context);
                        }
                        else
                        {
                            id = BitsyGame.ID_DEFAULT;
                            room.Tilemap[i, j] = id;
                        }
                    }
                }
            }

            for(int i = 0; i < room.Items.Count; i++)
            {
                BitsyGame.Item item;
                if(_env.Items.TryGetValue(room.Items[i].Id, out item))
                {
                    this.DrawItem(item, room.Items[i].x, room.Items[i].y, context);
                }
            }

            foreach(var spr in _env.Sprites.Values)
            {
                if(spr.RoomId == room.Id)
                {
                    this.DrawSprite(spr, spr.x, spr.y, context);
                }
            }
        }

        public void DrawTile(BitsyGame.Tile tile, int x, int y, IRenderSurface context)
        {

        }

        public void DrawItem(BitsyGame.Item item, int x, int y, IRenderSurface context)
        {

        }

        public void DrawSprite(BitsyGame.Sprite spr, int x, int y, IRenderSurface context)
        {

        }

        #endregion

    }

    public class DialogRenderer
    {

        #region Fields

        private Environment _env;

        private object _img = null;
        private int _width = 104;
        private int _height = 8 + 4 + 2 + 5; //8 for text, 4 for top-bottom padding, 2 for line padding, 5 for arrow
        private int _top = 12;
        private int _left = 12;
        private int _bottom = 12;

        private object _context;

        private bool _isCentered = false;

        #endregion

        #region CONSTRUCTOR

        public DialogRenderer(Environment environment)
        {
            if (environment == null) throw new System.ArgumentNullException("environment");
            _env = environment;
        }

        #endregion

        #region Methods

        public void AttachContext(object c)
        {
            _context = c;
        }

        public void ClearTextbox()
        {
            if (_context == null) return;

            //TODO - clear draw area
        }

        public void SetCentered(bool centered)
        {
            _isCentered = centered;
        }

        public void DrawTextbox(BitsyGame game)
        {
            if (_context == null) return;
            if (_isCentered)
            {
                //center
                //TODO - draw
            }
            else if (game.Environment.GetPlayer().y < BitsyGame.MAPSIZE / 2)
            {
                //bottom
                //TODO - draw
            }
            else
            {
                //top
                //TODO - draw
            }
        }

        public void Reset()
        {

        }

        public void Draw(DialogBuffer buffer, int deltaTime)
        {

        }

        #endregion

    }

    public class DialogBuffer
    {

        #region Fields

        #endregion

        #region Properties

        public bool IsActive
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public void Update(int deltaTime)
        {

        }

        public void Reset()
        {
            //TODO
        }

        public void AddText(string text, System.Action onFinish)
        {
            if (onFinish != null) onFinish();
            //TODO
        }

        public void AddLinebreak()
        {

        }

        public bool HasTextEffect(string name)
        {
            return false;
        }

        public void RemoveTextEffect(string name)
        {

        }

        public void AddTextEffect(string name)
        {

        }

        public void ToggleTextEffect(string name)
        {
            if (this.HasTextEffect(name))
                this.RemoveTextEffect(name);
            else
                this.AddTextEffect(name);
        }

        #endregion

    }

}
