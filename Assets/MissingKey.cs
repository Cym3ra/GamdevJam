using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissingKey : MonoBehaviour
{
    AudioManager audioManager;
    bool hasKey = false;
    [SerializeField] TextMeshProUGUI missingKeyText;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void HasKey()
    {
        hasKey = true;
    }

    private void OnEnable()
    {
        PickupFirstKey.OnKeyCollected += HasKey;
    }

    private void OnDisable()
    {
        PickupFirstKey.OnKeyCollected -= HasKey;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasKey)
        {
            missingKeyText.text = string.Format("Seems to need a key, I should check the room");
            audioManager.MissingItem();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            missingKeyText.text = string.Format("");
        }
    }

}
