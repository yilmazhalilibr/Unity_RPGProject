using Unity_RPGProject.Abstracts.Inputs;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.Utilities.Raycast;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity_RPGProject.Inputs
{
    public class InputReader : IInputReader
    {
        public bool OnMouseLeftClick { get; private set; }

        PlayerController _playerController;
        PlayerInput _input;

        RaycastHit _lastHit;

        public RaycastHit LastHitMouse => _lastHit;
        public InputReader(PlayerController playerController)
        {
            _playerController = playerController;
            _input = _playerController.GetComponent<PlayerInput>();

            _input.currentActionMap.actions[0].performed += OnMouseLeftPress;

            _lastHit.point = Vector3.zero;
        }

        public void OnMouseLeftPress(InputAction.CallbackContext context)
        {
            MouseRayLastHit();
            OnMouseLeftClick = context.ReadValueAsButton();
            _playerController.TargetDetector.MouseTargetHandle();
        }

        public void MouseRayLastHit()
        {
            Ray ray = RaycastExtension.GetMouseByRaycast();
            Physics.Raycast(ray, out _lastHit);
        }


    }
}

