using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.States.PlayerStates
{
    public class AttackState : IState
    {
        PlayerController _playerController;

        public AttackState(PlayerController playerController)
        {
            _playerController = playerController;

        }

        public void OnEnter()
        {
            _playerController.PlayerAnimation.PlayerAttackAnimAsync();
        }

        public void OnExit()
        {
            Debug.Log("Attack State Disable");
            _playerController.PlayerAnimation.PlayerAttackAnimStop();
        }

        public void Tick()
        {
            Debug.Log("Attack State Enable");
        }

        public void FixedTick()
        {
        }

        public void LateTick()
        {
        }


    }
}

