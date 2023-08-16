using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Controllers;
using UnityEngine;
using UnityEngine.AI;

namespace Unity_RPGProject.Combats
{
    public class PlayerDetector
    {
        EnemyController _enemyController;
        Transform _player;

        public PlayerDetector(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public Transform PlayerFind()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;

            return _player != null ? _player : null;
        }

        public void PlayerChaseDetector()
        {
            float enemyDistance = Vector3.Distance(_enemyController.transform.position, _enemyController.Player.transform.position);
            if (enemyDistance < _enemyController.ChaseDistance)
            {
                _enemyController.NavMeshAgent.destination = _enemyController.Player.transform.position;
            }
            else
            {
                _enemyController.ChaseCurrentTime += Time.deltaTime;
                _enemyController.CanPatrol = _enemyController.ChaseCurrentTime >= _enemyController.ChaseCancelTime;
            }
        }

    }
}

