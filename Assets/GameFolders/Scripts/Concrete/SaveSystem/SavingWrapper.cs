using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Concrete.Controllers;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.Helpers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Unity_RPGProject.Concrete
{
    public class SavingWrapper : SingletonMonoBehaviour<SavingWrapper>
    {
        const string defaultSaveFile = "save";
        PlayerController _player;
        private void Awake()
        {
            SetSingletonThisGameObject(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                _ = LoadLastScene();
            }
        }
        public async UniTaskVoid LoadLastScene()
        {
            await SavingSystem.Instance.LoadLastSceneSave(defaultSaveFile);
            await SceneLoader.Instance.SceneLoading(SceneLoader.Instance.SavedLevelIndex);
        }
        public void Save()
        {
            PlayerControllerNullCheck();
            _player.NavMeshAgent.enabled = false;
            SavingSystem.Instance.Save(defaultSaveFile);
            _player.NavMeshAgent.enabled = true;
        }



        public void Load()
        {
            PlayerControllerNullCheck();
            Debug.Log("Loading");
            SavingSystem.Instance.Load(defaultSaveFile);
            UpdatePlayerTransform();

        }

        private void PlayerControllerNullCheck()
        {
            if (_player == null)
            {
                _player = FindObjectOfType<PlayerController>();
            }


        }
        private void UpdatePlayerTransform()
        {
            _player.NavMeshAgent.enabled = false;
            var portal = FindObjectOfType<PortalController>();
            _player.transform.position = portal.SpawnPoint.transform.position;
            _player.NavMeshAgent.enabled = true;

        }

    }
}

