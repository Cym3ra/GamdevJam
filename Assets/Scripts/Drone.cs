using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using TMPro;

public class Drone : MonoBehaviour, IInteractable
{
    [SerializeField] CharacterController charControl;
    [SerializeField] DroneController droneController;
    [SerializeField] CinemachineVirtualCamera droneCamera;
    [SerializeField] PlayerInput droneInput;
    [SerializeField] TextMeshProUGUI dronetext;
    AudioManager audioManager;
    [SerializeField] string prompt;

    public string InteractionPrompt => prompt;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Interact(Interactor interactor)
    {
        audioManager.SwitchCharacterSound();
        charControl.enabled = true;
        droneController.enabled = true;
        droneCamera.Priority = 20;
        droneInput.enabled = true;
        FindObjectOfType<SwitchCharacter>().TurnOffPlayerControls();
        dronetext.text = string.Format("[E] to interact \n\n[T] to switch back to player");
    }

    public void TurnOffDroneControls()
    {
        audioManager.SwitchCharacterSound();
        charControl.enabled = false;
        droneController.enabled = false;
        droneCamera.Priority = 5;
        droneInput.enabled = false;
        dronetext.text = string.Format("");
    }

}
