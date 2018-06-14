using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SPBitsy
{

    public static class ScriptInterpreter
    {

        #region Interpret Methods

        public static void Compile(Environment env, string scriptName, string script)
        {
            var node = Parse(script);
            env.SetScript(scriptName, node);
        }

        public static void Run(Environment env, string scriptName, System.Action onFinish)
        {
            var node = env.GetScript(scriptName);
            if (node != null)
                node.Eval(env, Utils.Coerce(onFinish));
            else if (onFinish != null)
                onFinish();
        }

        public static void Interpret(Environment env, string script, System.Action onFinish)
        {
            var node = Parse(script);
            node.Eval(env, Utils.Coerce(onFinish));
        }

        #endregion

        #region Parser Methods

        public static Node Parse(string script)
        {
            var state = new ParserState(new BlockNode(BlockMode.Dialog), script);

            if (state.MatchAhead(Sym.DialogOpen))
            {
                var dialog = state.ConsumeBlock(Sym.DialogOpen, Sym.DialogClose);
                state = new ParserState(new BlockNode(BlockMode.Dialog), dialog);
                state = ParseDialog(state);
            }
            // NOTE: This causes problems when you lead with a code block
            //else if (state.MatchAhead(Sym.CodeOpen))
            //{
            //    state = ParseCodeBlock(state);
            //}
            else
            {
                state = ParseDialog(state);
            }

            return state.RootNode;
        }

        private static ParserState ParseDialogBlock(ParserState state)
        {
            string dialog = state.ConsumeBlock(Sym.DialogOpen, Sym.DialogClose);
            var dialogState = new ParserState(new BlockNode(BlockMode.Dialog), dialog);
            dialogState = ParseDialog(dialogState);
            state.CurNode.AddChild(dialogState.RootNode);
            return state;
        }

        private static ParserState ParseDialog(ParserState state)
        {
            bool hasBlock = false;
            bool hasDialog = false;
            bool isFirstLine = true;

            var builder = Utils.GetTempStringBuilder();

            while (!state.Done())
            {
                if (state.MatchAhead(Sym.CodeOpen))
                {
                    if (AddTextNode(builder, state)) hasDialog = true;
                    state = ParseCodeBlock(state);

                    int len = state.CurNode.Children.Count;
                    if (len > 0 && state.CurNode.Children[len - 1] is NodeParent)
                    {
                        var block = state.CurNode.Children[len - 1] as NodeParent;
                        if (block.IsMultilineListBlock())
                            hasDialog = true;
                    }

                    hasBlock = true;
                }
                // NOTE: nested dialog blocks disabled for now
                //else if(state.MatchAhead(Sym.DialogOpen))
                //{
                //    if (AddTextNode(builder, state)) hasDialog = true;
                //    state = ParseDialogBlock(state);
                //    hasBlock = true;
                //}
                else
                {
                    if (state.MatchAhead(Sym.LineBreak))
                    {
                        if (AddTextNode(builder, state)) hasDialog = true;

                        bool isLastLine = (state.Index + 1) == state.Count;
                        bool isEmptyLine = !hasBlock && !hasDialog;
                        bool isValidEmptyLine = isEmptyLine && !(isFirstLine || isLastLine);
                        bool shouldAddLineBreak = (hasDialog || isValidEmptyLine) && !isLastLine; // last clause is a hack (but it works - why?)
                        if (shouldAddLineBreak)
                        {
                            state.CurNode.AddChild(new FuncNode(FUNC_BR));
                        }

                        isFirstLine = false;
                        hasBlock = false;
                        hasDialog = false;

                        builder.Length = 0;
                    }
                    else
                    {
                        builder.Append(state.Char());
                    }

                    state.Step();
                }
            }
            AddTextNode(builder, state);

            return state;
        }

        private static bool AddTextNode(StringBuilder builder, ParserState state)
        {
            if (builder.Length > 0)
            {
                state.CurNode.AddChild(new FuncNode(FUNC_SAY, new LiteralNode(builder.ToString())));
                builder.Length = 0;
                return true;
            }
            return false;
        }

        private static ParserState ParseCodeBlock(ParserState state)
        {
            string code = state.ConsumeBlock(Sym.CodeOpen, Sym.CodeClose);
            var codeState = new ParserState(new BlockNode(BlockMode.Code), code);
            codeState = ParseCode(codeState);
            state.CurNode.AddChild(codeState.RootNode);
            return state;
        }

        private static ParserState ParseCode(ParserState state)
        {
            string name;
            while (!state.Done())
            {
                if (char.IsWhiteSpace(state.Char()))
                {
                    state.Step();
                }
                else if (state.MatchAhead(Sym.CodeOpen))
                {
                    state = ParseCodeBlock(state);
                }
                // NOTE: nested dialog blocks disabled for now
                //else if (state.MatchAhead(Sym.DialogOpen))
                //{
                //    state = ParseDialogBlock(state);
                //}
                else if (state.Char() == Sym.cList && state.Peek("").IndexOf('?') >= 0)
                {
                    state = ParseIf(state);
                }
                else if (HasFunction(name = state.Peek(" ")))
                {
                    state.Step(name.Length);
                    state = ParseFunction(state, name);
                }
                else if (IsSequence(name = state.Peek(" \n")))
                {
                    state.Step(name.Length);
                    state = ParseSequence(state, name);
                }
                else
                {
                    state = ParseExpression(state);
                }
            }
            return state;
        }

        private static ParserState ParseIf(ParserState state)
        {
            List<StringBuilder> conditionStrings = new List<StringBuilder>();
            List<StringBuilder> resultStrings = new List<StringBuilder>();
            var curIndex = -1;
            bool isNewLine = true;
            bool isConditionDone = false;
            int codeBlockCount = 0;

            while (!state.Done())
            {
                if (state.Char() == Sym.cCodeOpen)
                    codeBlockCount++;
                else if (state.Char() == Sym.cCodeClose)
                    codeBlockCount--;

                bool isWhiteSpace = (state.Char() == ' ' || state.Char() == '\t');
                bool isSkippableWhitespace = isNewLine && isWhiteSpace;
                bool isNewListItem = isNewLine && (codeBlockCount <= 0) && state.Char() == Sym.cList;

                if (isNewListItem)
                {
                    curIndex++;
                    isConditionDone = false;
                    conditionStrings.Add(Utils.GetTempStringBuilder());
                    resultStrings.Add(Utils.GetTempStringBuilder());
                }
                else if (curIndex > -1)
                {
                    if (isConditionDone)
                    {
                        if (state.Char() == '?' || state.Char() == '\n')
                        {
                            isConditionDone = true;
                        }
                        else
                        {
                            conditionStrings[curIndex].Append(state.Char());
                        }
                    }
                    else
                    {
                        if (!isSkippableWhitespace)
                            resultStrings[curIndex].Append(state.Char());
                    }
                }

                isNewLine = (state.Char() == Sym.cLineBreak) || isSkippableWhitespace || isNewListItem;

                state.Step();
            }

            var conditions = new Node[conditionStrings.Count];
            for (int i = 0; i < conditionStrings.Count; i++)
            {
                var str = Utils.Release(conditionStrings[i]);
                if (str == "else")
                {
                    conditions[i] = new ElseNode();
                }
                else
                {
                    conditions[i] = CreateExpression(str);
                }
            }

            var results = new Node[resultStrings.Count];
            for (int i = 0; i < resultStrings.Count; i++)
            {
                var str = Utils.Release(resultStrings[i]);
                var dialogState = new ParserState(new BlockNode(BlockMode.Dialog), str);
                dialogState = ParseDialog(dialogState);
                results[i] = dialogState.RootNode;
            }

            state.CurNode.AddChild(new IfNode(conditions, results, false));

            return state;
        }

        private static ParserState ParseFunction(ParserState state, string funcName)
        {
            var builder = Utils.GetTempStringBuilder();
            var args = new List<Node>();

            while (!(state.Char() == '\n' || state.Done()))
            {
                if (state.MatchAhead(Sym.CodeOpen))
                {
                    var codeState = new ParserState(new BlockNode(BlockMode.Code), state.ConsumeBlock(Sym.CodeOpen, Sym.CodeClose));
                    codeState = ParseCode(codeState);
                    args.Add(codeState.RootNode);
                    builder.Length = 0;
                }
                else if (state.MatchAhead(Sym.String))
                {
                    var str = state.ConsumeBlock(Sym.String, Sym.String);
                    args.Add(new LiteralNode(str));
                    builder.Length = 0;
                }
                else if (state.Char() == ' ' && builder.Length > 0)
                {
                    args.Add(StringToValueNode(builder.ToString().Trim()));
                    builder.Length = 0;
                }
                else
                {
                    builder.Append(state.Char());
                }
                state.Step();
            }

            if (builder.Length > 0)
            {
                args.Add(StringToValueNode(builder.ToString().Trim()));
                builder.Length = 0;
            }
            Utils.Release(builder);

            state.CurNode.AddChild(new FuncNode(funcName, args.ToArray()));
            return state;
        }

        private static bool IsSequence(string str)
        {
            return str == "sequence" || str == "cycle" || str == "shuffle";
        }

        private static ParserState ParseSequence(ParserState state, string sequenceType)
        {
            bool isNewLine = false;
            List<StringBuilder> itemStrings = new List<StringBuilder>();
            int curItemIndex = -1; //-1 indicates not reading an item yet
            int codeBlockCount = 0;

            while (!state.Done())
            {
                if (state.Char() == Sym.cCodeOpen)
                    codeBlockCount++;
                else if (state.Char() == Sym.cCodeClose)
                    codeBlockCount--;

                bool isWhiteSpace = (state.Char() == ' ' || state.Char() == '\t');
                bool isSkippableWhitespace = isNewLine && isWhiteSpace;
                bool isNewListItem = isNewLine && (codeBlockCount <= 0) && state.Char() == Sym.cList;

                if (isNewListItem)
                {
                    curItemIndex++;
                    itemStrings.Add(Utils.GetTempStringBuilder());
                }
                else if (curItemIndex > -1)
                {
                    if (!isSkippableWhitespace)
                        itemStrings[curItemIndex].Append(state.Char());
                }

                isNewLine = state.Char() == Sym.cLineBreak || isSkippableWhitespace || isNewListItem;

                state.Step();
            }

            var options = new Node[itemStrings.Count];
            for (int i = 0; i < itemStrings.Count; i++)
            {
                var str = Utils.Release(itemStrings[i]);
                var dialogState = new ParserState(new BlockNode(BlockMode.Dialog, false), str);
                dialogState = ParseDialog(dialogState);
                options[i] = dialogState.RootNode;
            }

            switch (sequenceType)
            {
                case "sequence":
                    state.CurNode.AddChild(new SequenceNode(options));
                    break;
                case "cycle":
                    state.CurNode.AddChild(new CycleNode(options));
                    break;
                case "shuffle":
                    state.CurNode.AddChild(new ShuffleNode(options));
                    break;
            }

            return state;
        }

        private static ParserState ParseExpression(ParserState state)
        {
            string line = state.Peek(Sym.LineBreak);
            var exp = CreateExpression(line);
            state.CurNode.AddChild(exp);
            state.Step(line.Length);
            return state;
        }

        private static Node CreateExpression(string line)
        {
            const char SYM_SET = '=';
            const char SYM_IF = '?';
            const char SYM_ELSE = ':';
            line = line.Trim();

            string op = null;
            int index;
            index = line.IndexOf(SYM_SET);
            if (index >= 0 && !IsInsideString(line, index) && !IsInsideCode(line, index))
            {
                if (index == 0) return new LiteralNode(null); //uh-oh - the line started with =

                if (line[index + 1] != SYM_SET && line[index - 1] != '>' && line[index - 1] != '<')
                {
                    op = OP_EQUAL;
                    var varName = line.Substring(0, index).Trim();
                    var left = IsValidVariableName(varName) ? (Node)(new VariableNode(varName)) : (Node)(new LiteralNode(null));
                    var right = CreateExpression(line.Substring(index + 1));
                    var exp = new ExpNode(op, left, right);
                    return exp;
                }
            }

            index = line.IndexOf(SYM_IF);
            if (index >= 0 && !IsInsideString(line, index) && !IsInsideCode(line, index))
            {
                op = "?";
                var conditionStr = line.Substring(0, index).Trim();
                var conditions = new List<Node>();
                conditions.Add(CreateExpression(conditionStr));

                var resultStr = line.Substring(index + 1);
                var results = new List<Node>();

                index = resultStr.IndexOf(SYM_ELSE);
                if (index >= 0)
                {
                    conditions.Add(new ElseNode());

                    var elseStr = resultStr.Substring(index + 1);
                    resultStr = resultStr.Substring(0, index);
                    AddExpressionResult(results, resultStr.Trim());
                    AddExpressionResult(results, elseStr.Trim());
                }
                else
                {
                    AddExpressionResult(results, resultStr.Trim());
                }

                return new IfNode(conditions.ToArray(), results.ToArray(), true);
            }

            for (int i = 0; (op == null && i < OP_SYMBOLS.Length); i++)
            {
                index = line.IndexOf(OP_SYMBOLS[i]);
                if (index >= 0 && !IsInsideString(line, index) && !IsInsideCode(line, index))
                {
                    op = OP_SYMBOLS[i];
                    var left = CreateExpression(line.Substring(0, index));
                    var right = CreateExpression(line.Substring(index + op.Length));
                    return new ExpNode(op, left, right);
                }
            }

            if (op == null)
                return StringToValueNode(line);

            return null; //uh-oh
        }

        private static bool IsInsideString(string line, int index)
        {
            bool result = false;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == Sym.cString)
                    result = !result;
                if (index == i)
                    return result;
            }
            return false;
        }

        private static bool IsInsideCode(string line, int index)
        {
            int cnt = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == Sym.cCodeOpen)
                    cnt++;
                else if (line[i] == Sym.cCodeClose)
                    cnt--;
                if (index == i)
                    return cnt > 0;
            }
            return false;
        }

        private static void AddExpressionResult(List<Node> lst, string code)
        {
            var dialogState = new ParserState(new BlockNode(BlockMode.Dialog), code);
            dialogState = ParseDialog(dialogState);
            lst.Add(dialogState.RootNode);
        }

        private static Node StringToValueNode(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                float fval;
                if (val[0] == Sym.cCodeOpen)
                {
                    var code = (new ParserState(null, val)).ConsumeBlock(Sym.CodeOpen, Sym.CodeClose); //hacky
                    var codeState = new ParserState(new BlockNode(BlockMode.Code), code);
                    codeState = ParseCode(codeState);
                    return codeState.RootNode;
                }
                else if (val[0] == Sym.cString)
                {
                    var builder = Utils.GetTempStringBuilder();
                    int i = 1;
                    while (i < val.Length && val[i] != Sym.cString)
                    {
                        builder.Append(val[i]);
                        i++;
                    }
                    return new LiteralNode(Utils.Release(builder));
                }
                else if (val == "true")
                {
                    return new LiteralNode(true);
                }
                else if (val == "false")
                {
                    return new LiteralNode(false);
                }
                else if (float.TryParse(val, out fval))
                {
                    return new LiteralNode(fval);
                }
                else if (IsValidVariableName(val))
                {
                    return new VariableNode(val);
                }
            }

            // uh oh
            return new LiteralNode(null);
        }

        private static bool IsValidVariableName(string str)
        {
            const string rx = @"^[a-zA-Z_$][a-zA-Z_$0-9]*$";
            return Regex.IsMatch(str, rx);
        }

        #endregion

        #region Eval Function

        public const string FUNC_SAY = "say";
        public const string FUNC_BR = "br";
        public const string FUNC_ITEM = "item";
        public const string FUNC_RBW = "rbw";
        public const string FUNC_CLR1 = "clr1";
        public const string FUNC_CLR2 = "clr2";
        public const string FUNC_CLR3 = "clr3";
        public const string FUNC_WVY = "wvy";
        public const string FUNC_SHK = "shk";

        public static bool HasFunction(string name)
        {
            switch (name)
            {
                case FUNC_SAY:
                case FUNC_BR:
                case FUNC_ITEM:
                case FUNC_RBW:
                case FUNC_CLR1:
                case FUNC_CLR2:
                case FUNC_CLR3:
                case FUNC_WVY:
                case FUNC_SHK:
                    return true;
                default:
                    return false;
            }
        }

        public static void EvalFunction(Environment env, string name, object[] args, System.Action<object> onReturn)
        {
            switch (name)
            {
                case FUNC_SAY:
                    env.DialogBuffer.AddText(args != null && args.Length > 0 ? Convert.ToString(args[0]) : string.Empty, Utils.Coerce(onReturn));
                    break;
                case FUNC_BR:
                    env.DialogBuffer.AddLinebreak();
                    if (onReturn != null) onReturn(null);
                    break;
                case FUNC_ITEM:
                    if (onReturn != null)
                    {
                        string itemId = args != null && args.Length > 0 ? Convert.ToString(args[0]) : string.Empty;
                        if (env.Names.items.ContainsKey(itemId)) itemId = env.Names.items[itemId]; //id is actually a name
                        var pl = env.GetPlayer();
                        float cnt;
                        if (pl == null || !pl.Inventory.TryGetValue(itemId, out cnt))
                            cnt = 0f;
                        onReturn(cnt);
                    }
                    break;
                case FUNC_RBW:
                case FUNC_CLR1:
                case FUNC_CLR2:
                case FUNC_CLR3:
                case FUNC_WVY:
                case FUNC_SHK:
                    {
                        if (env.DialogBuffer.HasTextEffect(name))
                            env.DialogBuffer.RemoveTextEffect(name);
                        else
                            env.DialogBuffer.AddTextEffect(name, TextEffects.CreateEffectCallback(name));
                        if (onReturn != null) onReturn(null);
                    }
                    break;
            }
        }

        #endregion

        #region Eval Operators

        public const string OP_SET = "=";
        public const string OP_EQUAL = "==";
        public const string OP_GT = ">";
        public const string OP_LT = "<";
        public const string OP_GTE = ">=";
        public const string OP_LTE = "<=";
        public const string OP_MULT = "*";
        public const string OP_DIV = "/";
        public const string OP_ADD = "+";
        public const string OP_SUB = "-";
        private readonly static string[] OP_SYMBOLS = new string[] { OP_SUB, OP_ADD, OP_DIV, OP_MULT, OP_LTE, OP_GTE, OP_LT, OP_GT, OP_EQUAL }; //used for expression parsing

        public static bool HasOperator(string op)
        {
            switch (op)
            {
                case OP_SET:
                case OP_EQUAL:
                case OP_GT:
                case OP_LT:
                case OP_GTE:
                case OP_LTE:
                case OP_MULT:
                case OP_DIV:
                case OP_ADD:
                case OP_SUB:
                    return true;
                default:
                    return false;
            }
        }

        public static void EvalOperator(Environment env, string op, Node left, Node right, Action<object> onReturn)
        {
            if (op == OP_SET)
            {
                var varnode = left as VariableNode;
                if (varnode == null || right == null)
                {
                    // not a variable! return null and hope for the best
                    if (onReturn != null) onReturn(null);
                    return;
                }

                if (right is IQuickEvalNode)
                {
                    env.SetVariable(varnode.VarName, (right as IQuickEvalNode).EvalNow(env));
                    if (onReturn != null) onReturn(varnode.EvalNow(env));
                }
                else
                {
                    right.Eval(env, (rVal) =>
                    {
                        env.SetVariable(varnode.VarName, rVal);
                        if (onReturn != null) onReturn(varnode.EvalNow(env));
                    });
                }
            }
            else
            {
                right.Eval(env, (rVal) =>
                {
                    left.Eval(env, (lVal) =>
                    {
                        if (onReturn != null)
                        {
                            try
                            {
                                switch (op)
                                {
                                    case OP_EQUAL:
                                        if (Utils.ValueIsNumericType(lVal))
                                            onReturn(Math.Abs(Convert.ToDouble(lVal) - Convert.ToDouble(rVal)) < 0.0001d); //fuzzy equal
                                        else
                                            onReturn(object.Equals(lVal, rVal));
                                        break;
                                    case OP_GT:
                                        onReturn(Convert.ToDouble(lVal) > Convert.ToDouble(rVal));
                                        break;
                                    case OP_LT:
                                        onReturn(Convert.ToDouble(lVal) < Convert.ToDouble(rVal));
                                        break;
                                    case OP_GTE:
                                        onReturn(Convert.ToDouble(lVal) >= Convert.ToDouble(rVal));
                                        break;
                                    case OP_LTE:
                                        onReturn(Convert.ToDouble(lVal) <= Convert.ToDouble(rVal));
                                        break;
                                    case OP_MULT:
                                        onReturn(Convert.ToDouble(lVal) * Convert.ToDouble(rVal));
                                        break;
                                    case OP_DIV:
                                        onReturn(Convert.ToDouble(lVal) / Convert.ToDouble(rVal));
                                        break;
                                    case OP_ADD:
                                        onReturn(Convert.ToDouble(lVal) + Convert.ToDouble(rVal));
                                        break;
                                    case OP_SUB:
                                        onReturn(Convert.ToDouble(lVal) - Convert.ToDouble(rVal));
                                        break;
                                    default:
                                        onReturn(null);
                                        break;
                                }
                            }
                            catch (System.Exception)
                            {
                                onReturn(null);
                            }
                        }
                    });
                });
            }
        }

        #endregion

        #region Special Types

        private class ParserState
        {

            #region Fields

            public NodeParent RootNode;
            public NodeParent CurNode;

            private string _source;
            private int _index;

            #endregion

            #region CONSTRUCTOR

            public ParserState(NodeParent root, string script)
            {
                this.RootNode = root;
                this.CurNode = root;
                _source = script;
                _index = 0;
            }

            #endregion

            #region Properties

            public int Index
            {
                get { return _index; }
            }

            public int Count
            {
                get { return _source.Length; }
            }

            #endregion

            #region Methods

            public bool MatchAhead(string sym)
            {
                for (int i = 0; i < sym.Length; i++)
                {
                    if (_index + i >= _source.Length)
                        return false;
                    else if (sym[i] != _source[_index + i])
                        return false;
                }
                return true;
            }

            public string Peek(string end)
            {
                var builder = Utils.GetTempStringBuilder();
                int i = _index;
                while (i < _source.Length && (end == null || end.IndexOf(_source[i]) == -1))
                {
                    builder.Append(_source[i]);
                    i++;
                }
                return Utils.Release(builder);
            }

            public string ConsumeBlock(string open, string close)
            {
                int startIndex = _index;

                int matchCount = 0;
                if (this.MatchAhead(open))
                {
                    matchCount++;
                    this.Step(open.Length);
                }

                while (matchCount > 0 && !this.Done())
                {
                    if (this.MatchAhead(close))
                    {
                        matchCount--;
                        this.Step(close.Length);
                    }
                    else if (this.MatchAhead(open))
                    {
                        matchCount++;
                        this.Step(open.Length);
                    }
                    else
                    {
                        this.Step();
                    }
                }

                startIndex += open.Length;
                return _source.Substring(startIndex, _index - close.Length - startIndex);
            }

            public void Step(int n = 1)
            {
                _index += n;
            }

            public bool Done()
            {
                return _index >= _source.Length;
            }

            public char Char()
            {
                return (_index >= 0 && _index < _source.Length) ? _source[_index] : default(char);
            }

            #endregion

        }

        public enum BlockType
        {
            Block,
            Function,
            Literal,
            Variable,
            Operator,
            Sequence,
            Cycle,
            Shuffle,
            If,
            Else
        }

        public enum BlockMode
        {
            Code,
            Dialog
        }

        public abstract class Node
        {
            public readonly BlockType type;
            public NodeParent Parent;
            public System.Action OnEnter;
            public System.Action OnExit;

            public Node(BlockType tp)
            {
                this.type = tp;
            }

            public abstract void Eval(Environment env, Action<object> onReturn);

            public virtual void Visit(Node visitor)
            {
                //?
            }
            public virtual void VisitAll(Node visitor)
            {
                //?
            }

            public virtual bool IsMultilineListBlock()
            {
                return false;
            }

        }

        public abstract class NodeParent : Node
        {
            public readonly List<Node> Children = new List<Node>();

            public NodeParent(BlockType tp) : base(tp)
            {

            }

            public void AddChild(Node node)
            {
                this.Children.Add(node);
                node.Parent = this;
            }

            public override void VisitAll(Node visitor)
            {
                visitor.Visit(this);
                for (int i = 0; i < this.Children.Count; i++)
                {
                    this.Children[i].VisitAll(visitor);
                }
            }

            public override bool IsMultilineListBlock()
            {
                return this.type == BlockType.Block && this.Children.Count > 0 &&
                       (this.Children[0].type == BlockType.Sequence || this.Children[0].type == BlockType.Cycle || this.Children[0].type == BlockType.Shuffle || this.Children[0].type == BlockType.If);
            }

        }

        /// <summary>
        /// Represents a node whose Eval method can be returned immediately. 
        /// Using this can save on performance for simple nodes like LiteralNode.
        /// 
        /// NOTE - due to the 'callback' nature of how Bitsy works, it generates a lot of garbage and piles on the stack hard. 
        /// This can effect performance in version of .net/mono that are older and have a poor GC (such as that found in Unity). 
        /// This is a hack fix to get better performance, though really the entire interpreter should probably be rewritten to match 
        /// a C# sensibility rather than the JS one.
        /// </summary>
        public interface IQuickEvalNode
        {
            object EvalNow(Environment env);
        }

        public class BlockNode : NodeParent
        {
            public BlockMode Mode;

            public BlockNode(BlockMode mode, bool doIndentFirstLine = true) : base(BlockType.Block)
            {
                //'doIndentFirstLine' exists because technically all nodes should implement 'Serialize'. I do not include this right now, but leaving this as residue that it exists
                this.Mode = mode;
            }

            public override void Eval(Environment env, Action<object> onReturn)
            {
                if (this.OnEnter != null) this.OnEnter();

                object result = null;
                int i = 0;
                System.Action<Action> evalChildren = null;
                evalChildren = (Action done) =>
                {
                    Loop:
                    if (i < this.Children.Count)
                    {
                        if (this.Children[i] is IQuickEvalNode)
                        {
                            result = (this.Children[i] as IQuickEvalNode).EvalNow(env);
                            i++;
                            goto Loop;
                        }
                        else
                        {
                            this.Children[i].Eval(env, (o) =>
                            {
                                result = o;
                                i++;
                                evalChildren(done);
                            });
                        }
                    }
                    else
                    {
                        done();
                    }
                };
                evalChildren(() =>
                {
                    if (this.OnExit != null) this.OnExit();
                    if (onReturn != null) onReturn(result);
                });
            }
        }

        public class FuncNode : Node
        {

            public string FuncName;
            public Node[] Arguments;

            public FuncNode(string name) : base(BlockType.Function)
            {
                this.FuncName = name;
                this.Arguments = null;
            }

            public FuncNode(string name, params Node[] args) : base(BlockType.Function)
            {
                this.FuncName = name;
                this.Arguments = args;
            }

            public override void Eval(Environment env, Action<object> onReturn)
            {
                if (this.OnEnter != null) this.OnEnter();

                object[] args = null;
                if (Arguments != null && Arguments.Length > 0)
                {
                    args = new object[Arguments.Length];
                    int i = 0;

                    Action<Action> evalArgs = null;
                    evalArgs = (done) =>
                    {
                        Loop:
                        if (i < this.Arguments.Length)
                        {
                            if (this.Arguments[i] is IQuickEvalNode)
                            {
                                args[i] = (this.Arguments[i] as IQuickEvalNode).EvalNow(env);
                                i++;
                                goto Loop;
                            }
                            else
                            {
                                this.Arguments[i].Eval(env, (o) =>
                                {
                                    args[i] = o;
                                    i++;
                                    evalArgs(done);
                                });
                            }
                        }
                        else
                        {
                            done();
                        }
                    };
                    evalArgs(() =>
                    {
                        if (this.OnExit != null) this.OnExit();
                        ScriptInterpreter.EvalFunction(env, this.FuncName, args, onReturn);
                    });
                }
                else
                {
                    if (this.OnExit != null) this.OnExit();
                    ScriptInterpreter.EvalFunction(env, this.FuncName, args, onReturn);
                }
            }

        }

        public class LiteralNode : Node, IQuickEvalNode
        {

            public object Value;

            public LiteralNode(object val) : base(BlockType.Literal)
            {
                this.Value = val;
            }

            public override void Eval(Environment env, Action<object> onReturn)
            {
                if (onReturn != null) onReturn(this.Value);
            }

            public object EvalNow(Environment env)
            {
                return this.Value;
            }

        }

        public class VariableNode : Node, IQuickEvalNode
        {

            public string VarName;

            public VariableNode(string name) : base(BlockType.Variable)
            {
                this.VarName = name;
            }

            public override void Eval(Environment env, Action<object> onReturn)
            {
                if (onReturn != null) onReturn(env.GetVariable(this.VarName));
            }

            public object EvalNow(Environment env)
            {
                return env.GetVariable(this.VarName);
            }

        }

        public class ExpNode : Node
        {

            public string Operator;
            public Node Left;
            public Node Right;

            public ExpNode(string op, Node left, Node right) : base(BlockType.Operator)
            {
                this.Operator = op;
                this.Left = left;
                this.Right = right;
            }

            public override void Eval(Environment env, Action<object> onReturn)
            {
                ScriptInterpreter.EvalOperator(env, this.Operator, this.Left, this.Right, onReturn);
            }

            public override void VisitAll(Node visitor)
            {
                visitor.Visit(this);
                if (this.Left != null)
                    this.Left.VisitAll(visitor);
                if (this.Right != null)
                    this.Right.VisitAll(visitor);
            }

        }



        public abstract class SequenceBase : Node
        {
            public Node[] Options;

            public SequenceBase(BlockType tp, Node[] options) : base(tp)
            {
                this.Options = options;
            }

            public override void VisitAll(Node visitor)
            {
                visitor.Visit(this);
                if (this.Options != null && this.Options.Length > 0)
                {
                    for (int i = 0; i < this.Options.Length; i++)
                    {
                        this.Options[i].VisitAll(visitor);
                    }
                }
            }

        }

        public class SequenceNode : SequenceBase
        {

            public SequenceNode(Node[] options) : base(BlockType.Sequence, options)
            {

            }

            private int _index = 0;
            public override void Eval(Environment env, Action<object> onReturn)
            {
                int len = this.Options != null ? this.Options.Length : 0;
                if (this.Options != null && _index < len)
                    this.Options[_index].Eval(env, onReturn);

                int next = _index + 1;
                if (next < len)
                    _index = next;
            }

        }

        public class CycleNode : SequenceBase
        {

            public CycleNode(Node[] options) : base(BlockType.Cycle, options)
            {

            }

            private int _index = 0;
            public override void Eval(Environment env, Action<object> onReturn)
            {
                int len = this.Options != null ? this.Options.Length : 0;
                if (this.Options != null && _index < len)
                    this.Options[_index].Eval(env, onReturn);

                _index = (_index + 1) % len;
            }

        }

        public class ShuffleNode : SequenceBase
        {

            private Node[] _shuffledOptions;
            private int _index;

            public ShuffleNode(Node[] options) : base(BlockType.Shuffle, options)
            {
            }

            public override void Eval(Environment env, Action<object> onReturn)
            {
                if (this.Options == null) return;

                if (_shuffledOptions == null)
                {
                    _shuffledOptions = new Node[this.Options.Length];
                    Array.Copy(this.Options, _shuffledOptions, this.Options.Length);
                    Utils.Shuffle(_shuffledOptions, env.Rng);
                }

                if (_index < _shuffledOptions.Length) _shuffledOptions[_index].Eval(env, onReturn);

                _index++;
                if (_index >= _shuffledOptions.Length)
                {
                    Utils.Shuffle(_shuffledOptions, env.Rng);
                    _index = 0;
                }
            }

        }

        public class IfNode : Node
        {

            private Node[] _conditions;
            private Node[] _results;
            public readonly bool IsSingleLine;

            public IfNode(Node[] conditions, Node[] results, bool isSingleLine = false) : base(BlockType.If)
            {
                _conditions = conditions;
                _results = results;
                this.IsSingleLine = isSingleLine;
            }

            public override void Eval(Environment env, Action<object> onReturn)
            {
                int i = 0;
                Action testCondition = null;
                testCondition = () =>
                {
                    _conditions[i].Eval(env, (o) =>
                    {
                        if (o is bool && (bool)o)
                        {
                            _results[i].Eval(env, onReturn);
                        }
                        else if (i + 1 < _conditions.Length)
                        {
                            i++;
                            testCondition();
                        }
                        else
                        {
                            if (onReturn != null) onReturn(null);
                        }
                    });
                };
                testCondition();
            }

            public override void VisitAll(Node visitor)
            {
                visitor.Visit(this);
                for (int i = 0; i < _conditions.Length; i++)
                {
                    _conditions[i].VisitAll(visitor);
                }
                for (int i = 0; i < _results.Length; i++)
                {
                    _results[i].VisitAll(visitor);
                }
            }

        }

        public class ElseNode : Node, IQuickEvalNode
        {

            public ElseNode() : base(BlockType.Else)
            {

            }

            public override void Eval(Environment env, Action<object> onReturn)
            {
                if (onReturn != null) onReturn(true);
            }

            public object EvalNow(Environment env)
            {
                return true;
            }

        }

        #endregion

    }

}
