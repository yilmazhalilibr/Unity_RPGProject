using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.Movements;
using Unity_RPGProject.Utilities.Raycast;
using UnityEngine;


namespace Unity_RPGProject.States.PlayerStates
{
    public class MoveState : IState
    {
        PlayerController _playerController;

        Vector3 _localVelocity;

        public MoveState(PlayerController playerController)
        {
            _playerController = playerController;

        }

        public void FixedTick()
        {

        }

        public void LateTick()
        {
            Animation();
        }

        private void Animation()
        {
            _localVelocity = _playerController.transform.InverseTransformDirection(_playerController.NavMeshAgent.velocity);
            float speed = _localVelocity.z;
            _playerController.GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

        public void OnEnter()
        {
            Debug.Log("OnEnter MoveState");

        }

        public void OnExit()
        {
            Debug.Log("OnExit MoveState");

        }

        public void Tick()
        {
            _playerController.Mover.Move();
        }



    }
}

