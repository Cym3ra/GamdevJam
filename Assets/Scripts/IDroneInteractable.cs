using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDroneInteractable
{

    public string InteractionPrompt { get; }

    public void OnInteract(DroneInteractor interactor);
}
