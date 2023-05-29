using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface IDroneInteractable
{

    public string InteractionPrompt { get; }

    public void OnInteract(DroneInteractor interactor);
}
