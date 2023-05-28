using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour, IInteractable
{
    [SerializeField] Door door;
    [SerializeField] DoorType doorType;
    [SerializeField] string prompt;

    public string InteractionPrompt => prompt;

    public void Interact(Interactor interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) { return; }


        if (inventory.HasDoorKey(doorType))
        {
            door.PlayDoorAnimation(doorType);

            inventory.RemoveDoorKey(doorType);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
