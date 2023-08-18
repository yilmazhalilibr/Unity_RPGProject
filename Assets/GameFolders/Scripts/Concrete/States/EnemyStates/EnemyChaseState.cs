using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;


namespace Unity_RPGProject.States.EnemyStates
{
    public class EnemyChaseState : IState
    {

        EnemyController _enemyController;

        float _currentTime;
        float _chaseTime;

        public EnemyChaseState(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _chaseTime = _enemyController.ChaseTime;
        }
        public void FixedTick()
        {
            Debug.Log("EnemyChase State Tick");

            _enemyController.Mover.Move();

            EnemyChaseHandle();

        }


        public void LateTick()
        {
            _enemyController.EnemyAnimation.EnemyMove();

        }

        public void OnEnter()
        {
            _enemyController.NavMeshAgent.speed = 3.5f;
            _enemyController.NavMeshAgent.stoppingDistance = _enemyController.Weapon.WeaponRange;
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
        }
        private void EnemyChaseHandle()
        {
            if (_enemyController.PlayerHealth.isDead)
            {
                _enemyController.StatesChangeHandle(true, "CanPatrol");
            }
            else if (_enemyController.NavMeshAgent.velocity == Vector3.zero)
            {
                _enemyController.StatesChangeHandle(true, "CanAttack");

            }
            else if (!_enemyController.IsChase())
            {
                _currentTime += Time.deltaTime;
            }
            if (_currentTime >= _chaseTime && !_enemyController.IsChase())
            {
                _enemyController.StatesChangeHandle(true, "CanPatrol");

            }
        }



    }
}

