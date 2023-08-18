using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;

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

            _enemyController.CanChase = _enemyController.PlayerHealth.isDead ? false : _enemyController.IsChase();
            PatrolHandle();
            _enemyController.Mover.Move();
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

        private void PatrolHandle()
        {
            if (_patrolWays.Length - 1 < _patrolIndex) { _patrolIndex = 0; }

            //_enemyController.NavMeshAgent.destination = _patrolWays[_patrolIndex].transform.position;
            _enemyController.PatrolWay = _patrolWays[_patrolIndex];

            if (_enemyController.transform.position.z == _patrolWays[_patrolIndex].transform.position.z)
            {
                _patrolIndex++;
                _enemyController.CanPatrol = false;
            }

        }




    }
}

