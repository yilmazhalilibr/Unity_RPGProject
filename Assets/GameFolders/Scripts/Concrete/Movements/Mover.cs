using System;
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
            if (Input.GetMouseButtonDown(0))
            {
                MoveToCursor();
            }

        }

        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool hasHit = Physics.Raycast(ray,out hit);

            if (hasHit) 
            {
                _playerController.NavMeshAgent.destination = hit.point;
            }

        }

    }
}

