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
        }

        public void LateTick()
        {
            _enemyController.PlayerDetector();
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
        }

       

    }
}

