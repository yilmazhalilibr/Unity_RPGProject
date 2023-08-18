using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;


namespace Unity_RPGProject.States.EnemyStates
{
    public class EnemyAttackState : IState
    {
        EnemyController _enemyController;
        public EnemyAttackState(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _enemyController.OnHit += Attack;
        }

        ~EnemyAttackState()
        {
            _enemyController.OnHit -= Attack;
        }

        public void FixedTick()
        {
            Debug.Log("Attack State Tick");

            if (_enemyController.PlayerAndEnemyDistance() > _enemyController.Weapon.WeaponRange)
            {
                _enemyController.StatesChangeHandle(true, "CanChase");
            }

        }

        public void LateTick()
        {
            _enemyController.EnemyAnimation.EnemyAttack();
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
            _enemyController.EnemyAnimation.EnemyAttackStop();
        }

        public void Tick()
        {
        }

        private void Attack()
        {
            _enemyController.transform.LookAt(_enemyController.Player.transform.position);
            if (_enemyController.PlayerHealth.isDead)
            {
                _enemyController.EnemyAnimation.EnemyAttackStop();
                _enemyController.StatesChangeHandle(true, "CanPatrol");
            }
            else if (_enemyController.CanAttack)
            {
                _enemyController.PlayerHealth.TakeDamage(_enemyController.Weapon.WeaponDamage);
            }
            else
            {
                Debug.Log("Miss Attack!");
            }


        }

    }

}
