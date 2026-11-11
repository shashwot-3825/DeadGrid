using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 4f;
    public float rotationSpeed = 10f;
    public float jumpHeight = 1.2f;
    public float gravity = -15f;

    private CharacterController controller;
    private Animator animator;
    private Vector3 verticalVelocity;
    private bool canMove = false; // Locked until typewriter intro finishes

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // If the intro hasn't unlocked movement yet, do nothing
        if (!canMove) return;

        // Read WASD / Arrow keys
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 moveInput = new Vector3(h, 0f, v).normalized;

        if (moveInput.magnitude >= 0.1f)
        {
            // Face the direction of movement smoothly
            Quaternion targetRot = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);

            // Move the character forward
            controller.Move(moveInput * moveSpeed * Time.deltaTime);
            animator.SetFloat("Speed", 1f); // Triggers Walking animation
        }
        else
        {
            animator.SetFloat("Speed", 0f); // Returns to Breathing Idle
        }

        // Jump & Grounded Gravity Logic
        if (controller.isGrounded)
        {
            verticalVelocity.y = -2f; // Small downward stick force to keep grounded

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    // Called by TypeWriterEffect script the moment the typewriter finishes
    public void WakeUpAndPlay()
    {
        animator.SetTrigger("WakeUp");
        
        // Wait for the get-up animation duration (approx 2.5 seconds) before unlocking controls
        Invoke(nameof(EnableControl), 2.5f);
    }

    void EnableControl()
    {
        canMove = true;
    }
}