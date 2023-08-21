using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_RPGProject.Helpers
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        public static T Instance;

        protected void SetSingletonThisGameObject(T instance)
        {
            if (Instance == null)
            {
                Instance = instance;
                //DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }


    }
}

