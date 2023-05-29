using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour, IInteractable
{
    [SerializeField] string prompt;
    [SerializeField] Animator door;

    public string InteractionPrompt => prompt;

    public void Interact(Interactor interactor)
    {
        door.SetTrigger("ExitDoorOpen");

    }
}
