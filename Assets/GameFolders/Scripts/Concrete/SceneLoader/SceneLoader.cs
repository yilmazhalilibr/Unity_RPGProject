using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Unity_RPGProject.Concrete
{
    public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
    {
        [SerializeField] Image _progressBar;
        [SerializeField] Canvas _canvas;

        private void Awake()
        {
            SetSingletonThisGameObject(this);
        }
        public async UniTask SceneLoading(int scene)
        {

            _canvas.gameObject.SetActive(true);
            _progressBar.fillAmount = 0;

            AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(scene);

            while (!loadingOperation.isDone)
            {
                _progressBar.fillAmount = loadingOperation.progress;
                await UniTask.WaitForEndOfFrame(this);
            }

            _canvas.gameObject.SetActive(false);

        }

    }
}

