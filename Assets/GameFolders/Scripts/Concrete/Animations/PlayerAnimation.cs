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
        public static string ATTACK_STOP = "stopAttack";
        public static string FORWARD_SPEED = "forwardSpeed";

        public Animator PlayerAnimator { get { return _animator; } set { _animator = value; } }
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
        public void PlayerMoveAnimStop()
        {
            _animator.SetFloat(FORWARD_SPEED, 0f);
        }
        public void PlayerAttackAnim()
        {
            _animator.SetTrigger(ATTACK);
        }

        public async void PlayerAttackAnimAsync()
        {
            _animator.ResetTrigger(ATTACK_STOP);
            _animator.SetTrigger(ATTACK);

            while (!_animator.GetCurrentAnimatorStateInfo(0).IsName(ATTACK))
            {
                await Task.Yield();
            }

            while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                await Task.Yield();
            }

        }

        public void PlayerAttackAnimStop()
        {
            _animator.ResetTrigger(ATTACK);
            _animator.SetTrigger(ATTACK_STOP);
        }


    }
}

