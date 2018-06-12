using System;
using System.Collections.Generic;

namespace SPBitsy
{

    public class Font
    {

        public const int FONT_WIDTH = 6;
        public const int FONT_HEIGHT = 8;

        #region Fields

        private List<BitsyGame.GfxTileSheet> _chars = new List<BitsyGame.GfxTileSheet>();

        #endregion

        #region CONSTRUCTOR

        public Font()
        {
            this.Rebuild();
        }

        #endregion

        #region Methods

        private BitsyGame.GfxTileSheet _debug;
        public BitsyGame.GfxTileSheet GetCharGfx(char c)
        {
            return _chars[0];
        }

        public void Rebuild()
        {
            _chars.Clear();

            /* num: 0 */
            _chars.Add(BitsyGame.GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 1 */
            _chars.Add(BitsyGame.GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 0, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 2 */
            _chars.Add(BitsyGame.GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 3 */
            _chars.Add(BitsyGame.GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 4 */
            _chars.Add(BitsyGame.GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 5 */
            _chars.Add(BitsyGame.GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 6 */
            _chars.Add(BitsyGame.GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 7 */
            _chars.Add(BitsyGame.GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 8 */
            _chars.Add(BitsyGame.GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 0, 0, 1, 1,
        1, 1, 0, 0, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1));
            /* num: 9 */
            _chars.Add(BitsyGame.GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0));
        }

        #endregion

    }

}
