using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour, IInteractable
{
    [SerializeField] Door door;
    [SerializeField] DoorType doorType;
    [SerializeField] string prompt;
    AudioManager audioManager;
    public string InteractionPrompt => prompt;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Interact(Interactor interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) 
        {
            audioManager.MissingItem();
            return; 
        }


        if (inventory.HasDoorKey(doorType))
        {
            audioManager.InteractSound();
            door.PlayDoorAnimation(doorType);

            inventory.RemoveDoorKey(doorType);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
