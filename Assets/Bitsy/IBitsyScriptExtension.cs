using System;
using System.Collections.Generic;

namespace SPBitsy
{

    public interface IBitsyScriptExtension
    {

        bool HasFunction(string funcName);
        void EvalFunction(Environment env, string name, object[] args, System.Action<object> onReturn);
        
    }

    public delegate void EvalFunctionCallback(Environment env, object[] args, System.Action<object> onReturn);

    public static class BitsyExtensionFunctions
    {

        //TODO - add some general extension functions

        public const string EXAMPLE = "exampleFuncName";

        public static void ExampleFunc(Environment env, object[] args, System.Action<object> onReturn)
        {
            if (onReturn != null) onReturn(null);
        }

        public static BitsyScriptExtensionTable CreateTable()
        {
            var table = new BitsyScriptExtensionTable();
            //TODO - add all general extensions
            return table;
        }

    }

    public class BitsyScriptExtensionTable : IBitsyScriptExtension
    {

        #region Fields

        private Dictionary<string, EvalFunctionCallback> _table = new Dictionary<string, EvalFunctionCallback>();

        #endregion

        #region Methods

        public void AddFunction(string name, EvalFunctionCallback callback)
        {
            if (callback == null) throw new System.ArgumentNullException("callback");
            _table[name] = callback;
        }

        public bool RemoveFunction(string name)
        {
            return _table.Remove(name);
        }

        #endregion

        #region IBitsyScriptExtension Interface

        public bool HasFunction(string funcName)
        {
            return _table.ContainsKey(funcName);
        }

        public void EvalFunction(Environment env, string name, object[] args, System.Action<object> onReturn)
        {
            EvalFunctionCallback d;
            if(_table.TryGetValue(name, out d))
            {
                d(env, args, onReturn);
            }
        }

        #endregion

    }

}