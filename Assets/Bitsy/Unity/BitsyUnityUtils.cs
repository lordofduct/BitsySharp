using UnityEngine;
using System.Collections.Generic;

namespace SPBitsy.Unity
{

    public static class BitsyUnityUtils
    {

        public const int TEXTUREFONT_FONTTILE_EDGE_CNT = 16;
        public const int TEXTUREFONT_FONTTILE_DIM = 8;
        public const int TEXTUREFONT_DIM = TEXTUREFONT_FONTTILE_EDGE_CNT * TEXTUREFONT_FONTTILE_DIM;

        public static BitsyFont LoadTextureFont(Texture2D texture)
        {
            if (texture == null) return null;
            if (texture.width < TEXTUREFONT_DIM || texture.height < TEXTUREFONT_DIM)
            {
                Debug.LogWarning("Attempted to load BitsyFont from a texture with the wrong proportions.");
                return null;
            }

            var font = new BitsyFont();
            byte[] arr = new byte[BitsyGame.FONT_WIDTH * BitsyGame.FONT_HEIGHT];
            for(int i = 0; i < 256; i++)
            {
                var gfx = new GfxTileSheet(BitsyGame.FONT_WIDTH, BitsyGame.FONT_HEIGHT, 1);
                int x = (i % BitsyUnityUtils.TEXTUREFONT_FONTTILE_EDGE_CNT) * BitsyUnityUtils.TEXTUREFONT_FONTTILE_DIM;
                int y = (i / BitsyUnityUtils.TEXTUREFONT_FONTTILE_EDGE_CNT) * BitsyUnityUtils.TEXTUREFONT_FONTTILE_DIM;
                x += 1;
                y = TEXTUREFONT_DIM - y - 1;
                
                for(int j = 0; j < arr.Length; j++)
                {
                    int ix = j % BitsyGame.FONT_WIDTH;
                    int iy = j / BitsyGame.FONT_WIDTH;
                    var c = texture.GetPixel(x + ix, y - iy);
                    arr[j] = (c.r > 0.5f) ? (byte)1 : (byte)0;
                }
                gfx.SetPixels(arr);
                font.SetCharGfx((char)i, gfx);
            }
            return font;
        }

        public static Texture2D DrawFontToTexture(IFont font)
        {
            var text = TextureRenderSurface.CreateCustomSize(BitsyUnityUtils.TEXTUREFONT_DIM, BitsyUnityUtils.TEXTUREFONT_DIM);

            text.FillSurface(BitsyGame.Color.Black);

            for (int i = 0; i < 256; i++)
            {
                var gfx = font.GetCharGfx((char)i);
                int x = (i % BitsyUnityUtils.TEXTUREFONT_FONTTILE_EDGE_CNT) * BitsyUnityUtils.TEXTUREFONT_FONTTILE_DIM;
                int y = (i / BitsyUnityUtils.TEXTUREFONT_FONTTILE_EDGE_CNT) * BitsyUnityUtils.TEXTUREFONT_FONTTILE_DIM;
                gfx.Draw(0, x + 1, y, BitsyGame.Color.White, text);
            }

            return text.Texture;
        }



        public static bool GetInputWASD(BitsyInput.InputId id)
        {
            switch (id)
            {
                case BitsyInput.InputId.Any:
                    return Input.anyKey;
                case BitsyInput.InputId.Up:
                    return Input.GetKey(KeyCode.W);
                case BitsyInput.InputId.Right:
                    return Input.GetKey(KeyCode.D);
                case BitsyInput.InputId.Down:
                    return Input.GetKey(KeyCode.S);
                case BitsyInput.InputId.Left:
                    return Input.GetKey(KeyCode.A);
                case BitsyInput.InputId.Action:
                    return Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter);
                default:
                    return false;
            }
        }
        
    }

}