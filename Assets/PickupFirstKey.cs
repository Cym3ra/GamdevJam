using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupFirstKey : MonoBehaviour
{

    public static event Action OnKeyCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnKeyCollected?.Invoke();
        }
    }
}
