using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    public Vector2 MoveInput;
    public bool MoveIsPressed = false;

    public Vector2 LookInput;
    public bool InvertMouseY = true;

    public bool ChangeCamera = false;
    InputSystem _input;

    private void Update()
    {
        ChangeCamera = _input.Player.ChangeCamera.WasPressedThisFrame();
    }
    private void OnEnable()
    {
        _input = new InputSystem();
        _input.Player.Enable();

        _input.Player.Move.performed += SetMove;
        _input.Player.Move.canceled += SetMove;


        _input.Player.Look.performed += SetLook;
        _input.Player.Look.canceled += SetLook;
    }
    private void OnDisable()
    {
        _input.Player.Move.performed -= SetMove;
        _input.Player.Move.canceled -= SetMove;

        _input.Player.Jump.performed -= SetLook;
        _input.Player.Jump.canceled -= SetLook;
        _input.Player.Disable();
    }

    private void SetLook(InputAction.CallbackContext context)
    {
        LookInput = context.ReadValue<Vector2>();
        MoveIsPressed = !(MoveInput == Vector2.zero);
    }

    private void SetMove(InputAction.CallbackContext context)
    {
       MoveInput = context.ReadValue<Vector2>();
    }

}
