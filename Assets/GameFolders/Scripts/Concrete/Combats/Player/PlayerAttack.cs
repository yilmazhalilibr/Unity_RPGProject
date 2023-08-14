using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.ScriptableObjects;
using Unity_RPGProject.Utilities.Raycast;
using UnityEngine;

namespace Unity_RPGProject.Combats
{
    public class PlayerAttack : IAttack
    {
        PlayerController _playerController;

        public WeaponSO Weapon => _playerController.Weapon;

        public PlayerAttack(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public bool AttackRaycastMouse()
        {
            RaycastHit[] hits = Physics.RaycastAll(RaycastExtension.GetMouseByRaycast());
            foreach (RaycastHit hit in hits)
            {
                IHealth health = hit.transform.GetComponent<IHealth>();
                if (health == null) continue;

                if (_playerController.Input.OnMouseLeftClick)
                {
                    if (GetDistanceEnemy(hit))
                    {
                        health.TakeDamage(Weapon.WeaponDamage);
                        return true;
                    }

                }
            }
            return false;

        }

        private bool GetDistanceEnemy(RaycastHit hit)
        {
            return Vector3.Distance(hit.transform.position, _playerController.transform.position) <= Weapon.WeaponRange;
        }


    }
}

