using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneInteractor : MonoBehaviour
{

    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius;
    [SerializeField] private LayerMask interactionMask;

    private readonly Collider[] colliders = new Collider[3];

    [SerializeField] private int numFound;

    private IDroneInteractable interactable;

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactionMask) * 2;

        if (numFound > 0)
        {
            interactable = colliders[0].GetComponent<IDroneInteractable>();

            if (interactable != null)
            {

                if (Keyboard.current.eKey.wasPressedThisFrame) interactable.OnInteract(this);
            }
        }
        else
        {
            if (interactable != null) interactable = null;
        }
    }
}
