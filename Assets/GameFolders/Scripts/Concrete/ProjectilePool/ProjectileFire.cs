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
        Projectile _projectile;

        float _lerpSpeed = 0.1f;
        float _elapseTime = 0f;

        public ProjectileFire(PlayerController playerController)
        {
            _playerController = playerController;
            _projectile = _playerController.ProjectTile;

            _projectile.ArrowPoolInitialize();
        }

        public void FireTheTarget()
        {
            var projectile = _projectile.GetArrowObject();

            while (projectile != null)
            {
                _elapseTime = Time.deltaTime * _lerpSpeed;
                float t = Mathf.Clamp01(_elapseTime);

                projectile.transform.LookAt(_playerController.TargetDetector.CurrentTargetTransform);
                projectile.transform.position = Vector3.Lerp(projectile.transform.position, _playerController.TargetDetector.CurrentTargetTransform.position, t);

                if (Mathf.Abs(Vector3.Distance(projectile.transform.position, _playerController.TargetDetector.CurrentTargetTransform.position)) < 0.1f)
                {
                    _projectile.ArrowCompleted(projectile);
                    break;
                }
            }

        }




    }
}
