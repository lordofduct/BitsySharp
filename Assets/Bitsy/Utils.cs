using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SPBitsy
{

    public static class Sym
    {
        public const string DialogOpen = "\"\"\"";
        public const string DialogClose = "\"\"\"";
        public const string CodeOpen = "{";
        public const string CodeClose = "}";
        public const string LineBreak = "\n";
        public const string Separator = ":";
        public const string List = "-";
        public const string String = "\"";


        public const char cCodeOpen = '{';
        public const char cCodeClose = '}';
        public const char cLineBreak = '\n';
        public const char cSeparator = ':';
        public const char cList = '-';
        public const char cString = '\"';
    }

    public static class Utils
    {

        #region Coerce Callbacks

        public static Action Coerce(System.Action<object> d)
        {
            if (d != null)
                return () => d(null);
            else
                return null;
        }

        public static Action<object> Coerce(System.Action d)
        {
            if (d != null)
                return (o) => d();
            else
                return null;
        }

        #endregion

        #region Array Methods

        public static T[] Empty<T>()
        {
            return TempArray<T>.Empty;
        }

        public static int IndexOfInRow(string[,] arr, int row, string value)
        {
            int len = arr.GetLength(1);
            for (int i = 0; i < len; i++)
            {
                if (string.Equals(arr[row, i], value)) return i;
            }
            return -1;
        }

        public static int IndexOfInCol(string[,] arr, int col, string value)
        {
            int len = arr.GetLength(0);
            for (int i = 0; i < len; i++)
            {
                if (string.Equals(arr[i, col], value)) return i;
            }
            return -1;
        }

        public static void Shuffle<T>(T[] arr, Random rng)
        {
            if (arr == null) throw new System.ArgumentNullException("arr");

            int j;
            T temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                j = rng.Next(i, arr.Length);
                temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }
        }

        #endregion

        #region Numeric Methods

        /// <summary>
        /// Tests if the typeof the value passed in is a numeric type. Handles IWrapper types as well.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool ValueIsNumericType(object obj)
        {

            if (obj == null)
                return false;

            return IsNumericType(obj.GetType());

        }

        /// <summary>
        /// Tests if the type is a numeric type.
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsNumericType(System.Type tp)
        {
            return IsNumericType(System.Type.GetTypeCode(tp));
        }

        public static bool IsNumericType(System.TypeCode code)
        {
            switch (code)
            {
                case System.TypeCode.SByte:
                    //5
                    return true;
                case System.TypeCode.Byte:
                    //6
                    return true;
                case System.TypeCode.Int16:
                    //7
                    return true;
                case System.TypeCode.UInt16:
                    //8
                    return true;
                case System.TypeCode.Int32:
                    //9
                    return true;
                case System.TypeCode.UInt32:
                    //10
                    return true;
                case System.TypeCode.Int64:
                    //11
                    return true;
                case System.TypeCode.UInt64:
                    //12
                    return true;
                case System.TypeCode.Single:
                    //13
                    return true;
                case System.TypeCode.Double:
                    //14
                    return true;
                case System.TypeCode.Decimal:
                    //15

                    return true;
                default:
                    return false;
            }
        }

        #endregion

        #region StringBuilder Methods

        private const int MAX_BUILDERS = 10;
        private static Stack<StringBuilder> _builderPool = new Stack<StringBuilder>(MAX_BUILDERS);

        public static StringBuilder GetTempStringBuilder()
        {
            if (_builderPool.Count > 0)
            {
                return _builderPool.Pop();
            }
            else
            {
                return new StringBuilder();
            }
        }

        public static string Release(StringBuilder builder)
        {
            if (builder == null) return null;

            var result = builder.ToString();
            if (_builderPool.Count < MAX_BUILDERS)
            {
                builder.Length = 0;
                _builderPool.Push(builder);
            }
            return result;
        }

        public static void PurgeStringBuilderPool()
        {
            _builderPool.Clear();
        }

        #endregion


        #region Special Types

        private class TempArray<T>
        {
            public static readonly T[] Empty = new T[0];
        }

        #endregion

    }

    public static class ColorUtil
    {

        public static BitsyGame.Color HexToRGB(string hex)
        {
            hex = Regex.Replace(hex, @"^#?([a-f\d])([a-f\d])([a-f\d])$", (m) =>
            {
                string r = m.Groups[1].Value;
                string g = m.Groups[2].Value;
                string b = m.Groups[3].Value;
                return r + r + g + g + b + b;
            }, RegexOptions.IgnoreCase);

            var match = Regex.Match(hex, @"^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return new BitsyGame.Color(byte.Parse(match.Groups[1].Value, NumberStyles.HexNumber),
                                   byte.Parse(match.Groups[2].Value, NumberStyles.HexNumber),
                                   byte.Parse(match.Groups[3].Value, NumberStyles.HexNumber));
            }
            else
            {
                return new BitsyGame.Color(0, 0, 0);
            }
        }

        public static string RGBToHex(byte r, byte g, byte b)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", r, g, b);
        }

    }

}
