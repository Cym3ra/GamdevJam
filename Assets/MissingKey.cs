using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissingKey : MonoBehaviour
{

    bool hasKey = false;
    [SerializeField] TextMeshProUGUI missingKeyText;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasKey)
        {
            missingKeyText.text = string.Format("Seems to need a key, I should check the room");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            missingKeyText.text = string.Format("");
        }
    }

}
