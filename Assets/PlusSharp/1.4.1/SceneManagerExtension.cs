using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NUDev.PlusSharp.v141
{
    public static class SceneManagerExtension
    {
        public static Scene[] GetAllLoadedScenes(this SceneManager sc)
        {
            List<Scene> scenes = new List<Scene>();
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                scenes.Add(SceneManager.GetSceneAt(i));
            }
            return scenes.ToArray();
        }
    }
}
