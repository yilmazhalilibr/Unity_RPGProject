using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.Enums;
using Unity_RPGProject.ScriptableObjects;
using UnityEngine;

namespace Unity_RPGProject.Combats
{
    public class PlayerAttack : MonoBehaviour
    {
        PlayerController _playerController;

        public WeaponSO Weapon => _playerController.Weapon;

        public PlayerAttack(PlayerController playerController)
        {
            _playerController = playerController;
        }

       

    }
}

