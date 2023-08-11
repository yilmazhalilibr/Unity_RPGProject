using Unity_RPGProject.Abstracts.Animations;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.Animations
{
    public class PlayerAnimationWithNavMesh : IPlayerAnimation
    {
        PlayerController _playerController;

        Vector3 _localVelocity;

        public PlayerAnimationWithNavMesh(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void AnimationUpdate()
        {
            _localVelocity = _playerController.transform.InverseTransformDirection(_playerController.NavMeshAgent.velocity);
            float speed = _localVelocity.z;
            _playerController.GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }


    }
}

