using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    List<DoorType> doors = new List<DoorType>();

    public void AddDoorKey(DoorType doorType)
    {
        doors.Add(doorType);
    }

    public void RemoveDoorKey(DoorType doorType)
    {
        doors.Remove(doorType);
    }

    public bool HasDoorKey(DoorType doorType)
    {
        return doors.Contains(doorType);
    }
}
