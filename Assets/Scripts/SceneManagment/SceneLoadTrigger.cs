using UnityEngine;
using UnityEngine.SceneManagement;

namespace Productivity.SceneManagement
{
    public class SceneLoadTrigger : MonoBehaviour
    {
        [SerializeField] private string targetScene;

        public void LoadScene()
        {
            LoadingData.SceneToLoad = targetScene;
            SceneManager.LoadScene(LoadingData.LoadScene);
        }
    }
}
