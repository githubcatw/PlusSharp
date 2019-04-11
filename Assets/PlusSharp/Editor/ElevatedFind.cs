using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace NUDev.PlusSharp.Editor
{
    public class ElevatedFind : EditorWindow
    {
        private string guid;
        private string instID;

        [MenuItem("GameObject/Find %&f")]
        // Use this for initialization
        static void Init()
        {
            ElevatedFind window = (ElevatedFind)EditorWindow.GetWindow(typeof(ElevatedFind), true, "Find");
            window.Show();
        }

        void OnGUI()
        {
            guid = EditorGUILayout.TextField("GUID: ", guid);
            instID = EditorGUILayout.TextField("Instance ID: ", instID);
            if (GUILayout.Button("Find"))
            {
                if (guid != "")
                {
                    var aPath = AssetDatabase.GUIDToAssetPath(guid);
                    var asset = AssetDatabase.LoadAssetAtPath<Object>(aPath);
                    EditorGUIUtility.PingObject(asset);
                }
                else if (instID != "")
                {
                    var asset = EditorUtility.InstanceIDToObject(int.Parse(instID));
                    EditorGUIUtility.PingObject(asset);
                }

            }
            this.Repaint();
        }
    }
}
