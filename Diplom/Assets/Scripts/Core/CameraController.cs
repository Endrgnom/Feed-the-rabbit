using UnityEngine;
using Cinemachine;
using System;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerInput _input;

    CinemachineVirtualCamera _activCamera;
    int _activCameraPriorityModifer = 100;

    public Camera MainCamera;
    public CinemachineVirtualCamera cinemachine1stPerson;
    public CinemachineVirtualCamera cinemachine3stPerson;

    private void Start()
    {
        ChangeCamera();        
    }
    private void Update()
    {
        if(_input.ChangeCamera)
        ChangeCamera();
    }

    private void ChangeCamera()
    {
        if(cinemachine3stPerson == _activCamera)
         {
            SetCameraPriorities(cinemachine3stPerson,cinemachine1stPerson);
        }
        else if(cinemachine1stPerson == _activCamera)
        {
            SetCameraPriorities(cinemachine1stPerson,cinemachine3stPerson);
        }
        else
        {
            cinemachine3stPerson.Priority += _activCameraPriorityModifer;
            _activCamera = cinemachine3stPerson;
        }
            
        
    }

    private void SetCameraPriorities(CinemachineVirtualCamera CurrentCameraMode, CinemachineVirtualCamera NewCameraMode)
    {
        CurrentCameraMode.Priority -= _activCameraPriorityModifer;
        NewCameraMode.Priority += _activCameraPriorityModifer;
        _activCamera = NewCameraMode;
    }
}
