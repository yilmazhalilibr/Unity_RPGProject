using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;


namespace Unity_RPGProject.States.EnemyStates
{
    public class EnemyChaseState : IState
    {

        EnemyController _enemyController;

        float _currentTime;
        float _chaseTime = 3f;
        public EnemyChaseState(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void FixedTick()
        {
            Debug.Log("EnemyChase State Tick");

            _enemyController.NavMeshAgent.destination = _enemyController.Player.transform.position;
            _currentTime += Time.deltaTime;
            if (_currentTime >= _chaseTime && !_enemyController.IsChase())
            {
                _enemyController.CanChase = false;
                _enemyController.CanPatrol = true;
            }

        }

        public void LateTick()
        {
            _enemyController.EnemyAnimation.EnemyMove();

        }

        public void OnEnter()
        {
            _enemyController.NavMeshAgent.speed = 3.5f;
            _enemyController.NavMeshAgent.stoppingDistance = 2f;
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
        }



    }
}

