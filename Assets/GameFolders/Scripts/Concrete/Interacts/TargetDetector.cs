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

        private Targets _currentTargetType;
        private Transform _currentTargetTransform;


        public Targets CurrentTargetType => _currentTargetType;
        public Transform CurrentTargetTransform => _currentTargetTransform;

        public TargetDetector(PlayerController playerController)
        {
            _playerController = playerController;
            _currentTargetType = Targets.UNDEFINITION;
        }

        public void MouseTargetHandle()
        {
            if (_playerController.Input.LastHitMouse.collider.TryGetComponent(out IHealth health) && !_playerController.Input.LastHitMouse.collider.TryGetComponent(out PlayerController pController))
            {
                _currentTargetType = Targets.Enemy;
                _currentTargetTransform = _playerController.Input.LastHitMouse.collider.transform;
                //Debug.Log("Current Target is : Enemy");
            }
            else if (_playerController.Input.LastHitMouse.collider.CompareTag("NPC"))
            {
                _currentTargetType = Targets.NPC;
            }
            else
            {
                _currentTargetType = Targets.UNDEFINITION;

            }


        }



    }
}

