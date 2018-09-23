using UnityEngine;
using System.Collections.Generic;

namespace SPBitsy.Unity
{

    public interface IBitsyInput
    {

        bool PollInput(BitsyInput.InputId id);

    }

}