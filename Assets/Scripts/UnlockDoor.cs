using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{

    [SerializeField] DoorType doorType;

    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory == null) { return; }

        inventory.AddDoorKey(doorType);
        Destroy(gameObject);
    }
}
