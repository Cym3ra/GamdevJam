using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerOn : MonoBehaviour, IDroneInteractable
{
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] GameObject powerLight;
    [SerializeField] string text;

    public string InteractionPrompt => text;

    public void OnInteract(DroneInteractor interactor)
    {
        powerLight.SetActive(true);
        FindObjectOfType<CheckPower>().ConsoleCheckEnabled();
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
