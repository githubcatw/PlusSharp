using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace NUDev.PlusSharp
{
    public static class TextureExtension
    {
        /// <summary>
        /// Saves a texture to PNG.
        /// </summary>
        /// <param name="path">The path to the output PNG.</param>
        public static void SaveToPNG(this Texture2D texture, string path)
        {
            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// Converts a RenderTexture to a Texture2D.
        /// </summary>
        /// <returns>The Texture2D.</returns>
        public static Texture2D ToTexture2D(this RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
            RenderTexture.active = rTex;
            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();
            return tex;
        }
    }
}
