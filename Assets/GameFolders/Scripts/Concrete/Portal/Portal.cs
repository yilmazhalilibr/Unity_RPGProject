using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Unity_RPGProject.Concrete.Portal
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] PortalType _travelTo;

        private void OnTriggerEnter(Collider other)
        {
            switch (_travelTo)
            {
                case PortalType.FirstVillage:

                    break;
                case PortalType.SecondVillage:

                    break;
                default:
                    Debug.Log("Portal Error! No portal type!");
                    break;
            }
        }


    }
}

