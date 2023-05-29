using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PowerOn : MonoBehaviour, IDroneInteractable
{
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] GameObject powerLight;
    [SerializeField] string text;

    public static event Action OnPowerOn;
    public static event Action OnLayerChange;
    public string InteractionPrompt => text;

    public void OnInteract(DroneInteractor interactor)
    {
        powerLight.SetActive(true);
        //FindObjectOfType<CheckPower>().ConsoleCheckEnabled();
        OnPowerOn?.Invoke();
        OnLayerChange?.Invoke();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Drone"))
        {
            prompt.gameObject.SetActive(true);
            prompt.text = string.Format("[E] to power on");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Drone"))
        {
            prompt.gameObject.SetActive(false);
        }
    }
}
