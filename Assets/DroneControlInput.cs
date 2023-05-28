using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneControlInput : MonoBehaviour
{
    private static DroneControlInput instance;
    
    public static DroneControlInput Instance
    {
        get { return instance; }
    }

    private DroneInput droneInput;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        droneInput = new DroneInput();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        droneInput.Enable();
    }

    private void OnDisable()
    {
        droneInput.Disable();
    }

    public Vector2 GetDroneMovement()
    {
        return droneInput.Drone.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return droneInput.Drone.Look.ReadValue<Vector2>();
    }

    public Vector2 GetDroneFLying()
    {
        return droneInput.Drone.FlyUpDown.ReadValue<Vector2>();
    }

    /*[Header("Movement")]
        public float moveSpeed;
        private Vector2 curMovementInput;

        [Header("Look")]
        public Transform cameraContainer;
        public float minXLook;
        public float maxXLook;
        private float camCurXRot;
        public float lookSensitivity;

        private Vector2 mouseDelta;

        [HideInInspector]
        public bool canLook = true;

        private Rigidbody rgbd;

        private void Awake()
        {
            rgbd = GetComponent<Rigidbody>();
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void LateUpdate()
        {
            if (canLook)
            {
                CameraLook();
            }
        }

        private void Move()
        {
            Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
            dir *= moveSpeed;
            dir.y = rgbd.velocity.y;

            rgbd.velocity = dir;
        }

        private void CameraLook()
        {
            camCurXRot += mouseDelta.y * lookSensitivity;
            camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
            cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

            transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
        }

        public void OnLookInput(InputAction.CallbackContext context)
        {
            mouseDelta = context.ReadValue<Vector2>();
        }

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                curMovementInput = context.ReadValue<Vector2>();
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                curMovementInput = Vector2.zero;
            }
        }*/
}
