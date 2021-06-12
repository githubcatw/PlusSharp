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

        private bool shouldPlay = true;
        private bool shouldStop;

        // Use this for initialization
        void Start() {
            if (playOnStart) Play();
        }

        /// <summary>
        /// Pause the video.
        /// </summary>
        public void Pause() { shouldPlay = false; }

        /// <summary>
        /// Resume the video.
        /// </summary>
        public void Resume() {
            if (shouldStop == true) shouldStop = false;
            shouldPlay = true;
        }

        /// <summary>
        /// Play the video.
        /// </summary>
        public void Play() {
            if (shouldStop == true) shouldStop = false;
            shouldPlay = true;
            StartCoroutine(PlayAsync());
        }

        /// <summary>
        /// Stop the video.
        /// </summary>
        public void Stop() { shouldStop = true; }

        public IEnumerator PlayAsync() {
            // get reference to a material
            Material mat = GetComponent<Renderer>().material;
            // play our animation
            for (int i = 0; i < animation.Length; i++) {
                // If shouldStop is true, break
                if (shouldStop == true) yield break;
                // Wait for shouldPlay to be true
                yield return new WaitUntil(() => shouldPlay = true);
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