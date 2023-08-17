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
        public EnemyChaseState(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void FixedTick()
        {
            Debug.Log("EnemyChase State Tick");
        }

        public void LateTick()
        {
            _enemyController.EnemyAnimation.EnemyMove();
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

