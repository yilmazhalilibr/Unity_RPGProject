using Unity_RPGProject.Abstracts.Movements;
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
            return true;
        }
    }
}

