using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Concrete.Controllers;
using UnityEngine;

public class TeleportSystem 
{

    public void TeleportVillage(PortalType type) 
    {
        switch (type)
        {
            case PortalType.FirstVillage:
                Debug.Log("FirstVillage ");
                break;
            case PortalType.SecondVillage:
                Debug.Log("SecondVillage ");
                break;
            default:
                Debug.Log("Portal Error! No portal type!");
                break;
        }
    }

}
