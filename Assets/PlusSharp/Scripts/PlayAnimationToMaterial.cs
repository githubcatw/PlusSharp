using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NUDev.PlusSharp {
    [RequireComponent(typeof(Material))]

    public class PlayAnimationToMaterial : MonoBehaviour {

        [Tooltip("The animation as a Texture2D array.")]
        public new Texture2D[] animation;

        [Tooltip("How much to wait each frame? Higher is slower.")]
        public float wait;

        [Tooltip("Should the animation be played at start?")]
        public bool playOnStart;

        // Use this for initialization
        void Start() {
            StartCoroutine(Play());
        }

        // Update is called once per frame
        void Update() {

        }

        public IEnumerator Play() {
            // return null so an external script can do other things
            yield return null;
            // get reference to a material
            Material mat = GetComponent<Renderer>().material;
            // play our animation
            for (int i = 0; i < animation.Length; i++) {
                // set texture
                mat.mainTexture = animation[i];
                // loop
                if (i == animation.Length - 1) {
                    i = 0;
                }
                // wait
                yield return new WaitForSeconds(wait);
            }

        }
    }
}