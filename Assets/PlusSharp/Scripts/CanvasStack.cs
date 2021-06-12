using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NUDev.PlusSharp {

    /// <summary>
    /// A canvas stack, used for managing multiple canvases.
    /// </summary>
    public class CanvasStack : MonoBehaviour {
        /// <summary>
        /// Array of canvases belonging to this stack.
        /// </summary>
        public GameObject[] canvases;

        [HideInInspector] public int currentIndex;

        /// <summary>
        /// Set a canvas active.
        /// </summary>
        /// <param name="index">The index of the canvas in the canvases array.</param>
        public void SetActive(int index) { currentIndex = index; SetActiveOnly(canvases[index]); }

        void SetActiveOnly(GameObject go) {
            if (!canvases.Contains(go)) throw new ArgumentException(
                    $"GameObject \"{go.name}\" isn't in this stack. Suggestions:\n" +
                    $"- Check if you're calling the right stack. This one is on GameObject {gameObject.name}.\n" +
                    $"- Check if you're activating the right object.\n" +
                    $"- Add \"{go.name}\" to this stack. This stack contains {canvases.Length} canvases.");
            foreach (var canvas in canvases) {
                canvas.SetActive(false);
            }
            go.SetActive(true);
        }
    }
}