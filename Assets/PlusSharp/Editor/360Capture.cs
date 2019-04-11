using UnityEngine;
using UnityEditor;
using System.IO;

namespace NUDev.PlusSharp.Editor
{
    public class Capture : EditorWindow
    {
        private string filePath;
        private int sqr;
        private bool paraError;
        GameObject zobj;
        bool rotToggle = false;
        bool flipStereo = false;
        [MenuItem("Window/XR/Capture Panorama %&c")]
        // Use this for initialization
        static void Init()
        {
            Capture window = (Capture)EditorWindow.GetWindow(typeof(Capture), true, "Capture Panorama...");
            window.Show();
        }

        void OnGUI()
        {
            filePath = EditorGUILayout.TextField("Path: ", filePath);
            sqr = EditorGUILayout.IntField("Resolution: ", sqr);
            if (sqr % 2 == 1)
            {
                sqr = sqr + 1;
            }

            flipStereo = EditorGUILayout.Toggle("Flip left and right", flipStereo);
            EditorGUILayout.LabelField("(tick this if depth is broken or weird)");
            EditorGUILayout.LabelField("");
            EditorGUILayout.LabelField("Please select the camera you want to capture from.");
            zobj = Selection.activeGameObject;
            if (zobj != null)
            {
                if (zobj.GetComponent<Camera>() == null)
                {
                    if (zobj.name.Contains("mayonnaise"))
                    {
                        EditorGUILayout.LabelField("No Patrick, " + zobj.name + " is not a camera.");
                    }
                    else
                    {
                        EditorGUILayout.LabelField(zobj.name + " is not a camera.");
                    }
                }
                else
                {
                    /*if (filePath == "" || sqr == 0)
                        paraError = true;
                    else if (filePath == "" && sqr == 0)
                        paraError = true;
                    else
                        paraError = false;*/
                    EditorGUILayout.LabelField("Press Capture to capture from " + zobj.name + ".");
                    if (GUILayout.Button("Capture"))
                    {
                        Camera camera = zobj.GetComponent<Camera>();
                        RenderTexture left = new RenderTexture(sqr, sqr, 24);
                        RenderTexture right = new RenderTexture(sqr, sqr, 24);
                        RenderTexture equirect = new RenderTexture(sqr, sqr, 24);
                        left.dimension = UnityEngine.Rendering.TextureDimension.Cube;
                        right.dimension = UnityEngine.Rendering.TextureDimension.Cube;
                        camera.stereoSeparation = 0.064f; // Eye separation (IPD) of 64mm.
                        camera.RenderToCubemap(left, 63, Camera.MonoOrStereoscopicEye.Left);
                        camera.RenderToCubemap(right, 63, Camera.MonoOrStereoscopicEye.Right);
                        if (flipStereo)
                        {
                            right.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Left);
                            left.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Right);
                        }
                        else
                        {
                            left.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Left);
                            right.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Right);
                        }
                        DumpRenderTexture(equirect, filePath);
                    }
                }
            }

            this.Repaint();
        }

        public static void DumpRenderTexture(RenderTexture rt, string pngOutPath)
        {
            var oldRT = RenderTexture.active;

            var tex = new Texture2D(rt.width, rt.height);
            RenderTexture.active = rt;
            tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            tex.Apply();

            File.WriteAllBytes(pngOutPath, tex.EncodeToPNG());
            RenderTexture.active = oldRT;
        }

    }
}