using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Helpers;
using UnityEngine;

namespace Unity_RPGProject.Concrete
{
    public class SavingWrapper : SingletonMonoBehaviour<SavingWrapper>
    {
        const string defaultSaveFile = "save";
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

        private void Save()
        {
            SavingSystem.Instance.Save(defaultSaveFile);
        }

        private void Load()
        {
            Debug.Log("Loading");
            SavingSystem.Instance.Load(defaultSaveFile);
        }

    }
}

