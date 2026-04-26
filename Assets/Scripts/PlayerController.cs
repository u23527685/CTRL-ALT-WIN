using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    public AudioClip clip;
    public float blueEnergy = 0;
    public float YellowEnergy = 0;
    public UnityEvent startRelease;
    public UnityEvent Release;
    public UnityEvent endRelease;

    public UnityEvent startAbsorb;
    public UnityEvent Absorb;
    public UnityEvent endAbsorb;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float gravity = -9.8f;

    [Header("Camera Settings")]
    [SerializeField] new Transform camera;

    private CharacterController controller;
    private Vector2 moveInput; // Changed to Vector2 to store raw input
    private Vector3 velocityInput;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Safety check to ensure a camera is assigned
        if (camera == null && Camera.main != null)
        {
            camera = Camera.main.transform;
        }
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        // Read the Vector2 value (WASD or Joystick)
        moveInput = callbackContext.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && controller.isGrounded)
        {
            velocityInput.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void OnAbsorb(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            startAbsorb?.Invoke();
        }
        else if (context.performed)
        {
            Absorb?.Invoke();
        }
        else if (context.canceled)
        {
            endAbsorb?.Invoke();
        }
    }

    public void OnRelease(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            startRelease?.Invoke();
        }
        else if (context.performed)
        {
            Release?.Invoke();
        }
        else if (context.canceled)
        {
            endRelease?.Invoke();
        }
    }

    public void Oninteract(InputAction.CallbackContext context)
    {
        if (context.performed && controller.isGrounded)
        {
            Debug.Log("Interact clicked");
        }
    }

    void Update()
    {
        // 1. Get Camera Directions
        Vector3 camForward = camera.forward;
        Vector3 camRight = camera.right;

        // 2. Flatten directions on the Y axis
        camForward.y = 0;
        camRight.y = 0;

        // 3. Normalize to ensure consistent speed regardless of camera tilt
        camForward.Normalize();
        camRight.Normalize();

        // 4. Calculate relative movement direction
        // moveInput.y is "Forward/Back" (Vertical), moveInput.x is "Left/Right" (Horizontal)
        Vector3 moveDirection = (camForward * moveInput.y) + (camRight * moveInput.x);

        // 5. Apply Movement
        controller.Move(moveDirection * speed * Time.deltaTime);

        // 6. Handle Gravity/Velocity
        if (controller.isGrounded && velocityInput.y < 0)
        {
            velocityInput.y = -2f; // Slight downward force to keep grounded
        }

        velocityInput.y += gravity * Time.deltaTime;
        controller.Move(velocityInput * Time.deltaTime);
    }
}