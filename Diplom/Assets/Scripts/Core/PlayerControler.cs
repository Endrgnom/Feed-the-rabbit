using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Transform CameraFollow;
  [SerializeField] PlayerInput _input;
    public HUD HUD;

    // private Animator _animator;

    
  Rigidbody _rigibody;
  public Inventory inventory;

  Vector3 _playerMoveInput;
  Vector3 _playerLookInput;
  Vector3 _previousPlayerLookInput;
  [SerializeField] float _cameraPitch;
  [SerializeField] float _playerLookInputLerpTime = 0.35f;

  [Header("Movement")]
  [SerializeField] float _movementMultiplier = 30f;
  [SerializeField] float _rotationSpeedMultiplier = 180f;
  [SerializeField] float _pitchSpeedMultiplier = 180f;

    // void Start()
    // {
    //     _animator = GetComponent<Animator>();
    // }
  private void Awake()
  {
      _rigibody = GetComponent<Rigidbody>();
  }

    private void FixedUpdate()
    {
        _playerLookInput = GetLookInput();
        PlayerLook();
        PitchCamera();

        _playerMoveInput = GetMoveInput();
        PlayerMover();
    

    _rigibody.AddRelativeForce(_playerMoveInput,ForceMode.Force);  

    }
    private Vector3 GetLookInput()
    {
        _previousPlayerLookInput = _playerLookInput;
        _playerLookInput = new Vector3(_input.LookInput.x,(_input.InvertMouseY? -_input.LookInput.y : _input.LookInput.y),0f);
        return Vector3.Lerp(_previousPlayerLookInput, _playerLookInput * Time.deltaTime, _playerLookInputLerpTime);
    }
    private void PlayerLook()
    {
        _rigibody.rotation = Quaternion.Euler(0, _rigibody.rotation.eulerAngles.y +
                                             (_playerLookInput.x * _rotationSpeedMultiplier), 0f);
    }

    private void PitchCamera()
    {
       Vector3 rotationValues = CameraFollow.rotation.eulerAngles;
       _cameraPitch += _playerLookInput.y * _pitchSpeedMultiplier;
       _cameraPitch = Math.Clamp(_cameraPitch, -38f, 50f);

       CameraFollow.rotation = Quaternion.Euler(_cameraPitch, rotationValues.y, rotationValues.z);
    }
     

    private Vector3 GetMoveInput()
    {
        return new Vector3(_input.MoveInput.x,0f,_input.MoveInput.y);
    }
    private void PlayerMover()
    {
       _playerMoveInput = (new Vector3(_playerMoveInput.x * _movementMultiplier * _rigibody.mass,
                                       _playerMoveInput.y,
                                       _playerMoveInput.z * _movementMultiplier * _rigibody.mass));
    }


    private IInventoryItem mItemToPicup = null;
    private void OnTriggerEnter(Collider other) 
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            mItemToPicup = item;
            inventory.AddItem(item);
            item.OnPickup();
            HUD.OpenMessagePanel("");
        }
    }

    void OnTriggerExit(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            HUD.CloseMessagePanel();
            mItemToPicup = null;
        }
    }


}
