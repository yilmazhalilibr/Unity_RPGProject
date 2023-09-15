using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.Helpers;
using UnityEngine;
using UnityEngine.AI;

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
        }

        public void Save()
        {
            PlayerControllerNullCheck();
            _player.NavMeshAgent.enabled = false;
            SavingSystem.Instance.Save(defaultSaveFile);
            UniTask.Delay(150);
            _player.NavMeshAgent.enabled = true;
        }

      

        public void Load()
        {
            PlayerControllerNullCheck();

            Debug.Log("Loading");
            _player.NavMeshAgent.enabled = false;
            SavingSystem.Instance.Load(defaultSaveFile);
            UniTask.Delay(150);
            _player.NavMeshAgent.enabled = true;

        }

        private void PlayerControllerNullCheck()
        {
            if (_player == null)
            {
                _player = FindObjectOfType<PlayerController>();
            }


        }
    }
}

