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

        float _maxIdleTime = Random.RandomRange(0, 5f);
        float _currentTime = 0f;

        public EnemyIdleState(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void FixedTick()
        {
            _enemyController.PlayerDetector.PlayerChaseDetector();
            PatrolHandle();
        }

        public void LateTick()
        {

        }

        public void OnEnter()
        {
            _maxIdleTime = Random.RandomRange(0, 5f);
        }

        public void OnExit()
        {

        }

        public void Tick()
        {
        }
        private void PatrolHandle()
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

