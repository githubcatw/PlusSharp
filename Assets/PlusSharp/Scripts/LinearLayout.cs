using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NUDev.PlusSharp {
    /// <summary>
    /// Make a UI object act similar to a LinearLayout in Android.
    /// </summary>
    public class LinearLayout : MonoBehaviour {

        public ScreenOrientation orientation;
        public bool runTests;
        public float offset;
        public GameObject testObject;

        private Vector2 lastXY = Vector2.zero;

        public LinearLayout(ScreenOrientation orientation) {
            this.orientation = orientation;
        }

        private void Update() {
            if (runTests) {
                runTests = false;
                RunTests();
            }
        }

        public void RunTests() {
            for (int i = 0; i < 10; i++) {
                var o1 = Instantiate(testObject);
                o1.name = $"[TestObject {i+1}]";
                Add(o1);
            }
        }

        /// <summary>
        /// Add a GameObject.
        /// </summary>
        /// <param name="view">The GameObject.</param>
        public void Add(GameObject view) {
            // Change the parent
            view.transform.SetParent(this.transform, false);
            // Get the RectTransform of the view
            var rt = view.GetComponent<RectTransform>();
            var prt = GetComponent<RectTransform>();
            // Initialize a few variables
            float newX = 0, newY = 0;
            // If lastXY is zero, set it to the negative of the view's size
            if (orientation == ScreenOrientation.LandscapeLeft) {
                // If lastXY is zero, set it to the negative of the view's size
                if (lastXY == Vector2.zero) lastXY = -rt.sizeDelta;
                // Update newX
                newX = lastXY.x + offset + rt.sizeDelta.x;
            } else if (orientation == ScreenOrientation.Portrait) {
                // If lastXY is zero, set it to the view's size
                if (lastXY == Vector2.zero) lastXY = rt.sizeDelta;
                // Update newY
                newY = lastXY.y - offset - rt.sizeDelta.y;
            }
            // Error in other orientations
            else
                Debug.LogError("Only LandscapeLeft and Portrait orientations are supported.");
            // Update the view position and lastXY
            rt.anchoredPosition = lastXY = new Vector2(newX, newY);
            if (orientation == ScreenOrientation.LandscapeLeft)
                prt.sizeDelta = new Vector2(lastXY.x, prt.sizeDelta.y);
            else if (orientation == ScreenOrientation.Portrait)
                prt.sizeDelta = new Vector2(prt.sizeDelta.x, -lastXY.y);
            // Reset z
            rt.Translate(0, 0, -rt.position.z);
        }

        /// <summary>
        /// Add an instance of a GameObject.
        /// </summary>
        /// <param name="view">The GameObject.</param>
        public void AddInstance(GameObject view) {
            // Did you think this is some complex magic?
            var i = Instantiate(view);
            Add(i);
        }

        /// <summary>
        /// Clear the layout.
        /// </summary>
        public void Clear() {
            // For each child:
            for (var i = 0; i < transform.childCount; i++) {
                // Destroy it
                Destroy(transform.GetChild(i).gameObject);
            }
            // Reset lastXY
            lastXY = Vector2.zero;
        }
    }
}