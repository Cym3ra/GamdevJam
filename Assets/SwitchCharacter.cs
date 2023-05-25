using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchCharacter : MonoBehaviour
{

    [SerializeField] PlayerInput playerInput;
    [SerializeField] CharacterController charController;
    [SerializeField] CinemachineVirtualCamera playerCamera;
    [SerializeField] string prompt;

    public void TurnOffPlayerControls()
    {
        playerInput.enabled = false;
        charController.enabled = false;
        playerCamera.Priority = 1;
    }

    public void TurnBackPlayerControls()
    {
        playerInput.enabled = true;
        charController.enabled = true;
        playerCamera.Priority = 20;
    }
}
