using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPBitsy.Unity
{

    public class BitsyComponent : MonoBehaviour
    {

        #region Fields

        public TextAsset GameData;
        public Renderer Renderer;

        [System.NonSerialized]
        private BitsyGame _game;
        [System.NonSerialized]
        private TextureRenderSurface _surface;

        #endregion

        #region CONSTRUCTOR

        // Use this for initialization
        void Start()
        {
            _surface = TextureRenderSurface.Create();
            this.Renderer.material.mainTexture = _surface.Texture;

            var parser = new BitsyGameParser();
            Environment environment;
            using (var reader = new System.IO.StringReader(this.GameData.text))
            {
                environment = parser.Parse(reader);
            }

            _game = new BitsyGame();
            _game.Begin(environment, BitsyUnityUtils.GetInputWASD, _surface);
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
        }

        #endregion

    }

}
