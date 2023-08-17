using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Combats;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.Utilities.Raycast;
using UnityEngine;

namespace Unity_RPGProject.Movements
{
    public class Mover : IMover
    {
        PlayerController _playerController;

        public Mover(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public bool Move()
        {
            if (!_playerController.Input.OnMouseLeftClick) return false;

            var hit = _playerController.Input.LastHitMouse;

            if (hit.collider.TryGetComponent(out IHealth health)) // This component need will be next time to change with EnemyController.
            {
                _playerController.NavMeshAgent.stoppingDistance = _playerController.Weapon.WeaponRange;
                _playerController.NavMeshAgent.destination = hit.point;
            }
            else
            {
                _playerController.NavMeshAgent.destination = hit.point;
            }
            return true;

        }

        public bool Move(Transform transform)
        {
            return false;
        }
    }
}

