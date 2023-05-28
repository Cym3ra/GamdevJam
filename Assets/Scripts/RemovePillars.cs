using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePillars : MonoBehaviour, IDroneInteractable
{
    [SerializeField] List<PillarsRemove> pillars = new List<PillarsRemove>();
    [SerializeField] string prompt;

    public string InteractionPrompt => prompt;

    public void OnInteract(DroneInteractor interactor)
    {
        for (int i = 0; i < pillars.Count; i++)
        {
            pillars[i].RemovePillars();
        }
        

        
    }
}
