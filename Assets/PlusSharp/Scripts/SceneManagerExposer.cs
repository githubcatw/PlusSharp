using UnityEngine;
using UnityEngine.SceneManagement;

namespace NUDev.Generic {
    /// <summary>
    /// Exposes SceneManager as a MonoBehaviour. For buttons.
    /// </summary>
    public class SceneManagerExposer : MonoBehaviour {
        public void LoadScene(string scene) {
            SceneManager.LoadScene(scene);
        }
    }
}