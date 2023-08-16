using System.Collections;
using System.Collections.Generic;
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
            if (_wayIndex > _wayList.Length) { _wayIndex = 0; }

            float distanceWaypoint = Vector3.Distance(_enemyController.transform.position, _wayList[_wayIndex].transform.position);

            // It's find distance enemy with way's point and i need going to enemy to way point between.

            _wayIndex++;
            return false;
        }



    }
}

