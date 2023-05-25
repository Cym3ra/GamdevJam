using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class Drone : MonoBehaviour, IInteractable
{
    [SerializeField] CharacterController charControl;
    [SerializeField] DroneController droneController;
    [SerializeField] CinemachineVirtualCamera droneCamera;
    [SerializeField] PlayerInput droneInput;

    [SerializeField] string prompt;

    public string InteractionPrompt => prompt;

    public void Interact(Interactor interactor)
    {
        charControl.enabled = true;
        droneController.enabled = true;
        droneCamera.Priority = 20;
        droneInput.enabled = true;
        FindObjectOfType<SwitchCharacter>().TurnOffPlayerControls();
    }

    public void TurnOffDroneControls()
    {
        charControl.enabled = false;
        droneController.enabled = false;
        droneCamera.Priority = 5;
        droneInput.enabled = false;
    }

}
