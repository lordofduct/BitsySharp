using System;
using System.Collections.Generic;

namespace SPBitsy
{

    public class DialogRenderer
    {

        #region Fields

        private object _img = null;
        private int _width = 104;
        private int _height = 8 + 4 + 2 + 5; //8 for text, 4 for top-bottom padding, 2 for line padding, 5 for arrow
        private int _top = 12;
        private int _left = 12;
        private int _bottom = 12;

        private object _context = null;

        private bool _isCentered = false;

        #endregion

        #region CONSTRUCTOR

        public DialogRenderer()
        {

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

        #endregion

    }

    public class DialogBuffer
    {

        #region Fields

        #endregion

        #region Methods

        public void Reset()
        {
            //TODO
        }

        public void AddText(string text, System.Action onFinish)
        {
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
