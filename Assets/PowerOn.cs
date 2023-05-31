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
    AudioManager audioManager;

    public static event Action OnPowerOn;
    public static event Action OnLayerChange;
    public string InteractionPrompt => text;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnInteract(DroneInteractor interactor)
    {
        powerLight.SetActive(true);
        audioManager.GeneratorSound();
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
