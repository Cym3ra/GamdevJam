using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour, IInteractable
{
    [SerializeField] string prompt;
    [SerializeField] Animator door;
    AudioManager audioManager;

    public string InteractionPrompt => prompt;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Interact(Interactor interactor)
    {
        door.SetTrigger("ExitDoorOpen");
        audioManager.DoorSound();
    }
}
