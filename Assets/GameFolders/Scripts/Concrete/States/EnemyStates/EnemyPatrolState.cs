using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.States.EnemyStates
{
    public class EnemyPatrolState : IState
    {
        EnemyController _enemyController;
        public EnemyPatrolState(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void FixedTick()
        {
            _enemyController.PlayerDetector.PlayerChaseDetector();
            Debug.Log("EnemyPatrolState Tick");
            _enemyController.Mover.Move();

        }

        public void LateTick()
        {
            _enemyController.EnemyAnimation.EnemyMove();

        }

        public void OnEnter()
        {
            _enemyController.NavMeshAgent.speed = 2f;

        }

        public void OnExit()
        {
        }

        public void Tick()
        {
        }



    }
}

