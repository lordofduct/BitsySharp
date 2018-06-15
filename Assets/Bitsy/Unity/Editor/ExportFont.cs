using UnityEngine;
using UnityEditor;
using System.IO;

namespace SPBitsy.Unity.Editor
{

    /// <summary>
    /// Simple util to export the default bitsy font into the newer bitmapped font texture.
    /// </summary>
    public static class ExportFont
    {

        //[MenuItem("Bitsy/ExportFont")]
        public static void DoExportFont()
        {
            var font = BitsyFont.CreateDefault();
            var text = BitsyUnityUtils.DrawFontToTexture(font);
            
            var bytes = text.EncodeToTGA();
            var path = Application.dataPath + "/Bitsy/Unity/DefaultFont.tga";
            if (File.Exists(path)) File.Delete(path);
            File.WriteAllBytes(path, bytes);

        }

    }

}