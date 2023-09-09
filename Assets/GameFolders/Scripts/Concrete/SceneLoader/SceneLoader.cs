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


        private void Awake()
        {
            _progressBar = GetComponentInChildren<Image>();
        }


        public async UniTaskVoid SceneLoading(string sceneName)
        { 
            AsyncOperation loadingOperationLoad = SceneManager.LoadSceneAsync("Loading");
            while (loadingOperationLoad.isDone)
            {
                AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneName);

                while (!loadingOperation.isDone)
                {
                    _progressBar.fillAmount = loadingOperation.progress;
                    await UniTask.WaitForEndOfFrame();
                }
            }


        }



    }
}

