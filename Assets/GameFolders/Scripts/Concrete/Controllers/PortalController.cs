using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Unity_RPGProject.Concrete.Controllers
{
    public class PortalController : MonoBehaviour
    {
        [SerializeField] PortalType _travelTo;
        TeleportSystem _teleportSystem;


        private void Awake()
        {
            _teleportSystem = new TeleportSystem();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            _teleportSystem.TeleportVillage(_travelTo);
        }


    }
}

