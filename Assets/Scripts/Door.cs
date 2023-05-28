using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] DoorType thisDoor;

    Animator animation;

    private void Awake()
    {
        animation = GetComponent<Animator>();
    }



    public void PlayDoorAnimation(DoorType doorType)
    {
        if (doorType == thisDoor)
        {
            if (animation == null) { return; }
            animation.SetBool("OpenDoor", true);
        }
    }
}
