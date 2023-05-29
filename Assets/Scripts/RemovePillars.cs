using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemovePillars : MonoBehaviour, IDroneInteractable
{
    [SerializeField] List<PillarsRemove> pillars = new List<PillarsRemove>();
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] string text;

    public string InteractionPrompt => text;

    public void OnInteract(DroneInteractor interactor)
    {
        for (int i = 0; i < pillars.Count; i++)
        {
            pillars[i].RemovePillars();
        }
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
