using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;


namespace Unity_RPGProject.States.EnemyStates
{
    public class EnemyDeadState : IState
    {
        EnemyController _enemyController;

        public EnemyDeadState(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void FixedTick()
        {
        }

        public void LateTick()
        {
        }

        public void OnEnter()
        {
            _enemyController.EnemyAnimation.EnemyDie();
            _enemyController.enabled = false;
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
        }
    }
}

