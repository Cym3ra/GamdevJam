using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoPowerToSecondDoor : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI noPowerText;
    bool hasPower = false;

    private void TurnsOnPower()
    {
        hasPower = true;
    }

    private void OnEnable()
    {
        PowerOn.OnPowerOn += TurnsOnPower;
    }

    private void OnDisable()
    {
        PowerOn.OnPowerOn -= TurnsOnPower;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasPower)
        {
            noPowerText.text = string.Format("Doesn't seem to have any power. I wonder if the generator is in the other room");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            noPowerText.text = string.Format("");
        }
    }
}
