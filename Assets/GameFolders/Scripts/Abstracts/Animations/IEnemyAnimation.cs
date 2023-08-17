using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_RPGProject.Abstracts.Animations
{
    public interface IEnemyAnimation : IAnimations
    {
        void EnemyAttack();
        void EnemyAttackStop();
        void EnemyDie();
        void EnemyMove();
    }

}
