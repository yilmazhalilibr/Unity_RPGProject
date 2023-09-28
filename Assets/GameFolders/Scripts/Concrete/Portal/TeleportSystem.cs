using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Concrete.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Unity_RPGProject.Concrete
{
    public class TeleportSystem
    {

        public async UniTask TeleportVillage(PortalType type)
        {
            switch (type)
            {
                case PortalType.FirstVillage:
                    await SceneLoader.Instance.SceneLoading(1);
                    break;
                case PortalType.SecondVillage:
                    await SceneLoader.Instance.SceneLoading(2);
                    break;
                default:
                    Debug.Log("Portal Error! No portal type!");
                    break;
            }
        }

    }
}

