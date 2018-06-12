using UnityEngine;
using System.Collections.Generic;

namespace SPBitsy.Unity
{

    public static class BitsyUnityUtils
    {

        public static BitsyGame.InputState GetInputWASD(BitsyGame.InputId id)
        {
            KeyCode code;
            switch(id)
            {
                case BitsyGame.InputId.Up:
                    code = KeyCode.W;
                    break;
                case BitsyGame.InputId.Right:
                    code = KeyCode.D;
                    break;
                case BitsyGame.InputId.Down:
                    code = KeyCode.S;
                    break;
                case BitsyGame.InputId.Left:
                    code = KeyCode.A;
                    break;
                default:
                    return BitsyGame.InputState.None;
            }

            if (Input.GetKeyDown(code))
                return BitsyGame.InputState.Down;
            else if (Input.GetKeyUp(code))
                return BitsyGame.InputState.Released;
            else if (Input.GetKey(code))
                return BitsyGame.InputState.Held;
            else
                return BitsyGame.InputState.None;
        }

    }

}