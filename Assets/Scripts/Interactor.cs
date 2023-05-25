using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius;
    [SerializeField] private LayerMask interactionMask;
    [SerializeField] private InteractionPromptUI interactPromptUI;

    private readonly Collider[] colliders = new Collider[3];

    [SerializeField] private int numFound;

    private IInteractable interactable;

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactionMask) *2;

        if (numFound > 0)
        {
            interactable = colliders[0].GetComponent<IInteractable>();

            if (interactable != null)
            {
                if (!interactPromptUI.IsDisplayed) interactPromptUI.SetUp(interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame) interactable.Interact(this);
            }
        }
        else
        {
            if (interactable != null) interactable = null;
            if (interactPromptUI.IsDisplayed) interactPromptUI.Close();
        }
    }

}
