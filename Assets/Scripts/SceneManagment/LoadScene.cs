using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Productivity.SceneManagement
{
    // Loading Data and load the target Scene
    // Displays loading progress by using a slider
    public class LoadScene : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Slider loadingSlider;

        private void Start()
        {
            StartCoroutine(LoadAsynchronusly());
        }

        private IEnumerator LoadAsynchronusly()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(LoadingData.SceneToLoad);
            loadingScreen.SetActive(true);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                loadingSlider.value = progress;
                yield return null;
            }
        }
    }
}