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
        public static GameObject[] GetChildren(this GameObject go) {
            List<GameObject> gos = new List<GameObject>();
            foreach (Transform ch in go.transform) {
                gos.Add(ch.gameObject);
            }
            return gos.ToArray();
        }

        /// <summary>
        /// Find a GameObject even if it's disabled.
        /// </summary>
        /// <param name="name">The name.</param>
        public static GameObject FindWithDisabled(this GameObject go, string name) {
            var temp = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
            var obj = new GameObject();
            foreach (GameObject o in temp) {
                if (o.name == name) {
                    obj = o;
                }
            }
            return obj;
        }

        /// <summary>
        /// Gets the RectTransform of an object. Like GameObject.transform.
        /// </summary>
        public static RectTransform rectTransform(this GameObject go) {
            return go.GetComponent<RectTransform>();
        }
    }
}
