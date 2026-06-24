using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem; // Import the input system into this script

public class PlayerController : MonoBehaviour
{
    // Stores the input action sheet used for input
    [SerializeField] private InputActionAsset InputActions;

    // ACTIONS
    private InputAction moveAction;
    private InputAction jumpAction;

    // LOGIC
    private UnityEngine.Vector2 moveInput;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 1f;

    // COMPONENTS
    [SerializeField] private Rigidbody rb;

    // PLAYER SETTINGS
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    // Awake() is called once only when the script instance is loaded, used for initializing variables
    private void Awake()
    {
        // Assign our input action variables to their respective input actions
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        // Assign the rb variable to the players rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        // Turn on the Player action map
        InputActions.FindActionMap("Player")?.Enable();
    }

    private void OnDisable()
    {
        // Turn off the Player action map when this is disabled
        InputActions.FindActionMap("Player")?.Disable();
    }

    // Update() is called once per frame (60-120 frames per second)
    private void Update()
    {
        // Read & store movement input from the action sheet
        moveInput = moveAction.ReadValue<UnityEngine.Vector2>();

        if (jumpAction.WasPressedThisFrame())
        {
            // Tell the player to jump
            HandleJump();
        }
    }

    // FixedUpdate() is called at a fixed interval (50 times per second) and is not frame dependent like Update() to account for consistent physics simulation
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        UnityEngine.Vector3 moveDirection = new UnityEngine.Vector3(
            moveInput.x,
            0f,
            moveInput.y
        );

        moveDirection.Normalize();

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);
    }

    private void HandleJump()
    {
        if (IsGrounded())
        {
            rb.AddForce(UnityEngine.Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Draw the ground check ray
        Debug.DrawRay(transform.position, 
        UnityEngine.Vector3.down * groundCheckDistance);

        return Physics.Raycast
        (transform.position, 
        UnityEngine.Vector3.down, 
        groundCheckDistance,
        groundLayer);
    }
}
