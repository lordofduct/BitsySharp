using UnityEngine;
using System.Collections.Generic;

namespace SPBitsy.Unity
{

    public static class BitsyUnityUtils
    {

        public static bool GetInputWASD(BitsyGame.InputId id)
        {
            switch(id)
            {
                case BitsyGame.InputId.Any:
                    return Input.anyKeyDown;
                case BitsyGame.InputId.Up:
                    return Input.GetKey(KeyCode.W);
                case BitsyGame.InputId.Right:
                    return Input.GetKey(KeyCode.D);
                case BitsyGame.InputId.Down:
                    return Input.GetKey(KeyCode.S);
                case BitsyGame.InputId.Left:
                    return Input.GetKey(KeyCode.A);
                default:
                    return false;
            }
        }

    }

}