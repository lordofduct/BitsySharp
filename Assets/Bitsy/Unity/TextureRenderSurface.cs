using UnityEngine;
using System.Collections.Generic;

namespace SPBitsy.Unity
{

    public sealed class TextureRenderSurface : IRenderSurface, System.IDisposable
    {

        #region Fields

        private Texture2D _texture;

        //caches
        private Color32[] _color = new Color32[1];
        private Color32[] _surface;
        private Color32[] _tile;

        #endregion

        #region CONSTRUCTOR

        private TextureRenderSurface(Texture2D texture)
        {
            _texture = texture;
        }

        #endregion

        #region Properties

        public Texture2D Texture
        {
            get { return _texture; }
        }

        #endregion

        #region IRenderSurface Interface

        public void SetPixel(BitsyGame.Color color, int x, int y)
        {
            _color[0].r = color.r;
            _color[0].g = color.g;
            _color[0].b = color.b;
            _color[0].a = color.a;

            _texture.SetPixels32(x, y, 1, 1, _color);
        }
        
        public void FillSurface(BitsyGame.Color color)
        {
            if(_surface == null)
            {
                _surface = new Color32[_texture.width * _texture.height];
            }
            for (int i = 0; i < _surface.Length; i++)
            {
                _surface[i].r = color.r;
                _surface[i].g = color.g;
                _surface[i].b = color.b;
                _surface[i].a = color.a;
            }
            _texture.SetPixels32(_surface);
        }

        public void FillTile(BitsyGame.Color color, int x, int y)
        {
            if(_tile == null)
            {
                _tile = new Color32[BitsyGame.TILESIZE * BitsyGame.TILESIZE];
            }
            for (int i = 0; i < _tile.Length; i++)
            {
                _tile[i].r = color.r;
                _tile[i].g = color.g;
                _tile[i].b = color.b;
                _tile[i].a = color.a;
            }
            _texture.SetPixels32(x, y, BitsyGame.TILESIZE, BitsyGame.TILESIZE, _tile);
        }

        #endregion

        #region IDisposable Interface

        public bool IsDisposed
        {
            get { return _texture == null; }
        }

        public void Dispose()
        {
            if(_texture != null)
            {
                Object.Destroy(_texture);
                _texture = null;
            }
            _surface = null;
            _tile = null;
        }

        #endregion

        #region Static Methods

        public static TextureRenderSurface Create()
        {
            return new TextureRenderSurface(new Texture2D(BitsyGame.RENDERSIZE, BitsyGame.RENDERSIZE));
        }

        #endregion

    }

}