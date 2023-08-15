using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;


namespace Unity_RPGProject.States.PlayerStates
{
    public class DeadState : IState
    {
        readonly PlayerController _playerController;

        public DeadState(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void FixedTick()
        {
        }

        public void LateTick()
        {
        }

        public void OnEnter()
        {
            _playerController.GetComponent<Animator>().SetTrigger("die");
            _playerController.enabled = false;
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
        }
    }
}

