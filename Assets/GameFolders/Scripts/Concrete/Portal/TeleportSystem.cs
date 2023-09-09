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

        public void TeleportVillage(PortalType type)
        {
            switch (type)
            {
                case PortalType.FirstVillage:
                    Debug.Log("FirstVillage ");
                    SceneLoader.Instance.SceneLoading("Game");
                    break;
                case PortalType.SecondVillage:
                    Debug.Log("SecondVillage ");
                    SceneLoader.Instance.SceneLoading("Game2");
                    break;
                default:
                    Debug.Log("Portal Error! No portal type!");
                    break;
            }
        }

    }
}

