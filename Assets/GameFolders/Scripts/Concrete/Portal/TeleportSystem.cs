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
                    //Debug.Log("FirstVillage ");
                    _ = SceneLoader.Instance.SceneLoading(1);
                    break;
                case PortalType.SecondVillage:
                    //Debug.Log("SecondVillage ");
                    _ = SceneLoader.Instance.SceneLoading(2);
                    break;
                default:
                    Debug.Log("Portal Error! No portal type!");
                    break;
            }
        }

    }
}

