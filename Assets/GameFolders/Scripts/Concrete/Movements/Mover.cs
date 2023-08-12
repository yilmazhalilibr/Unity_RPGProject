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
            Ray ray = RaycastExtension.GetMouseByRaycast();
            RaycastHit hit;

            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    _playerController.NavMeshAgent.stoppingDistance = _playerController.Weapon.WeaponRange;
                    _playerController.NavMeshAgent.destination = hit.point;
                }
                return true;
            }
            return false;

        }



    }
}
