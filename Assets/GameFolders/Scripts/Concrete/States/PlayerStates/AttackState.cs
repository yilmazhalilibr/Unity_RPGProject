using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

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
        }

        public void OnExit()
        {
            _playerController.PlayerAnimation.PlayerAttackAnimStop();
        }

        public void Tick()
        {
            Debug.Log("AttackState Tick");
        }

        public void FixedTick()
        {
            _playerController.PlayerAnimation.PlayerAttackAnimAsync();
            if (!_playerController.OnHitInfo) return;
            Attack();
        }

        public void LateTick()
        {
            _playerController.transform.LookAtSmooth(_playerController.TargetDetector.CurrentTargetTransform, 2f);
        }

        public async void Attack()
        {
            _playerController.TargetDetector.CurrentTargetTransform.GetComponent<IHealth>().TakeDamage(Weapon.WeaponDamage);
            _playerController.OnHitInfo = false;
            await Task.Delay(700);
        }



    }
}

