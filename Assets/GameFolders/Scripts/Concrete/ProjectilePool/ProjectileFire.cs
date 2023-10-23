using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.Concrete.ProjectilePool
{
    public class ProjectileFire
    {
        PlayerController _playerController;

        float _movementDuration = 1f;
        float _elapseTime = 0f;
        Projectile _projectile;
        public ProjectileFire(PlayerController playerController)
        {
            _playerController = playerController;
            _projectile = new Projectile();
           // _projectile.ArrowPoolInitialize();
        }

        public async UniTaskVoid Tick()
        {
            while (true)
            {
                await UniTask.Delay(25);
                _elapseTime += Time.deltaTime;

                if (_elapseTime < _movementDuration)
                {
                    float t = _elapseTime / _movementDuration;
                    _projectile.GetArrowObject().transform.position = Vector3.Lerp(_playerController.transform.position, _playerController.TargetDetector.CurrentTargetTransform.position, t);
                }
                else
                {
                    break;
                }
            }

        }






    }
}
