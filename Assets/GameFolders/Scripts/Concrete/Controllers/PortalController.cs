using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Controllers;
using UnityEngine;
using Zenject;

namespace Unity_RPGProject.Concrete.Controllers
{
    public class PortalController : MonoBehaviour
    {
        [SerializeField] PortalType _travelTo;
        [SerializeField] Transform _spawnPoint;

        TeleportSystem _teleportSystem;

        public Transform SpawnPoint => _spawnPoint;
        private void Awake()
        {
            _teleportSystem = new TeleportSystem();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerController player)) return;
            _ = SaveAndLoadAsync();
        }

        private async UniTaskVoid SaveAndLoadAsync()
        {
            SavingWrapper.Instance.Save();
            await _teleportSystem.TeleportVillage(_travelTo);
            SavingWrapper.Instance.Load();
        }




    }
}

