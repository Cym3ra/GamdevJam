using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private DroneControlInput droneInput;
    private float playerSpeed = 2.0f;
    private Transform cameraTransform;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        droneInput = DroneControlInput.Instance;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = droneInput.GetDroneMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        /*if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }*/

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            FindObjectOfType<Drone>().TurnOffDroneControls();
            FindObjectOfType<SwitchCharacter>().TurnBackPlayerControls();
        }
    }
}
