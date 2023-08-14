using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Animations;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.Movements;
using UnityEngine;

namespace Unity_RPGProject.States.PlayerStates
{
    public class IdleState : IState
    {
        PlayerController _playerController;
        IMover _mover;
        public IdleState(PlayerController playerController)
        {
            _playerController = playerController;
            _mover = new Mover(_playerController);

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
            _playerController.GetComponent<Animator>().SetFloat("forwardSpeed", 0);
        }

        public void OnEnter()
        {
            Debug.Log("OnEnter IdleState");
        }

        public void OnExit()
        {
            Debug.Log("OnExit IdleState");

        }

        public void Tick()
        {
            _mover.Move();

        }
    }
}

