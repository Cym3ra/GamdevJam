using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemovePillars : MonoBehaviour, IDroneInteractable
{
    [SerializeField] List<PillarsRemove> pillars = new List<PillarsRemove>();
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] string text;
    AudioManager audioManager;

    public string InteractionPrompt => text;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnInteract(DroneInteractor interactor)
    {
        for (int i = 0; i < pillars.Count; i++)
        {
            pillars[i].RemovePillars();
        }
        audioManager.PillarsAnimSound();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            prompt.gameObject.SetActive(true);
            prompt.text = string.Format("[E] to power down");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            prompt.gameObject.SetActive(false);
        }
    }
}
