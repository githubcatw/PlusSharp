using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NUDev.PlusSharp.Editor {
    public class MoveGameCameraToEditorCamera : EditorWindow {
        [MenuItem("Window/Move main camera to Scene View camera %m")]
        static void Init() {
            var cam = SceneView.lastActiveSceneView.camera;
            Camera.main.transform.position = cam.transform.position;
            Camera.main.transform.rotation = cam.transform.rotation;
        }
    }
}
