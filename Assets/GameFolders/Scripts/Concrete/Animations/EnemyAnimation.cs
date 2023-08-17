using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Animations;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.Animations
{
    public class EnemyAnimation : IEnemyAnimation
    {
        EnemyController _enemyController;

        Animator _animator;
        Vector3 _localVelocity;


        static string ATTACK = "EnemyAttack";
        static string ATTACK_STOP = "EnemyAttackStop";
        static string DIE = "EnemyDie";
        static string ENEMYSPEED = "EnemySpeed";

        public EnemyAnimation(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _animator = _enemyController.GetComponent<Animator>();
        }

        public void EnemyAttack()
        {
            _animator.ResetTrigger(ATTACK_STOP);
            _animator.SetTrigger(ATTACK);
        }

        public void EnemyAttackStop()
        {
            _animator.ResetTrigger(ATTACK);
            _animator.SetTrigger(ATTACK_STOP);
        }

        public void EnemyMove()
        {
            _localVelocity = _enemyController.transform.InverseTransformDirection(_enemyController.NavMeshAgent.velocity);
            float speed = _localVelocity.z;
            _animator.SetFloat(ENEMYSPEED, speed);
        }
        public void EnemyDie()
        {
            _animator.SetTrigger(DIE);
        }
    }
}

