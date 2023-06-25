using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class LoadAsyncManager : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;
        [SerializeField] private string _targetScene = UnityScenes.Level1.ToString();


        private void Start()
        {
            StartCoroutine(LoadAsync());
            
        }
        IEnumerator LoadAsync()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(_targetScene);
            float progress = 0;

            while (!operation.isDone)
            {
                progress = operation.progress;
                _progressBar.fillAmount = progress;

                yield return null;
            }
        }

    }
}