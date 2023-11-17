using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;


namespace Unity_RPGProject.States.EnemyStates
{
    public class EnemyIdleState : IState
    {
        EnemyController _enemyController;

        float _currentIdleTime = 0f;
        float _idleTime = 0f;
        public EnemyIdleState(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void FixedTick()
        {
            _enemyController.CanChase = _enemyController.IsChase();

            _currentIdleTime += Time.deltaTime;

            if (_currentIdleTime >= _idleTime)
            {
                _currentIdleTime = 0f;
                _enemyController.StatesChangeHandle(true, "CanPatrol");

            }

        }

        public void LateTick()
        {
        }

        public void OnEnter()
        {
            _idleTime = Random.Range(0, 3f);
            _enemyController.EnemyHealth.OnTakeHit += ChaseTrigger;
        }

        public void OnExit()
        {
            _enemyController.EnemyHealth.OnTakeHit -= ChaseTrigger;
        }

        public void Tick()
        {
        }

        public void ChaseTrigger(float currentHealth, float maxHealth)
        {
            _enemyController.CanChase = true;
        }

    }
}

