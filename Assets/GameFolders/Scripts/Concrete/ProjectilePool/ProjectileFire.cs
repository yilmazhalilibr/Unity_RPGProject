using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.Concrete.ProjectilePool
{
    public class ProjectileFire
    {
        PlayerController _playerController;
        Projectile _projectile;

        float _lerpSpeed = 2f;
        public ProjectileFire(PlayerController playerController)
        {
            _playerController = playerController;
            _projectile = _playerController.ProjectTile;

            _projectile.ArrowPoolInitialize();
        }

        public async UniTaskVoid FireTheTarget()
        {
            var projectile = _projectile.GetArrowObject();

            while (projectile != null)
            {
                projectile.SetActive(true);
                projectile.transform.LookAt(_playerController.TargetDetector.CurrentTargetTransform);
                projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, _playerController.TargetDetector.CurrentTargetTransform.position, Time.deltaTime * _lerpSpeed);

                await Task.Delay(1);
                if (Mathf.Abs(Vector3.Distance(projectile.transform.position, _playerController.TargetDetector.CurrentTargetTransform.position)) < 0.01f)
                {
                    Debug.Log(Mathf.Abs(Vector3.Distance(projectile.transform.position, _playerController.TargetDetector.CurrentTargetTransform.position)) + " <= Distance");
                    _projectile.ArrowCompleted(projectile);
                    break;
                }
            }

        }




    }
}
