using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Inputs;
using Unity_RPGProject.Concrete.Inputs;
using Unity_RPGProject.Controllers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity_RPGProject.Inputs
{
    public class InputReader : IInputReader
    {
        public bool OnMouseLeftClick { get; private set; }

        PlayerController _playerController;
        PlayerInput _input;

        public InputReader(PlayerController playerController)
        {
            _playerController = playerController;
            _input = _playerController.GetComponent<PlayerInput>();

            _input.currentActionMap.actions[0].performed += OnMouseLeftPress;

        }

        public void OnMouseLeftPress(InputAction.CallbackContext context)
        {
            OnMouseLeftClick = context.ReadValueAsButton();
        }


    }
}

