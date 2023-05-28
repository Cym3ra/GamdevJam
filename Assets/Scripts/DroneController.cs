using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private DroneControlInput droneInput;
    private float movementSpeed = 4.0f;
    private float walkingSpeed = 5f;
    private float flyingSpeed = 10f;
    private Transform cameraTransform;
    private float acceleration = 20f;
    private float gravityValue = -9.81f;
    private float mouseSensitivity = 3f;
    Vector3 velocity;
    Vector2 look;

    PlayerInput pInput;
    InputAction moveAction;
    InputAction lookAction;
    InputAction flyUpDownAction;

    public State state;

    internal float movementSpeedMultiplier;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        pInput = GetComponent<PlayerInput>();
        droneInput = DroneControlInput.Instance;
        cameraTransform = Camera.main.transform;
        moveAction = pInput.actions["Move"];
        lookAction = pInput.actions["Look"];
        flyUpDownAction = pInput.actions["FlyUpDown"];
    }

    void Update()
    {
        movementSpeedMultiplier = 1f;

        UpdateFlying();
        UpdateLook();

        /*if (playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = droneInput.GetDroneMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * movementSpeed);

        /*if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);*/


        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            FindObjectOfType<Drone>().TurnOffDroneControls();
            FindObjectOfType<SwitchCharacter>().TurnBackPlayerControls();
        }
    }

    Vector3 GetMovementInput(float speed, bool horizontal = true)
    {
        var moveInput = moveAction.ReadValue<Vector2>();
        var flyUpDownInput = flyUpDownAction.ReadValue<float>();
        var input = new Vector3();
        var referenceTransform = horizontal ? transform : cameraTransform;
        input += referenceTransform.forward * moveInput.y;
        input += referenceTransform.right * moveInput.x;
        if (!horizontal)
        {
            input += transform.up * flyUpDownInput;
        }
        input = Vector3.ClampMagnitude(input, 1f);
        input *= speed * movementSpeedMultiplier;

        return input;
    }

    private void UpdateMovement()
    {
        var input = GetMovementInput(walkingSpeed);

        var factor = acceleration * Time.deltaTime;
        velocity.x = Mathf.Lerp(velocity.x, input.x, factor);
        velocity.z = Mathf.Lerp(velocity.z, input.z, factor);

        controller.Move(velocity * Time.deltaTime);
    }

    private void UpdateFlying()
    {
        var input = GetMovementInput(flyingSpeed, false);

        var factor = acceleration * Time.deltaTime;
        velocity = Vector3.Lerp(velocity, input, factor);
        controller.Move(velocity * Time.deltaTime);
    }

    private void UpdateLook()
    {
        var delta = lookAction.ReadValue<Vector2>();
        //if (delta.magnitude > 10f) return;
        look.x += delta.x * mouseSensitivity;
        look.y += delta.y * mouseSensitivity;

        look.y = Mathf.Clamp(look.y, -89f, 89f);

        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }

    private void OnToggleFlying()
    {
        state = state == State.Flying ? State.Walking : State.Flying;
    }
}

public enum State
{
    Walking,
    Flying
}
