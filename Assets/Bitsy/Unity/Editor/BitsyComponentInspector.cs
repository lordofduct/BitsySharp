using UnityEngine;
using UnityEditor;
using System.Linq;

namespace SPBitsy.Unity.Editor
{

    [CustomEditor(typeof(BitsyComponent))]
    public class BitsyComponentInspector : UnityEditor.Editor
    {
        public const string PROP_HANDLEBITSYMSG = "HandleBitsyMessagesAsUnityEvent";
        public const string PROP_ONBITSYMSG = "_onBitsyMessage";
        public const string PROP_MSGHANDLERS = "_messageHandlers";
        private const string PROP_MSG = "Message";
        private const string PROP_MSGHANDLER = "OnMessage";

        private UnityEditorInternal.ReorderableList _messageHandlersList;

        private void OnEnable()
        {
            _messageHandlersList = new UnityEditorInternal.ReorderableList(this.serializedObject, this.serializedObject.FindProperty(PROP_MSGHANDLERS));
            _messageHandlersList.elementHeight = EditorGUIUtility.singleLineHeight;
            _messageHandlersList.drawHeaderCallback = _lst_DrawHeader;
            _messageHandlersList.drawElementCallback = _lst_DrawElement;
        }

        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();
            
            DrawDefaultInspectorExcept(this.serializedObject, PROP_HANDLEBITSYMSG, PROP_ONBITSYMSG, PROP_MSGHANDLERS);

            //draw global msg handler
            var propHandleGlobal = this.serializedObject.FindProperty(PROP_HANDLEBITSYMSG);
            EditorGUILayout.PropertyField(propHandleGlobal);
            if(propHandleGlobal.boolValue)
            {
                EditorGUILayout.PropertyField(this.serializedObject.FindProperty(PROP_ONBITSYMSG));
            }

            //draw messages
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Message Handlers", EditorStyles.boldLabel);
            _messageHandlersList.DoLayoutList();
            if(_messageHandlersList.index >= 0 && _messageHandlersList.index < _messageHandlersList.serializedProperty.arraySize)
            {
                EditorGUI.indentLevel++;
                var entry = _messageHandlersList.serializedProperty.GetArrayElementAtIndex(_messageHandlersList.index);
                var propMsg = entry.FindPropertyRelative(PROP_MSG);
                var propHandler = entry.FindPropertyRelative(PROP_MSGHANDLER);
                EditorGUILayout.PropertyField(propHandler, new GUIContent(propMsg.stringValue));
                EditorGUI.indentLevel--;
            }
            
            this.serializedObject.ApplyModifiedProperties();
        }

        private void _lst_DrawHeader(Rect area)
        {
            EditorGUI.LabelField(area, "Message Handlers");
        }

        private void _lst_DrawElement(Rect area, int index, bool isActive, bool isFocused)
        {
            var el = _messageHandlersList.serializedProperty.GetArrayElementAtIndex(index);
            var propMsg = el.FindPropertyRelative(PROP_MSG);
            EditorGUI.PropertyField(area, propMsg);
        }


        private static bool DrawDefaultInspectorExcept(SerializedObject serializedObject, params string[] propsNotToDraw)
        {
            if (serializedObject == null) throw new System.ArgumentNullException("serializedObject");

            EditorGUI.BeginChangeCheck();
            var iterator = serializedObject.GetIterator();
            for (bool enterChildren = true; iterator.NextVisible(enterChildren); enterChildren = false)
            {

                if (propsNotToDraw == null || !propsNotToDraw.Contains(iterator.name))
                {
                    EditorGUILayout.PropertyField(iterator, true);
                }
            }
            return EditorGUI.EndChangeCheck();
        }


    }

}