using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovememt : MonoBehaviour
{
    Vector3 PlayerMoveInput;
    Vector2 MouseMoveInput;
    private InputAction move;
    CharacterController controller;
    ControllPlayer controls;

    float xRot;
    [SerializeField] Transform PlayerCamera;
    [SerializeField] float Speed; 
    [SerializeField] float Sensitivity;

    // void Start()
    // {
    //     controls = new ControllPlayer();
    //     controls.Enable();

    //     controls.Player.Move.performed += Move;
    //     controls.Player.UpDown.performed += UpDown;
    //     controls.Player.MouseDelta.performed += MouseControl;
    //     controls.Player.Move.canceled += Move;
    //     controls.Player.UpDown.canceled += UpDown;
    //     controls.Player.MouseDelta.canceled += MouseControl;

    //     controller = GetComponent<CharacterController>();
    // }

    void Start()
    {
    controller = GetComponent<CharacterController>();
    }
    
    void FixedUpdate()
    {
        
    }

    private void OnEnable() 
    {
        controls.Player.Move.performed += Move;
        controls.Player.UpDown.performed += UpDown;
        controls.Player.MouseDelta.performed += MouseControl;
    }

    void OnDisable()
    {
         controls.Player.Move.performed -= Move;
        controls.Player.UpDown.performed -= UpDown;
        controls.Player.MouseDelta.performed -= MouseControl;
    }


    private void MouseControl(InputAction.CallbackContext context)
    {
        MouseMoveInput = context.ReadValue<Vector2>();
        xRot -=MouseMoveInput.y * Sensitivity;
        transform.Rotate(0f,MouseMoveInput.x * Sensitivity,0f);
        PlayerCamera.localRotation = Quaternion.Euler(xRot,0f,0f);
    }

    private void UpDown(InputAction.CallbackContext context)
    {
         PlayerMoveInput = new Vector3(PlayerMoveInput.x,context.ReadValue<float>(),PlayerMoveInput.z);
    }

    private void Move(InputAction.CallbackContext context)
    {
       PlayerMoveInput = new Vector3(context.ReadValue<Vector2>().x, PlayerMoveInput.y,context.ReadValue<Vector2>().y);
       Vector3 MoveVec = transform.TransformDirection(PlayerMoveInput);

       controller.Move(MoveVec * Speed * Time.deltaTime);

    }

  
}
