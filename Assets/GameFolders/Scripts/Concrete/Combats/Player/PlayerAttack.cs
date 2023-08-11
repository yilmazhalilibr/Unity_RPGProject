using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.Combats
{
    public class PlayerAttack : IAttack
    {
        PlayerController _playerController;

        public PlayerAttack(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public bool Attack()
        {
            RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
            foreach (RaycastHit hit in hits)
            {
                IHealth health = hit.transform.GetComponent<Health>();
                if (health == null) continue;
                if (Input.GetMouseButton(0))
                {
                    health.TakeDamage(_playerController.Damage);
                    return true;
                }
            }
            return false;

        }
    }
}

