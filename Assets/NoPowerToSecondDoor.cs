using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoPowerToSecondDoor : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI noPowerText;
    bool hasPower = false;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasPower)
        {
            noPowerText.text = string.Format("Doesn't seem to have any power. I wonder if the generator is in the other room");
            audioManager.MissingItem();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            noPowerText.text = string.Format("");
        }
    }
}
