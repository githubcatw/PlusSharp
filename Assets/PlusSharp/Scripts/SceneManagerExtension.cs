using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NUDev.PlusSharp
{
    public static class SceneManagerExtension
    {
        /// <summary>
        /// Gets all loaded scenes.
        /// </summary>
        /// <returns>All loaded scenes.</returns>
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
