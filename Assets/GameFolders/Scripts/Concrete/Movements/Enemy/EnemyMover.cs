using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Concrete;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.Movements.Enemy
{
    public class EnemyMover : IMover
    {
        EnemyController _enemyController;


        public EnemyMover(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public bool Move()
        {
            if (_enemyController.PatrolWay != null && _enemyController.CanPatrol)
            {
                _enemyController.NavMeshAgent.destination = _enemyController.PatrolWay.transform.position;
                return true;
            }
            else if (_enemyController.CanChase)
            {
                _enemyController.NavMeshAgent.destination = _enemyController.Player.transform.position;
                return true;
            }

            return false;
        }
        
    }
}

