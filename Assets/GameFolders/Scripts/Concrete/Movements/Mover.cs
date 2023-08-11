using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.Movements
{
    public class Mover : IMover
    {
        PlayerController _playerController;

        public Mover(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void Move()
        {
            _playerController.NavMeshAgent.destination = _playerController.TargetTransform.position;

        }






    }
}

