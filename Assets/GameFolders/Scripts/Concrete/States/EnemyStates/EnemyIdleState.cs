using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;


namespace Unity_RPGProject.States.EnemyStates
{
    public class EnemyIdleState : IState
    {
        EnemyController _enemyController;
        [System.Obsolete]
        float _maxIdleTime;
        float _currentTime = 0f;

        public EnemyIdleState(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _maxIdleTime = Random.Range(0f, 4f);
        }

        public void FixedTick()
        {
            PatrolWaiterHandle();
        }

        public void LateTick()
        {
            Debug.Log("EnemyIdleState Tick");

        }

        public void OnEnter()
        {
            _maxIdleTime = Random.Range(0f, 4f);
        }

        public void OnExit()
        {
            _currentTime = 0f;
        }

        public void Tick()
        {
        }
        private void PatrolWaiterHandle()
        {
            _currentTime += Time.deltaTime;
            if (_maxIdleTime < _currentTime && !_enemyController.CanAttack)
            {
                _enemyController.CanPatrol = true;
                _currentTime = 0f;
            }
        }
    }
}

