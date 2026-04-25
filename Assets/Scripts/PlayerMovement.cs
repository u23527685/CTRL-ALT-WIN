using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;

    [Header("Movement Settings")]
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [Header("Camera Settings")]
    [SerializeField] new Transform camera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal") * movementSpeed;
        float verticalAxis = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 camForward =camera.forward;
        Vector3 camRight = camera.right;

        camForward.y = 0;
        camRight.y = 0;

        Vector3 forwardRelative= verticalAxis * camForward;
        Vector3 rightRelative = horizontalAxis * camRight;

        Vector3 moveDir = forwardRelative + rightRelative;


        rb.linearVelocity = new Vector3(moveDir.x, rb.linearVelocity.y, moveDir.z );

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }


    }

    //Ground check
    bool IsGrounded()
    {
        if (groundCheck == null) return false;

        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}

