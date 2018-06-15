using System;
using System.Collections.Generic;

namespace SPBitsy
{

    /// <summary>
    /// Supports defining custom function names that the ScriptInterpreter will recognize and evaluate accordingly.
    /// Extending the feature set otherwise not available in Bitsy-vanilla. Create a custom extension and apply it 
    /// to the ScriptInterpreter.ScriptExtension field to gain access to them from BitsyScript.
    /// 
    /// See 'BitsyScriptExtensionTable' and/or BitsyExtensionFunctions for an easy hash table for creating a script extension.
    /// 
    /// When EvalFunction is called make certain to call 'onReturn' at some point otherwise Bitsy will stall. 
    /// This includes even if the function name is unknown.
    /// </summary>
    public interface IBitsyScriptExtension
    {

        bool HasFunction(string funcName);
        void EvalFunction(Environment env, string name, object[] args, System.Action<object> onReturn);
        
    }
    
    public delegate void EvalFunctionCallback(Environment env, object[] args, System.Action<object> onReturn);

    /// <summary>
    /// Collection of standard extension functions that can be used to extend the feature set of the Bitsy ScriptInterpreter.
    /// </summary>
    public static class BitsyExtensionFunctions
    {
        
        public const string DELETESPRITE = "deletesprite";
        public const string MESSAGE = "message";

        /// <summary>
        /// Delete's a sprite with id or name.
        /// {deletesprite "id/name"}
        /// </summary>
        /// <param name="env"></param>
        /// <param name="args"></param>
        /// <param name="onReturn"></param>
        public static void DeleteSprite(Environment env, object[] args, System.Action<object> onReturn)
        {
            if(args.Length > 0)
            {
                string id = env.Names.GetSpriteId(args[0] as string);
                if(id != null)
                    env.Sprites.Remove(id);
            }

            if (onReturn != null) onReturn(null);
        }

        /// <summary>
        /// Calls env.OnMessage passing in the string parameter.
        /// {message "custom"}
        /// </summary>
        /// <param name="env"></param>
        /// <param name="args"></param>
        /// <param name="onReturn"></param>
        public static void Message(Environment env, object[] args, System.Action<object> onReturn)
        {
            if(args.Length > 0 && args[0] is string && env.OnMessage != null)
            {
                env.OnMessage(env, args[0] as string);
            }

            if (onReturn != null) onReturn(null);
        }

        /// <summary>
        /// Creates an IBitsyScriptExtension of all the methods that are members of BitsyExtensionFunctions. 
        /// Attach this to the ScriptInterperter to get access to extra functions not in Bitsy-vanilla.
        /// </summary>
        /// <returns></returns>
        public static BitsyScriptExtensionTable CreateTable()
        {
            var table = new BitsyScriptExtensionTable();
            table.AddFunction(DELETESPRITE, DeleteSprite);
            table.AddFunction(MESSAGE, Message);
            return table;
        }

    }

    /// <summary>
    /// A hash table that can be filled with named callbacks to be used as functions in the Bitsy ScriptInterpreter. 
    /// Add functions and set this the the ScriptInterpreter.ScriptExtension field to gain access to them from BitsyScript.
    /// </summary>
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