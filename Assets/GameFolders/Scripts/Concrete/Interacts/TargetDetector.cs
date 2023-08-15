using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.Enums;
using UnityEngine;

namespace Unity_RPGProject.Interacts
{
    public class TargetDetector
    {
        PlayerController _playerController;

        private Targets _currentTarget;

        public Targets CurrentTarget => _currentTarget;

        public TargetDetector(PlayerController playerController)
        {
            _playerController = playerController;
            _currentTarget = Targets.UNDEFINITION;
        }

        public void MouseTargetHandle()
        {
            if (_playerController.Input.LastHitMouse.collider.TryGetComponent(out IHealth health))
            {
                _currentTarget = Targets.Enemy;
                //Debug.Log("Current Target is : Enemy");
            }
            else if (_playerController.Input.LastHitMouse.collider.CompareTag("NPC"))
            {
                _currentTarget = Targets.NPC;
            }
           

        }



    }
}

