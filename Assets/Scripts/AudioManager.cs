using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip doorSwish;
    [SerializeField] AudioClip interactClick;
    [SerializeField] AudioClip switchCharSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip pickupKey;
    [SerializeField] AudioClip startGenerator;
    [SerializeField] AudioClip pillarsAnim;
    [SerializeField] AudioClip cantInteract;
    [SerializeField] AudioClip droneInteract;

    public void DoorSound()
    {
        audioSource.PlayOneShot(doorSwish);
    }

    public void InteractSound()
    {
        audioSource.PlayOneShot(interactClick);
    }

    public void SwitchCharacterSound()
    {
        audioSource.PlayOneShot(switchCharSound);
    }

    public void WinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void PickupKeySound()
    {
        audioSource.PlayOneShot(pickupKey);
    }

    public void GeneratorSound()
    {
        audioSource.PlayOneShot(startGenerator);
    }

    public void PillarsAnimSound()
    {
        audioSource.PlayOneShot(pillarsAnim);
    }

    public void MissingItem()
    {
        audioSource.PlayOneShot(cantInteract);
    }

    public void DroneInteractSound()
    {
        audioSource.PlayOneShot(droneInteract);
    }
}
