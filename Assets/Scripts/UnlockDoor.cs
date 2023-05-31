using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] DoorType doorType;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory == null) { return; }

        audioManager.PickupKeySound();
        inventory.AddDoorKey(doorType);
        Destroy(gameObject);
    }
}
