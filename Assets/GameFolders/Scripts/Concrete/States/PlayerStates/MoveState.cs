using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;


namespace Unity_RPGProject.States.PlayerStates
{
    public class MoveState : IState
    {
        PlayerController _playerController;

        public MoveState(PlayerController playerController)
        {
            _playerController = playerController;

        }

        public void FixedTick()
        {
            _playerController.Mover.Move();
            Debug.Log("MoveFixedTick Enable");

        }

        public void LateTick()
        {
            _playerController.PlayerAnimation.PlayerMoveAnim();
        }


        public void OnEnter()
        {
            _playerController.PlayerAnimation.PlayerAttackAnimStop();

            //Debug.Log($"{nameof(MoveState)} {nameof(OnEnter)}");

        }

        public void OnExit()
        {
            //Debug.Log($"{nameof(MoveState)} {nameof(OnExit)}");


        }

        public void Tick()
        {
        }



    }
}

