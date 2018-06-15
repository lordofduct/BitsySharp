using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPBitsy.Unity
{

    public sealed class BitsyComponent : MonoBehaviour
    {
        
        #region Fields

        public TextAsset GameData;
        public Texture2D FontTexture;
        public Renderer Renderer;
        public int Margin;
        public bool ShowTitleText = true;
        [Tooltip("Include the default extension functions defined in the class 'BitsyExtensionFunctions'.")]
        public bool UseExtensionFunctions;
        [Tooltip("If the extension function 'message' is dispatched, it calls the string parameter of it as a 'SendMessage' in unity.")]
        public bool HandleBitsyMessagesAsSendMessage;
        [Tooltip("If the extension function 'message' is dispatched, it calls the 'OnMessage' UnityEvent passing along the included string parameter.")]
        public bool HandleBitsyMessagesAsUnityEvent;

        [SerializeField]
        private BitsyMessageUnityEvent _onBitsyMessage = new BitsyMessageUnityEvent();

        [System.NonSerialized]
        private BitsyGame _game = new BitsyGame();
        [System.NonSerialized]
        private TextureRenderSurface _surface;

        #endregion

        #region CONSTRUCTOR

        private void Awake()
        {
            if (this.Renderer == null) this.Renderer = this.GetComponent<Renderer>();
            if (this.Renderer == null)
            {
                Debug.LogWarning("BitsyComponent requires a Renderer to render to.");
                this.enabled = false;
                return;
            }

            _surface = TextureRenderSurface.Create(this.Margin);
        }
        
        void Start()
        {
            this.RestartGame();
        }

        #endregion

        #region Properties

        /// <summary>
        /// A reference to the current game.
        /// </summary>
        public BitsyGame Game
        {
            get { return _game; }
        }

        public BitsyMessageUnityEvent OnMessage
        {
            get { return _onBitsyMessage; }
        }

        public Texture2D Texture
        {
            get { return _surface != null ? _surface.Texture : null; }
        }

        #endregion

        #region Methods

        public void RestartGame()
        {
            if (this.GameData == null || this.Renderer == null || _surface == null)
            {
                this.enabled = false;
                return;
            }

            //parse game
            var parser = new BitsyGameParser();
            Environment environment;
            using (var reader = new System.IO.StringReader(this.GameData.text))
            {
                environment = parser.Parse(reader, BitsyUnityUtils.GetInputWASD, BitsyUnityUtils.LoadTextureFont(this.FontTexture));
            }

            if (this.UseExtensionFunctions) environment.ScriptInterpreter.ScriptExtension = BitsyExtensionFunctions.CreateTable();
            environment.OnMessage += this.OnBitsyMessageCallback;


            //prepare renderer
            if (this.Margin != _surface.Margin)
            {
                Object.Destroy(_surface.Texture);
                _surface = TextureRenderSurface.Create(this.Margin);
            }
            this.Renderer.material.mainTexture = _surface.Texture;
            
            //begin game
            _game.Begin(environment, _surface, this.ShowTitleText);
        }

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

        private void OnBitsyMessageCallback(Environment env, string parameter)
        {
            if (this.HandleBitsyMessagesAsSendMessage)
                this.SendMessage(parameter);
            if (this.HandleBitsyMessagesAsUnityEvent)
                _onBitsyMessage.Invoke(parameter);

        }

        #endregion

        #region Special Types

        [System.Serializable]
        public class BitsyMessageUnityEvent : UnityEngine.Events.UnityEvent<string>
        {

        }

        #endregion

    }

}
