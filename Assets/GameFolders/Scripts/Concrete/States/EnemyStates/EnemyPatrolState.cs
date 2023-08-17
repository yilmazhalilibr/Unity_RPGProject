using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;
using UnityEngine.AI;

namespace Unity_RPGProject.States.EnemyStates
{
    public class EnemyPatrolState : IState
    {
        EnemyController _enemyController;

        Transform[] _patrolWays;
        int _patrolIndex = 0;
        public EnemyPatrolState(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _patrolWays = _enemyController.PatrolPath.GetAllWays();
        }

        public void FixedTick()
        {
            Debug.Log("EnemyPatrolState Tick");

            if (_patrolWays.Length - 1 < _patrolIndex) { _patrolIndex = 0; }

            _enemyController.NavMeshAgent.destination = _patrolWays[_patrolIndex].transform.position;
            if (_enemyController.transform.position.z == _patrolWays[_patrolIndex].transform.position.z)
            {
                _patrolIndex++;
                _enemyController.CanPatrol = false;
                OnExit();
            }

        }

        public void LateTick()
        {
            _enemyController.EnemyAnimation.EnemyMove();
        }

        public void OnEnter()
        {
            _enemyController.NavMeshAgent.speed = 2f;
            _enemyController.NavMeshAgent.stoppingDistance = 0f;


        }

        public void OnExit()
        {
        }

        public void Tick()
        {

        }






    }
}

