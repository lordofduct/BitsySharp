using UnityEngine;
using System.Collections.Generic;

namespace SPBitsy.Unity
{

    public class UnityInputForBitsy : MonoBehaviour, IBitsyInput
    {

        #region Fields

        public string HorizontalAxis = "Horizontal";
        public string VerticalAxis = "Vertical";
        public string ActionButton = "Submit";

        #endregion

        #region IBitsyInput Interface

        public bool PollInput(BitsyInput.InputId id)
        {
            switch (id)
            {
                case BitsyInput.InputId.Any:
                    return Input.GetButton(ActionButton) || Mathf.Abs(Input.GetAxis(HorizontalAxis)) > 0.5f || Mathf.Abs(Input.GetAxis(VerticalAxis)) > 0.5f;
                case BitsyInput.InputId.Up:
                    return Input.GetAxis(VerticalAxis) > 0.5f;
                case BitsyInput.InputId.Right:
                    return Input.GetAxis(HorizontalAxis) > 0.5f;
                case BitsyInput.InputId.Down:
                    return Input.GetAxis(VerticalAxis) < -0.5f;
                case BitsyInput.InputId.Left:
                    return Input.GetAxis(HorizontalAxis) < -0.5f;
                case BitsyInput.InputId.Action:
                    return Input.GetButton(ActionButton);
                default:
                    return false;
            }
        }

        #endregion

    }

}