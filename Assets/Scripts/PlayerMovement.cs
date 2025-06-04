using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInput;
    private bool isCrouched = true;
    private float xRotation = 0f;
    private Camera playerCamera;
    private Animator playerAnimator;
    private Box currentBox;

    [Header("Player Settings")]
    public float walkSpeed = 10f;
    public float crouchSpeed = 7f;
    public float mouseSensitivity = 500f;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
        playerCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        LookCheck();
    }

    void FixedUpdate()
    {
        // Obtains movement direction defined in 'PlayerInput.cs'
        Vector3 movement = new Vector3(playerInput.MoveInput.x, 0f, playerInput.MoveInput.y);


        // Checks crouch status, defines movement speed
        if (isCrouched == true)
        {
            movement = transform.TransformDirection(movement.normalized) * crouchSpeed;
            movement.y = rb.linearVelocity.y; // Maintains gravity instead of overriding it
        }

        else
        {
            movement = transform.TransformDirection(movement.normalized) * walkSpeed;
            movement.y = rb.linearVelocity.y; // Maintains gravity instead of overriding it
        }
        // Applies movement directly to player Rigidbody
        rb.linearVelocity = movement;

    }

    void LookCheck()
    {
        Vector2 look = playerInput.LookInput * mouseSensitivity * Time.deltaTime;

        xRotation -= look.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(Vector3.up * look.x); // Rotates the whole body on the Y axis
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Only apply pitch rotation to camera
    }

    public void Crouch()
    {
        // Toggle animation parameter to opposite bool
        bool current = playerAnimator.GetBool("IsCrouched");
        playerAnimator.SetBool("IsCrouched", !current);
    }

    public void EnterExitBox(Box box, bool entering, Vector3 newPosition)
    {
        if (entering)
        {
            currentBox = box;
            transform.position = newPosition;
        }
        else
        {
            currentBox = null;
            transform.position = newPosition;
        }
    }
}
