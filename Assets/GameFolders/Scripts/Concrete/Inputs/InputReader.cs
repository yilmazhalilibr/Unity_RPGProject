using Unity_RPGProject.Abstracts.Inputs;
using Unity_RPGProject.Concrete.Inputs;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.Utilities.Raycast;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity_RPGProject.Inputs
{
    public class InputReader : IInputReader
    {
        public bool OnMouseLeftClick { get; private set; }
        public bool OnMouseLeftMultiClick { get; set; }

        PlayerController _playerController;
        GameInput _input;

        RaycastHit _lastHit;

        public RaycastHit LastHitMouse => _lastHit;
        public InputReader(PlayerController playerController)
        {
            _playerController = playerController;
            _input = new GameInput();
            _input.Player.Enable();

            _input.Player.Mouse.performed += OnMouseLeftPress;
            _input.Player.MouseMultiTap.performed += OnMouseLeftMultiPress;

            _lastHit.point = Vector3.zero;
        }


        public void OnMouseLeftPress(InputAction.CallbackContext context)
        {
            MouseRayLastHit();
            OnMouseLeftClick = context.ReadValueAsButton();
            _playerController.TargetDetector.MouseTargetHandle();
        }
        public void OnMouseLeftMultiPress(InputAction.CallbackContext context)
        {
            if (OnMouseLeftMultiClick == true) return;
            MouseRayLastHit();
            OnMouseLeftMultiClick = true;
            _playerController.TargetDetector.MouseTargetHandle();
        }

        public void MouseRayLastHit()
        {
            Ray ray = RaycastExtension.GetMouseByRaycast();
            Physics.Raycast(ray, out _lastHit);
        }


    }
}

