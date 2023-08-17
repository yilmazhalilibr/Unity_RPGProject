using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.Movements.Enemy
{
    public class EnemyMover : IMover
    {
        EnemyController _enemyController;

        Transform[] _wayList;
        int _wayIndex = 0;
        public EnemyMover(EnemyController enemyController)
        {
            _enemyController = enemyController;

            _wayList = _enemyController.PatrolPath.GetAllWays();
        }


        public bool Move()
        {

            if (_wayIndex > _wayList.Length - 1) { _wayIndex = 0; }

            _enemyController.NavMeshAgent.destination = _wayList[_wayIndex].transform.position;

            if (_enemyController.NavMeshAgent.velocity == Vector3.zero)
            {
                _enemyController.CanPatrol = false;
                _wayIndex++;

            }

            return true;
        }





    }
}

