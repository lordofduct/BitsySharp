using System;
using System.Collections.Generic;

namespace SPBitsy
{

    public interface IFont
    {

        GfxTileSheet GetCharGfx(char c);

    }
    
    public class BitsyFont : IFont
    {

        public const int FONT_WIDTH = BitsyGame.FONT_WIDTH;
        public const int FONT_HEIGHT = BitsyGame.FONT_HEIGHT;

        #region Fields

        private GfxTileSheet[] _table = new GfxTileSheet[256];

        #endregion

        #region CONSTRUCTOR

        public BitsyFont()
        {

        }

        #endregion

        #region Methods

        public void SetCharGfx(char c, GfxTileSheet tile)
        {
            int i = (int)c;
            if (i < 0 || i >= _table.Length) return;
            _table[i] = tile;
        }

        #endregion

        #region IFont Interface

        public GfxTileSheet GetCharGfx(char c)
        {
            int i = (int)c;
            if (i < 0 || i >= _table.Length) return _table[0];
            return _table[i];
        }

        #endregion

        #region Default Font

        public void RebuildDefault()
        {
            GfxTileSheet[] chars = _table;

            /* num: 0 */
            chars[0] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 1 */
            chars[1] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 0, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 2 */
            chars[2] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 3 */
            chars[3] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 4 */
            chars[4] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 5 */
            chars[5] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 6 */
            chars[6] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 7 */
            chars[7] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 8 */
            chars[8] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 0, 0, 1, 1,
        1, 1, 0, 0, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1);
            /* num: 9 */
            chars[9] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 10 */
            chars[10] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
            1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 0, 0, 0, 0, 1,
        1, 0, 1, 1, 0, 1,
        1, 0, 1, 1, 0, 1,
        1, 0, 0, 0, 0, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1);
            /* num: 11 */
            chars[11] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 1, 1,
        0, 0, 0, 0, 1, 1,
        0, 0, 1, 1, 0, 1,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 12 */
            chars[12] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 13 */
            chars[13] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 1, 0, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 1, 1, 0, 0,
        0, 1, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 14 */
            chars[14] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 1, 1,
        0, 0, 1, 1, 0, 1,
        0, 0, 1, 0, 1, 1,
        0, 0, 1, 1, 0, 1,
        0, 0, 1, 0, 1, 1,
        0, 1, 1, 0, 1, 1,
        0, 1, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 15 */
            chars[15] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 1, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 0, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 1, 0, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 16 */
            chars[16] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 17 */
            chars[17] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 18 */
            chars[18] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 19 */
            chars[19] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 20 */
            chars[20] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 0, 1, 1, 0, 1,
        0, 0, 0, 1, 0, 1,
        0, 0, 0, 1, 0, 1,
        0, 0, 0, 1, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 21 */
            chars[21] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 22 */
            chars[22] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 23 */
            chars[23] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0);
            /* num: 24 */
            chars[24] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 25 */
            chars[25] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 26 */
            chars[26] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 27 */
            chars[27] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 28 */
            chars[28] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 29 */
            chars[29] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 30 */
            chars[30] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 31 */
            chars[31] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 32 */
            chars[32] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 33 */
            chars[33] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 34 */
            chars[34] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 0, 1, 1,
        0, 1, 1, 0, 1, 1,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 35 */
            chars[35] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 36 */
            chars[36] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 1, 0,
        0, 1, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 37 */
            chars[37] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 0, 0, 1,
        0, 1, 1, 0, 0, 1,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 0, 0, 1, 1,
        0, 1, 0, 0, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 38 */
            chars[38] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 39 */
            chars[39] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 40 */
            chars[40] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 41 */
            chars[41] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 42 */
            chars[42] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 43 */
            chars[43] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 44 */
            chars[44] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 0, 0, 0);
            /* num: 45 */
            chars[45] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 46 */
            chars[46] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 47 */
            chars[47] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 48 ZERO!!!!*/
            chars[48] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 1, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 1, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 49 */
            chars[49] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 50 */
            chars[50] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 1, 1, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 51 */
            chars[51] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 52 */
            chars[52] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 53 */
            chars[53] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 54 */
            chars[54] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 1, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 55 */
            chars[55] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 56 */
            chars[56] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 57 */
            chars[57] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 58 */
            chars[58] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 59 */
            chars[59] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 0, 0, 0);
            /* num: 60 */
            chars[60] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 61 */
            chars[61] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 62 */
            chars[62] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 63 */
            chars[63] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 64 */
            chars[64] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 1, 1, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 1, 1, 1,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 65 Start of Capital Letters*/
            chars[65] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 66 */
            chars[66] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 67 */
            chars[67] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 68 */
            chars[68] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 69 */
            chars[69] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 70 */
            chars[70] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 71 */
            chars[71] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 72 */
            chars[72] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 73 */
            chars[73] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 74 */
            chars[74] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 75 */
            chars[75] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 1, 0, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 76 */
            chars[76] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 77 */
            chars[77] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 0, 1, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 78 */
            chars[78] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 0, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 0, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 79 */
            chars[79] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 80 */
            chars[80] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 81 */
            chars[81] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 82 */
            chars[82] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 83 */
            chars[83] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 84 */
            chars[84] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 85 */
            chars[85] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 86 */
            chars[86] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 87 */
            chars[87] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 88 */
            chars[88] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 89 */
            chars[89] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 90 */
            chars[90] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 91 */
            chars[91] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 92 */
            chars[92] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 93 */
            chars[93] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 94 */
            chars[94] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 95 */
            chars[95] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1);
            /* num: 96 */
            chars[96] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 97 */
            chars[97] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 98 */
            chars[98] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 99 */
            chars[99] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 100 */
            chars[100] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 101 */
            chars[101] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 102 */
            chars[102] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 1, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 103 */
            chars[103] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0);
            /* num: 104 */
            chars[104] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 105 */
            chars[105] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 106 */
            chars[106] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0);
            /* num: 107 */
            chars[107] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 1, 0, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 108 */
            chars[108] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 109 */
            chars[109] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 0, 1, 0,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 110 */
            chars[110] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 111 */
            chars[111] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 112 */
            chars[112] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0);
            /* num: 113 */
            chars[113] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 1);
            /* num: 114 */
            chars[114] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 1, 1, 0,
        0, 0, 1, 0, 0, 1,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 115 */
            chars[115] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 116 */
            chars[116] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 117 */
            chars[117] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 1, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 118 */
            chars[118] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 119 */
            chars[119] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 120 */
            chars[120] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 121 */
            chars[121] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 1, 1, 0, 0, 0);
            /* num: 122 */
            chars[122] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 123 */
            chars[123] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 1, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 124 */
            chars[124] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0);
            /* num: 125 */
            chars[125] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 1,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 126 */
            chars[126] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 1, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 127 */
            chars[127] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 0, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 128 */
            chars[128] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 0, 0);
            /* num: 129 */
            chars[129] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 1, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 130 */
            chars[130] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 131 */
            chars[131] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 132 */
            chars[132] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 133 */
            chars[133] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 134 */
            chars[134] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 135 */
            chars[135] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 0, 0);
            /* num: 136 */
            chars[136] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 137 */
            chars[137] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 138 */
            chars[138] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 139 */
            chars[139] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 140 */
            chars[140] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 141 */
            chars[141] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 142 */
            chars[142] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 143 */
            chars[143] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 0, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 144 */
            chars[144] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 145 */
            chars[145] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 146 */
            chars[146] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 147 */
            chars[147] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 148 */
            chars[148] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 149 */
            chars[149] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 150 */
            chars[150] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 1, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 151 */
            chars[151] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 1, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 152 */
            chars[152] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 1, 1, 0, 0, 0);
            /* num: 153 */
            chars[153] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 154 */
            chars[154] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 155 */
            chars[155] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 156 */
            chars[156] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 1, 0,
        0, 0, 1, 0, 0, 1,
        0, 0, 1, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 1, 0, 0, 1,
        0, 1, 0, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 157 */
            chars[157] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 158 */
            chars[158] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 0, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 1, 0, 1, 0,
        0, 1, 0, 1, 1, 1,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 159 */
            chars[159] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 0, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0);
            /* num: 160 */
            chars[160] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 161 */
            chars[161] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 162 */
            chars[162] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 163 */
            chars[163] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 1, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 164 */
            chars[164] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 1, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 165 */
            chars[165] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 1, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 0, 1, 0,
        0, 1, 0, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 166 */
            chars[166] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 167 */
            chars[167] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 168 */
            chars[168] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 169 */
            chars[169] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 170 */
            chars[170] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 171 */
            chars[171] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 172 */
            chars[172] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 1, 0, 0,
        0, 0, 1, 0, 1, 1,
        0, 1, 0, 1, 0, 1,
        0, 0, 0, 1, 1, 1,
        0, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 173 */
            chars[173] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 174 */
            chars[174] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 0, 1,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 0, 0, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 175 */
            chars[175] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 0, 0, 1,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 176 */
            chars[176] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 1,
        0, 0, 0, 0, 0, 0,
        1, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 1, 0, 1,
        0, 0, 0, 0, 0, 0,
        1, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 177 */
            chars[177] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 1,
        1, 0, 1, 0, 1, 0,
        0, 1, 0, 1, 0, 1,
        1, 0, 1, 0, 1, 0,
        0, 1, 0, 1, 0, 1,
        1, 0, 1, 0, 1, 0,
        0, 1, 0, 1, 0, 1,
        1, 0, 1, 0, 1, 0);
            /* num: 178 */
            chars[178] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 0, 1, 0, 1, 0,
        1, 1, 1, 1, 1, 1,
        0, 1, 0, 1, 0, 1,
        1, 1, 1, 1, 1, 1,
        1, 0, 1, 0, 1, 0,
        1, 1, 1, 1, 1, 1,
        0, 1, 0, 1, 0, 1,
        1, 1, 1, 1, 1, 1);
            /* num: 179 */
            chars[179] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0);
            /* num: 180 */
            chars[180] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0);
            /* num: 181 */
            chars[181] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0);
            /* num: 182 */
            chars[182] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        1, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0);
            /* num: 183 */
            chars[183] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0);
            /* num: 184 */
            chars[184] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0);
            /* num: 185 */
            chars[185] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        1, 1, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        1, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0);
            /* num: 186 */
            chars[186] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0);
            /* num: 187 */
            chars[187] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        1, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0);
            /* num: 188 */
            chars[188] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        1, 1, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 189 */
            chars[189] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 190 */
            chars[190] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 191 */
            chars[191] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0);
            /* num: 192 */
            chars[192] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 193 */
            chars[193] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 194 */
            chars[194] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0);
            /* num: 195 */
            chars[195] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0);
            /* num: 196 */
            chars[196] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 197 */
            chars[197] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0);
            /* num: 198 */
            chars[198] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0);
            /* num: 199 */
            chars[199] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 1, 1,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0);
            /* num: 200 */
            chars[200] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 1, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 201 */
            chars[201] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 1, 1, 1,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0);
            /* num: 202 */
            chars[202] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        1, 1, 0, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 203 */
            chars[203] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        1, 1, 0, 1, 1, 1,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0);
            /* num: 204 */
            chars[204] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 1, 1,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 1, 1, 1,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0);
            /* num: 205 */
            chars[205] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 206 */
            chars[206] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        1, 1, 0, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        1, 1, 0, 1, 1, 1,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0);
            /* num: 207 */
            chars[207] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 208 */
            chars[208] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 209 */
            chars[209] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0);
            /* num: 210 */
            chars[210] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0);
            /* num: 211 */
            chars[211] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 212 */
            chars[212] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1);
            /* num: 213 */
            chars[213] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1);
            /* num: 214 */
            chars[214] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1);
            /* num: 215 */
            chars[215] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1);
            /* num: 216 */
            chars[216] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1);
            /* num: 217 */
            chars[217] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1);
            /* num: 218 */
            chars[218] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1);
            /* num: 219 */
            chars[219] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1);
            /* num: 220 */
            chars[220] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0);
            /* num: 221 */
            chars[221] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0);
            /* num: 222 */
            chars[222] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0);
            /* num: 223 */
            chars[223] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0);
            /* num: 224 */
            chars[224] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0);
            /* num: 225 */
            chars[225] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 0, 0,
        0, 1, 0, 0, 0, 0);
            /* num: 226 */
            chars[226] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 227 */
            chars[227] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 228 */
            chars[228] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 229 */
            chars[229] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 1,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 230 */
            chars[230] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0);
            /* num: 231 */
            chars[231] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 232 */
            chars[232] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 233 */
            chars[233] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 234 */
            chars[234] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 1, 0, 1, 1,
        0, 0, 0, 0, 0, 0);
            /* num: 235 */
            chars[235] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 236 */
            chars[236] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 237 */
            chars[237] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 238 */
            chars[238] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 239 */
            chars[239] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 240 */
            chars[240] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 241 */
            chars[241] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 242 */
            chars[242] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 243 */
            chars[243] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 0, 0, 0,
        1, 0, 0, 1, 1, 0,
        1, 0, 0, 0, 0, 1,
        1, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1);
            /* num: 244 */
            chars[244] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        1, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 1, 1,
        0, 1, 1, 0, 0, 1,
        1, 0, 0, 0, 0, 1,
        0, 0, 0, 0, 0, 1,
        1, 1, 1, 1, 1, 1);
            /* num: 245 */
            chars[245] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 246 */
            chars[246] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 247 */
            chars[247] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 1, 0);
            /* num: 248 */
            chars[248] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 0, 0);
            /* num: 249 */
            chars[249] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0);
            /* num: 250 */
            chars[250] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0,
        1, 1, 0, 0, 0, 0);
            /* num: 251 */
            chars[251] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 0);
            /* num: 252 */
            chars[252] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 1, 1, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 253 */
            chars[253] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 1, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
            /* num: 254 */
            chars[254] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        1, 1, 0, 0, 1, 0,
        1, 1, 0, 0, 1, 1,
        1, 1, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 1);
            /* num: 255 */
            chars[255] = GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 1, 0, 0, 1, 0,
        1, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        1, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0);
        }

        public static BitsyFont CreateDefault()
        {
            var font = new BitsyFont();
            font.RebuildDefault();
            return font;
        }

        #endregion

    }
    
}
