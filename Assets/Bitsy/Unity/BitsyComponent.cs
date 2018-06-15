using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPBitsy.Unity
{

    public class BitsyComponent : MonoBehaviour
    {
        
        #region Fields

        public TextAsset GameData;
        public Texture2D FontTexture;
        public Renderer Renderer;
        public int Margin;

        [System.NonSerialized]
        private BitsyGame _game;
        [System.NonSerialized]
        private TextureRenderSurface _surface;

        #endregion

        #region CONSTRUCTOR
        
        void Start()
        {
            if (this.GameData == null) return;
            if (this.Renderer == null) this.Renderer = this.GetComponent<Renderer>();

            _surface = TextureRenderSurface.Create(this.Margin);
            this.Renderer.material.mainTexture = _surface.Texture;

            var parser = new BitsyGameParser();
            Environment environment;
            using (var reader = new System.IO.StringReader(this.GameData.text))
            {
                environment = parser.Parse(reader, BitsyUnityUtils.GetInputWASD, BitsyUnityUtils.LoadTextureFont(this.FontTexture));
            }
            
            _game = new BitsyGame();
            _game.Begin(environment, _surface);
        }

        #endregion

        #region Methods

        private void Update()
        {
            try
            {
                _game.Tick((int)(Time.deltaTime * 1000));
            }
            catch(System.Exception ex)
            {
                Debug.LogException(ex, this);
            }
            
            _surface.Texture.Apply();
        }

        #endregion

    }

}
