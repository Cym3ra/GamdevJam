using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] DoorType thisDoor;
    AudioManager audioManager;
    Animator animation;

    private void Awake()
    {
        animation = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }



    public void PlayDoorAnimation(DoorType doorType)
    {
        if (doorType == thisDoor)
        {
            if (animation == null) { return; }
            animation.SetBool("OpenDoor", true);
            audioManager.DoorSound();
        }
    }
}
