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
        [SerializeField] private Text _text;

        private void Start()
        {
            StartCoroutine(LoadAsync());
            
        }
        IEnumerator LoadAsync()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(_targetScene);
            operation.allowSceneActivation = false;
            while (!operation.isDone)
            {
                _progressBar.fillAmount = operation.progress;
                _text.text = "Loading progress: " + (operation.progress * 100) + "%";
                if (operation.progress >= 0.8)
                {
                    _progressBar.fillAmount = 1;
                    _text.text = "Press the space bar to continue";
                    if (Input.GetKeyDown(KeyCode.Space))
                        operation.allowSceneActivation = true;
                }
                yield return null;
            }

        }

    }
}