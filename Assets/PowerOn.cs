using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOn : MonoBehaviour, IDroneInteractable
{

    [SerializeField] GameObject powerLight;

    public string InteractionPrompt => throw new System.NotImplementedException();

    public void OnInteract(DroneInteractor interactor)
    {
        powerLight.SetActive(true);
        FindObjectOfType<CheckPower>().ConsoleCheckEnabled();
    }
}
