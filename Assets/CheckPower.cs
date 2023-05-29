using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPower : MonoBehaviour
{
    int layerChange;

    private void Awake()
    {
        layerChange = LayerMask.NameToLayer("Interactable");
    }

    public void ConsoleCheckEnabled()
    {
        gameObject.layer = layerChange;
    }

    private void OnEnable()
    {
        PowerOn.OnLayerChange += ConsoleCheckEnabled;
    }

    private void OnDisable()
    {
        PowerOn.OnLayerChange -= ConsoleCheckEnabled;
    }
}
