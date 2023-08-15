using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.ScriptableObjects;
using UnityEngine;

namespace Unity_RPGProject.States.PlayerStates
{
    public class AttackState : IState, IAttack
    {
        PlayerController _playerController;

        public WeaponSO Weapon => _playerController.Weapon;

        public AttackState(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void OnEnter()
        {
            _playerController.PlayerAnimation.PlayerAttackAnimAsync();
        }

        public void OnExit()
        {
            Debug.Log("Attack State Disable");
            _playerController.PlayerAnimation.PlayerAttackAnimStop();
        }

        public void Tick()
        {
            Debug.Log("Attack State Enable");
        }

        public void FixedTick()
        {
            if (!_playerController.OnHitInfo) return;
            Attack();
        }

        public void LateTick()
        {
        }

        public void Attack()
        {
            _playerController.TargetDetector.CurrentTargetTransform.GetComponent<IHealth>().TakeDamage(Weapon.WeaponDamage);
            _playerController.OnHitInfo = false;
        }

    }
}

