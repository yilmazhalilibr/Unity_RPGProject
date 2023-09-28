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
        GameObject _player;


        private void Awake()
        {
            _teleportSystem = new TeleportSystem();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerController player)) return;
            _player = player.gameObject;
            _ = SaveAndLoadAsync();
        }

        private async UniTaskVoid SaveAndLoadAsync()
        {
            _player.transform.position = _spawnPoint.transform.position;
            await UniTask.Delay(50);
            SavingWrapper.Instance.Save();
            await UniTask.Delay(100);
            await _teleportSystem.TeleportVillage(_travelTo);
            await UniTask.Delay(100);
            SavingWrapper.Instance.Load();

        }



    }
}

