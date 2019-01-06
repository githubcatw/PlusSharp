using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NUDev.PlusSharp
{
    public static class GameObjectExtension
    {
        /// <summary>
        /// Get all children of this GameObject.
        /// </summary>
        /// <returns>All children of this GameObject</returns>
        public static GameObject[] GetChildren(this GameObject go)
        {
            List<GameObject> gos = new List<GameObject>();
            foreach (Transform ch in go.transform)
            {
                gos.Add(ch.gameObject);
            }
            return gos.ToArray();
        }
    }
}
