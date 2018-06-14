using System;
using System.Collections.Generic;

namespace SPBitsy
{

    public interface IBitsyScriptExtension
    {

        bool HasFunction(string funcName);
        void EvalFunction(Environment env, string name, object[] args, System.Action<object> onReturn);
        
    }

}