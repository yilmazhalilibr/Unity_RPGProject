using Unity_RPGProject.Abstracts.States;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.States.PlayerStates
{
    public class IdleState : IState
    {
        PlayerController _playerController;

        public IdleState(PlayerController playerController)
        {
            _playerController = playerController;

        }

        public void FixedTick()
        {

        }

        public void LateTick()
        {
            Debug.Log("IdleTick Enable");
        }

        public void OnEnter()
        {
            //Debug.Log($"{nameof(IdleState)} {nameof(OnEnter)}");

        }

        public void OnExit()
        {
            //Debug.Log($"{nameof(IdleState)} {nameof(OnExit)}");


        }

        public void Tick()
        {

        }
    }
}

