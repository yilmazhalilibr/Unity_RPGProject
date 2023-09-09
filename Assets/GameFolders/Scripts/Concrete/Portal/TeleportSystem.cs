using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Concrete.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportSystem
{

    public void TeleportVillage(PortalType type)
    {
        switch (type)
        {
            case PortalType.FirstVillage:
                Debug.Log("FirstVillage ");
                SceneManager.LoadScene("Game");
                break;
            case PortalType.SecondVillage:
                Debug.Log("SecondVillage ");
                SceneManager.LoadScene("Game2");
                break;
            default:
                Debug.Log("Portal Error! No portal type!");
                break;
        }
    }

}
