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

        public float LerpSpeed { get { return _lerpSpeed; } set { _lerpSpeed = value; } }

        float _lerpSpeed = 20f;
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
                projectile.transform.LookAt(_playerController.TargetDetector.CurrentTargetTransform);
                Vector3 targetPos = _playerController.TargetDetector.CurrentTargetTransform.position;
                projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, new Vector3(targetPos.x, targetPos.y + 1f, targetPos.z), Time.deltaTime * _lerpSpeed);
                
                await UniTask.Delay(1);
                
                if (Mathf.Abs(Vector3.Distance(projectile.transform.position, _playerController.TargetDetector.CurrentTargetTransform.position)) < 0.01f)
                {
                    // Debug.Log(Mathf.Abs(Vector3.Distance(projectile.transform.position, _playerController.TargetDetector.CurrentTargetTransform.position)) + " <= Distance");
                    _projectile.ArrowCompleted(projectile);
                    break;
                }
            }

        }




    }
}
