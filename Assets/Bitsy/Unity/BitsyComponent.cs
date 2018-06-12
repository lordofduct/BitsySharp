using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPBitsy.Unity
{

    public class BitsyComponent : MonoBehaviour
    {

        #region Fields

        public TextAsset GameData;

        [System.NonSerialized]
        private BitsyGame _game;

        #endregion

        #region CONSTRUCTOR

        // Use this for initialization
        void Start()
        {
            var parser = new BitsyGameParser();
            Environment environment;
            using (var reader = new System.IO.StringReader(this.GameData.text))
            {
                environment = parser.Parse(reader);
            }

            _game = new BitsyGame();
            _game.Begin(environment, BitsyUnityUtils.GetInputWASD);
        }

        #endregion

        #region Methods

        private void Update()
        {
            _game.Tick();
        }

        #endregion

    }

}
