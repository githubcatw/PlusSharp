using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NUDev.PlusSharp.Editor
{
    public class MoveGameCameraToEditorCamera : EditorWindow
    {
        [MenuItem("Window/Move Game camera to Scene View camera %m")]
        // Use this for initialization
        static void Init()
        {
            var cam = SceneView.lastActiveSceneView.camera;
            Camera.main.transform.position = cam.transform.position;
            Camera.main.transform.rotation = cam.transform.rotation;
            //Capture window = (MoveGameCameraToEditorCamera)EditorWindow.GetWindow(typeof(MoveGameCameraToEditorCamera), true, "Capture Panorama...");
            //window.Show();
        }

        void OnGUI()
        {
            if (GUILayout.Button("Teleport!")) {
                
            }
                

            this.Repaint();
        }

    }
}
