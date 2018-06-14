using UnityEngine;
using System.Collections.Generic;

namespace SPBitsy.Unity
{

    public static class BitsyUnityUtils
    {

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