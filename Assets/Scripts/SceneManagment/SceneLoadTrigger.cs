using UnityEngine;
using UnityEngine.SceneManagement;

namespace Productivity.SceneManagement
{
    // Implements a mechanism for loading scenes through an interlayer loading scene
    public class SceneLoadTrigger : MonoBehaviour
    {
        [SerializeField] private string targetScene;

        // Load the LoadScene and set up next scene to load
        public void LoadScene()
        {
            LoadingData.SceneToLoad = targetScene;
            SceneManager.LoadScene(LoadingData.LoadScene);
        }
    }
}
