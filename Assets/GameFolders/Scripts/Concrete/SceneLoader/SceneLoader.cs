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

        public int SavedLevelIndex { get { return _savedLevelIndex; } set { _savedLevelIndex = value; } }

        private int _savedLevelIndex = 1;
        private void Awake()
        {
            SetSingletonThisGameObject(this);
        }
        private void Start()
        {
            var index = SavedLevelIndex == 0 ? 1 : SavedLevelIndex;
            _ = SceneLoading(index);
        }
        public async UniTask SceneLoading(int scene = 1)
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

