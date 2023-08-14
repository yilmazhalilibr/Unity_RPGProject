using System.Threading.Tasks;
using Unity_RPGProject.Abstracts.Animations;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.Animations
{
    public class PlayerAnimation : IPlayerAnimation
    {
        PlayerController _playerController;
        Animator _animator;

        Vector3 _localVelocity;

        public static string ATTACK = "attack";
        public static string FORWARD_SPEED = "forwardSpeed";
        public PlayerAnimation(PlayerController playerController)
        {
            _playerController = playerController;
            _animator = _playerController.GetComponent<Animator>();
        }

        public void PlayerMoveAnim()
        {
            _localVelocity = _playerController.transform.InverseTransformDirection(_playerController.NavMeshAgent.velocity);
            float speed = _localVelocity.z;

            _animator.SetFloat(FORWARD_SPEED, speed);
        }

        public void PlayerAttackAnim()
        {
            _animator.SetBool(ATTACK, true);

        }

        public async void PlayerAttackAnimAsync()
        {
            _animator.SetBool(ATTACK, true);
            await Task.Delay((int)_animator.GetCurrentAnimatorStateInfo(0).length);

        }

        public void PlayerAttackAnimStop() 
        {
            _animator.SetBool(ATTACK,false);
        }


    }
}

