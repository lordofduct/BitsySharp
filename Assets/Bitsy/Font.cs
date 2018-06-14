using System;
using System.Collections.Generic;

namespace SPBitsy
{

    public interface IFont
    {

        GfxTileSheet GetCharGfx(char c);

    }

    public sealed class BasicBitsyFont : IFont
    {

        public const int FONT_WIDTH = 6;
        public const int FONT_HEIGHT = 8;

        #region Fields

        private List<GfxTileSheet> _chars = new List<GfxTileSheet>(256);

        #endregion

        #region CONSTRUCTOR

        private BasicBitsyFont()
        {

        }

        #endregion

        #region IFont Interface

        public GfxTileSheet GetCharGfx(char c)
        {
            int i = (int)c;
            if (i < 0 || i > _chars.Count) return _chars[0];
            return _chars[i];
        }

        #endregion

        #region Rebuild Methods

        public void Rebuild()
        {
            _chars.Clear();

            /* num: 0 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 1 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 0, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 0, 0, 0, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 2 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 1, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 1, 0, 0, 0, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 3 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 4 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 0, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 5 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 6 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 7 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 8 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 0, 0, 1, 1,
        1, 1, 0, 0, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1,
        1, 1, 1, 1, 1, 1));
            /* num: 9 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0));
            /* num: 10 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
            1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,0,0,0,0,1,
		1,0,1,1,0,1,
		1,0,1,1,0,1,
		1,0,0,0,0,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1));
            /* num: 11 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,1,1,1,
		0,0,0,0,1,1,
		0,0,1,1,0,1,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 12 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 13 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,1,0,
		0,0,0,1,0,1,
		0,0,0,1,0,0,
		0,0,1,1,0,0,
		0,1,1,1,0,0,
		0,1,1,0,0,0,
		0,0,0,0,0,0));
            /* num: 14 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,1,1,
		0,0,1,1,0,1,
		0,0,1,0,1,1,
		0,0,1,1,0,1,
		0,0,1,0,1,1,
		0,1,1,0,1,1,
		0,1,1,0,0,0,
		0,0,0,0,0,0));
            /* num: 15 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,1,0,1,0,1,
		0,0,1,1,1,0,
		0,1,1,0,1,1,
		0,0,1,1,1,0,
		0,1,0,1,0,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 16 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,0,0,
		0,0,1,1,0,0,
		0,0,1,1,1,0,
		0,0,1,1,1,1,
		0,0,1,1,1,0,
		0,0,1,1,0,0,
		0,0,1,0,0,0,
		0,0,0,0,0,0));
            /* num: 17 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,1,0,
		0,0,0,1,1,0,
		0,0,1,1,1,0,
		0,1,1,1,1,0,
		0,0,1,1,1,0,
		0,0,0,1,1,0,
		0,0,0,0,1,0,
		0,0,0,0,0,0));
            /* num: 18 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,1,1,1,1,1,
		0,0,0,1,0,0,
		0,1,1,1,1,1,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 19 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 20 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,1,
		0,1,0,1,0,1,
		0,1,0,1,0,1,
		0,0,1,1,0,1,
		0,0,0,1,0,1,
		0,0,0,1,0,1,
		0,0,0,1,0,1,
		0,0,0,0,0,0));
            /* num: 21 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,0,1,1,0,0,
		0,0,1,0,1,0,
		0,0,0,1,1,0,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 22 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,1,1,0,
		0,1,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 23 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,1,1,1,1,1,
		0,0,0,1,0,0,
		0,1,1,1,1,1,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0));
            /* num: 24 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,1,1,1,1,1,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 25 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,1,1,1,1,1,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 26 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,0,1,1,0,
		0,1,1,1,1,1,
		0,0,0,1,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 27 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,1,1,0,0,
		0,1,1,1,1,1,
		0,0,1,1,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 28 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 29 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,1,1,1,1,1,
		0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 30 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,0,1,1,1,0,
		0,1,1,1,1,1,
		0,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 31 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,1,
		0,1,1,1,1,1,
		0,0,1,1,1,0,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 32 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 33 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 34 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,0,1,1,
		0,1,1,0,1,1,
		0,1,0,0,1,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 35 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,1,0,1,0,
		0,1,1,1,1,1,
		0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,1,1,1,1,1,
		0,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 36 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,0,
		0,0,1,1,0,0,
		0,0,0,0,1,0,
		0,1,1,1,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 37 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,0,0,1,
		0,1,1,0,0,1,
		0,0,0,0,1,0,
		0,0,0,1,0,0,
		0,0,1,0,0,0,
		0,1,0,0,1,1,
		0,1,0,0,1,1,
		0,0,0,0,0,0));
            /* num: 38 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,0,1,0,0,0,
		0,1,0,1,0,1,
		0,1,0,0,1,0,
		0,0,1,1,0,1,
		0,0,0,0,0,0));
            /* num: 39 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,0,0,
		0,0,1,1,0,0,
		0,0,1,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 40 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 41 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,1,0,0,0,
		0,0,0,0,0,0));
            /* num: 42 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,1,0,1,0,
		0,0,1,1,1,0,
		0,1,1,1,1,1,
		0,0,1,1,1,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 43 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,1,1,1,1,1,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 44 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,0,0,
		0,0,1,1,0,0,
		0,0,1,0,0,0));
            /* num: 45 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 46 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,0,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 47 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,1,
		0,0,0,0,1,0,
		0,0,0,1,0,0,
		0,0,1,0,0,0,
		0,1,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 48 ZERO!!!!*/
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,1,1,
		0,1,0,1,0,1,
		0,1,1,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 49 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,1,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 50 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,0,0,0,0,1,
		0,0,0,1,1,0,
		0,0,1,0,0,0,
		0,1,0,0,0,0,
		0,1,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 51 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,0,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 52 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,1,0,
		0,0,0,1,1,0,
		0,0,1,0,1,0,
		0,1,0,0,1,0,
		0,1,1,1,1,1,
		0,0,0,0,1,0,
		0,0,0,0,1,0,
		0,0,0,0,0,0));
            /* num: 53 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,1,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,1,1,1,0,
		0,0,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 54 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,1,0,
		0,0,1,0,0,0,
		0,1,0,0,0,0,
		0,1,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 55 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,1,
		0,0,0,0,0,1,
		0,0,0,0,1,0,
		0,0,0,1,0,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,0,0,0,0));
            /* num: 56 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 57 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,1,
		0,0,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 58 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,0,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0,
		0,0,1,1,0,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 59 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,0,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0,
		0,0,1,1,0,0,
		0,0,1,1,0,0,
		0,0,1,0,0,0));
            /* num: 60 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,1,0,
		0,0,0,1,0,0,
		0,0,1,0,0,0,
		0,1,0,0,0,0,
		0,0,1,0,0,0,
		0,0,0,1,0,0,
		0,0,0,0,1,0,
		0,0,0,0,0,0));
            /* num: 61 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 62 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,0,0,
		0,0,0,1,0,0,
		0,0,0,0,1,0,
		0,0,0,0,0,1,
		0,0,0,0,1,0,
		0,0,0,1,0,0,
		0,0,1,0,0,0,
		0,0,0,0,0,0));
            /* num: 63 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,0,0,0,0,1,
		0,0,0,1,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 64 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,1,1,1,
		0,1,0,1,0,1,
		0,1,0,1,1,1,
		0,1,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 65 Start of Capital Letters*/
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,1,1,1,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,0,0,0,0));
            /* num: 66 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 67 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 68 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 69 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,1,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,1,1,1,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 70 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,1,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,1,1,1,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 71 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,0,
		0,1,0,1,1,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 72 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,1,1,1,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,0,0,0,0));
            /* num: 73 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 74 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,1,
		0,0,0,0,0,1,
		0,0,0,0,0,1,
		0,0,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 75 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,1,
		0,1,0,0,1,0,
		0,1,0,1,0,0,
		0,1,1,0,0,0,
		0,1,0,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,0,1,
		0,0,0,0,0,0));
            /* num: 76 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 77 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,1,
		0,1,1,0,1,1,
		0,1,0,1,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,0,0,0,0));
            /* num: 78 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,1,
		0,1,1,0,0,1,
		0,1,0,1,0,1,
		0,1,0,0,1,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,0,0,0,0));
            /* num: 79 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 80 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 81 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,1,0,1,
		0,1,0,0,1,0,
		0,0,1,1,0,1,
		0,0,0,0,0,0));
            /* num: 82 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,1,0,0,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,0,0,0,0));
            /* num: 83 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 84 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,1,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 85 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 86 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,0,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 87 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,1,0,1,
		0,1,0,1,0,1,
		0,1,0,1,0,1,
		0,1,0,1,0,1,
		0,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 88 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,0,1,0,
		0,0,0,1,0,0,
		0,0,1,0,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,0,0,0,0));
            /* num: 89 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,0,1,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 90 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,0,
		0,0,0,0,1,0,
		0,0,0,1,0,0,
		0,0,1,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 91 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 92 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,1,0,0,0,0,
		0,0,1,0,0,0,
		0,0,0,1,0,0,
		0,0,0,0,1,0,
		0,0,0,0,0,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 93 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,0,0,0,1,0,
		0,0,0,0,1,0,
		0,0,0,0,1,0,
		0,0,0,0,1,0,
		0,0,0,0,1,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 94 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,1,0,1,0,
		0,1,0,0,0,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 95 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1));
            /* num: 96 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,0,0,
		0,0,1,1,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 97 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,1,
		0,0,1,1,1,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 98 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 99 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,0,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 100 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,1,
		0,0,0,0,0,1,
		0,0,1,1,1,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 101 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,1,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 102 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,1,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,1,1,1,1,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,0,0,0,0));
            /* num: 103 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,1,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,1,
		0,0,1,1,1,0));
            /* num: 104 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,0,0,0,0));
            /* num: 105 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,1,0,
		0,0,0,0,0,0));
            /* num: 106 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,1,0,
		0,0,0,0,0,0,
		0,0,0,1,1,0,
		0,0,0,0,1,0,
		0,0,0,0,1,0,
		0,0,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0));
            /* num: 107 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,1,0,0,
		0,1,1,0,0,0,
		0,1,0,1,0,0,
		0,1,0,0,1,0,
		0,0,0,0,0,0));
            /* num: 108 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,1,0,
		0,0,0,0,0,0));
            /* num: 109 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,0,1,0,
		0,1,0,1,0,1,
		0,1,0,1,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,0,0,0,0));
            /* num: 110 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,0,0,0,0));
            /* num: 111 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 112 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,1,0,0,0,0));
            /* num: 113 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,1,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,1));
            /* num: 114 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,0,1,1,0,
		0,0,1,0,0,1,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,1,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 115 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 116 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,1,0,0,0,
		0,1,1,1,1,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,1,0,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 117 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,1,1,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 118 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,0,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 119 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,1,0,1,
		0,1,1,1,1,1,
		0,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 120 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,0,0,0,0));
            /* num: 121 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,1,1,0,0,0));
            /* num: 122 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,1,1,0,
		0,0,0,0,1,0,
		0,0,1,1,0,0,
		0,1,0,0,0,0,
		0,1,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 123 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,1,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,1,1,0,0,0,
		0,0,1,0,0,0,
		0,0,1,0,0,0,
		0,0,0,1,1,0,
		0,0,0,0,0,0));
            /* num: 124 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0));
            /* num: 125 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,0,0,
		0,0,0,0,1,0,
		0,0,0,0,1,0,
		0,0,0,0,1,1,
		0,0,0,0,1,0,
		0,0,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 126 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,1,0,1,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 127 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,1,1,0,1,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 128 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,1,1,0,0));
            /* num: 129 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,1,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,1,1,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 130 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,1,1,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,1,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 131 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,1,
		0,0,1,1,1,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 132 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,1,
		0,0,1,1,1,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 133 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,0,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,1,
		0,0,1,1,1,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 134 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,0,1,0,1,0,
		0,0,1,1,1,0,
		0,0,0,0,0,1,
		0,0,1,1,1,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 135 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,0,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,1,1,0,0));
            /* num: 136 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,1,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 137 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,1,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 138 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,0,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,1,1,1,0,
		0,1,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 139 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,1,0,
		0,0,0,0,0,0));
            /* num: 140 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,1,0,
		0,0,0,0,0,0));
            /* num: 141 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,0,0,
		0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,1,0,
		0,0,0,0,0,0));
            /* num: 142 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,1,0,1,0,
		0,1,0,0,0,1,
		0,1,1,1,1,1,
		0,1,0,0,0,1,
		0,0,0,0,0,0));
            /* num: 143 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,0,1,0,1,0,
		0,0,1,1,1,0,
		0,1,1,0,1,1,
		0,1,0,0,0,1,
		0,1,1,1,1,1,
		0,1,0,0,0,1,
		0,0,0,0,0,0));
            /* num: 144 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,1,1,
		0,0,0,0,0,0,
		0,1,1,1,1,1,
		0,1,0,0,0,0,
		0,1,1,1,1,0,
		0,1,0,0,0,0,
		0,1,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 145 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,1,1,0,
		0,0,0,1,0,1,
		0,1,1,1,1,1,
		0,1,0,1,0,0,
		0,0,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 146 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,1,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,1,1,1,1,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,1,1,
		0,0,0,0,0,0));
            /* num: 147 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,0,0,0,0,0,
		0,0,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 148 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 149 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 150 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,1,1,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 151 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,0,0,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,1,1,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 152 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,1,1,0,0,0));
            /* num: 153 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 154 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 155 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 156 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,1,0,
		0,0,1,0,0,1,
		0,0,1,0,0,0,
		0,1,1,1,1,0,
		0,0,1,0,0,0,
		0,0,1,0,0,1,
		0,1,0,1,1,1,
		0,0,0,0,0,0));
            /* num: 157 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,1,
		0,0,1,0,1,0,
		0,0,0,1,0,0,
		0,1,1,1,1,1,
		0,0,0,1,0,0,
		0,1,1,1,1,1,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 158 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,0,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,1,0,1,0,
		0,1,0,1,1,1,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,0,0,0,0));
            /* num: 159 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,1,0,
		0,0,0,1,0,1,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,1,0,1,0,0,
		0,0,1,0,0,0));
            /* num: 160 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,1,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,1,
		0,0,1,1,1,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 161 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,1,0,
		0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,1,0,
		0,0,0,0,0,0));
            /* num: 162 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,1,0,
		0,0,0,0,0,0,
		0,0,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 163 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,1,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,1,1,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 164 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,1,0,1,0,0,
		0,0,0,0,0,0,
		0,1,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,0,0,0,0));
            /* num: 165 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,1,0,1,0,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,1,0,1,0,
		0,1,0,1,1,0,
		0,1,0,0,1,0,
		0,0,0,0,0,0));
            /* num: 166 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,0,0,0,0,1,
		0,0,1,1,1,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,0,
		0,0,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 167 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0,
		0,1,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 168 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,1,1,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 169 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,1,1,1,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 170 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,0,0,0,0,1,
		0,0,0,0,0,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 171 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,1,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,0,0,0,1,0,
		0,0,0,1,1,1,
		0,0,0,0,0,0));
            /* num: 172 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,1,0,0,
		0,0,1,0,1,1,
		0,1,0,1,0,1,
		0,0,0,1,1,1,
		0,0,0,0,0,1,
		0,0,0,0,0,0));
            /* num: 173 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 174 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,0,0,1,
		0,1,0,0,1,0,
		0,0,1,0,0,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 175 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,0,1,0,0,1,
		0,1,0,0,1,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 176 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,1,
		0,0,0,0,0,0,
		1,0,1,0,1,0,
		0,0,0,0,0,0,
		0,1,0,1,0,1,
		0,0,0,0,0,0,
		1,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 177 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,1,
		1,0,1,0,1,0,
		0,1,0,1,0,1,
		1,0,1,0,1,0,
		0,1,0,1,0,1,
		1,0,1,0,1,0,
		0,1,0,1,0,1,
		1,0,1,0,1,0));
            /* num: 178 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,0,1,0,1,0,
		1,1,1,1,1,1,
		0,1,0,1,0,1,
		1,1,1,1,1,1,
		1,0,1,0,1,0,
		1,1,1,1,1,1,
		0,1,0,1,0,1,
		1,1,1,1,1,1));
            /* num: 179 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0));
            /* num: 180 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		1,1,1,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0));
            /* num: 181 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,1,1,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0));
            /* num: 182 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		1,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0));
            /* num: 183 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0));
            /* num: 184 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		1,1,1,1,0,0,
		0,0,0,1,0,0,
		1,1,1,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0));
            /* num: 185 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		1,1,0,1,0,0,
		0,0,0,1,0,0,
		1,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0));
            /* num: 186 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0));
            /* num: 187 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		1,1,1,1,0,0,
		0,0,0,1,0,0,
		1,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0));
            /* num: 188 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		1,1,0,1,0,0,
		0,0,0,1,0,0,
		1,1,1,1,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 189 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		1,1,1,1,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 190 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		1,1,1,1,0,0,
		0,0,0,1,0,0,
		1,1,1,1,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 191 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0));
            /* num: 192 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 193 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		1,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 194 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0));
            /* num: 195 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,1,1,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0));
            /* num: 196 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 197 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		1,1,1,1,1,1,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0));
            /* num: 198 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,1,1,
		0,0,0,1,0,0,
		0,0,0,1,1,1,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0));
            /* num: 199 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,1,1,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0));
            /* num: 200 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		0,1,0,1,1,1,
		0,1,0,0,0,0,
		0,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 201 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,1,1,1,1,1,
		0,1,0,0,0,0,
		0,1,0,1,1,1,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0));
            /* num: 202 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		1,1,0,1,1,1,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 203 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,0,0,0,0,0,
		1,1,0,1,1,1,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0));
            /* num: 204 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		0,1,0,1,1,1,
		0,1,0,0,0,0,
		0,1,0,1,1,1,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0));
            /* num: 205 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 206 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		1,1,0,1,1,1,
		0,0,0,0,0,0,
		1,1,0,1,1,1,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0));
            /* num: 207 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		1,1,1,1,1,1,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 208 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		1,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 209 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0));
            /* num: 210 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0));
            /* num: 211 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,0,1,0,0,
		0,1,1,1,1,1,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 212 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1));
            /* num: 213 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		1,1,1,1,1,1));
            /* num: 214 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1));
            /* num: 215 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1));
            /* num: 216 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1));
            /* num: 217 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1));
            /* num: 218 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1));
            /* num: 219 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1,
		1,1,1,1,1,1));
            /* num: 220 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0));
            /* num: 221 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0));
            /* num: 222 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0));
            /* num: 223 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0));
            /* num: 224 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0));
            /* num: 225 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,1,1,1,0,0,
		0,1,0,0,1,0,
		0,1,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,1,1,0,0,
		0,1,0,0,0,0));
            /* num: 226 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,1,1,0,
		0,1,0,0,1,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 227 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,1,1,1,1,1,
		0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 228 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,1,
		0,0,1,1,1,1,
		0,1,0,0,0,1,
		0,0,1,1,1,1,
		0,0,0,0,0,0));
            /* num: 229 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,1,1,1,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 230 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,1,1,0,0,
		0,1,0,0,0,0,
		0,1,0,0,0,0));
            /* num: 231 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,0,1,0,
		0,1,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 232 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 233 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,1,1,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 234 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,0,1,0,
		0,0,1,0,1,0,
		0,1,1,0,1,1,
		0,0,0,0,0,0));
            /* num: 235 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,1,0,0,
		0,1,0,0,0,0,
		0,0,1,0,0,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,1,0,0,1,0,
		0,0,1,1,0,0,
		0,0,0,0,0,0));
            /* num: 236 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,1,0,1,0,
		0,1,0,1,0,1,
		0,1,0,1,0,1,
		0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 237 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,1,0,1,0,1,
		0,1,0,1,0,1,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0));
            /* num: 238 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,0,
		0,1,1,1,1,0,
		0,1,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 239 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,1,1,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 240 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,1,1,1,1,0,
		0,0,0,0,0,0,
		0,1,1,1,1,0,
		0,0,0,0,0,0,
		0,1,1,1,1,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 241 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,1,0,0,
		0,0,1,1,1,0,
		0,0,0,1,0,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 242 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,0,0,
		0,0,1,1,0,0,
		0,0,0,0,1,0,
		0,0,1,1,0,0,
		0,1,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 243 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		1,1,1,0,0,0,
		1,0,0,1,1,0,
		1,0,0,0,0,1,
		1,0,0,0,0,0,
		1,1,1,1,1,1));
            /* num: 244 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		1,1,1,1,1,1,
		0,0,0,1,1,1,
		0,1,1,0,0,1,
		1,0,0,0,0,1,
		0,0,0,0,0,1,
		1,1,1,1,1,1));
            /* num: 245 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,0,0,1,0,0,
		0,1,0,1,0,0,
		0,0,1,0,0,0,
		0,0,0,0,0,0));
            /* num: 246 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,0,1,1,1,0,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,1,0,0,0,1,
		0,0,1,1,1,0,
		0,0,0,0,0,0));
            /* num: 247 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0,
		1,1,1,1,1,0));
            /* num: 248 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0,
		1,1,1,1,0,0));
            /* num: 249 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0,
		1,1,1,0,0,0));
            /* num: 250 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0,
		1,1,0,0,0,0));
            /* num: 251 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0,
		1,0,0,0,0,0));
            /* num: 252 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,1,0,1,0,
		0,0,0,0,0,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		0,1,0,1,1,0,
		0,0,1,0,1,0,
		0,0,0,0,0,0));
            /* num: 253 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,1,0,0,0,
		0,0,0,1,0,0,
		0,0,1,0,0,0,
		0,1,1,1,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
            /* num: 254 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0,
		0,1,1,1,1,0,
		1,1,0,0,1,0,
		1,1,0,0,1,1,
		1,1,1,1,1,0,
		0,0,1,1,1,1));
            /* num: 255 */
            _chars.Add(GfxTileSheet.CreateStatic(FONT_WIDTH, FONT_HEIGHT,
        0,1,0,0,1,0,
		1,1,1,1,1,1,
		0,1,0,0,1,0,
		0,1,0,0,1,0,
		1,1,1,1,1,1,
		0,1,0,0,1,0,
		0,0,0,0,0,0,
		0,0,0,0,0,0));
        }

        #endregion

        #region Static Factory

        private static BasicBitsyFont _default;

        public static IFont LoadFont()
        {
            if(_default == null)
            {
                _default = new BasicBitsyFont();
                _default.Rebuild();
            }

            return _default;
        }

        public static void UnloadFont()
        {
            _default = null;
        }

        #endregion

    }

}
