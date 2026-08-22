using UnityEngine;
using UnityEngine.InputSystem;

public class AstronautLocomotion : MonoBehaviour
{
    [Header("Planet")]
    public float gravity = 3.71f;          // Set per planet
    public float jumpImpulse = 4.5f;       // Manual jump force
    public float walkSpeed = 2.0f;         // Horizontal speed
    public float walkBounce = 1.5f;        // NEW: Upward push for each step

    [Header("Input")]
    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    CharacterController cc;
    Vector3 velocity;
    Transform cam;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void OnEnable() { moveAction.action.Enable(); jumpAction.action.Enable(); }
    void OnDisable() { moveAction.action.Disable(); jumpAction.action.Disable(); }

    void Update()
    {
        // 1. Read joystick input
        Vector2 stick = moveAction.action.ReadValue<Vector2>();
        Vector3 forward = Vector3.ProjectOnPlane(cam.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(cam.right, Vector3.up).normalized;
        Vector3 move = (forward * stick.y + right * stick.x) * walkSpeed;

        // 2. Vertical Physics & Bounding
        if (cc.isGrounded)
        {
            if (velocity.y < 0) velocity.y = -1f; // Stick to ground

            // Manual Jump (Optional)
            if (jumpAction.action.WasPressedThisFrame())
                velocity.y = jumpImpulse;

            // NEW: Automatic bounding walk mechanic
            // If the user pushes the joystick past a small deadzone, apply a hop
            if (stick.magnitude > 0.1f && velocity.y <= 0)
            {
                velocity.y = walkBounce;
            }
        }

        // Apply specific planetary gravity every frame
        velocity.y -= gravity * Time.deltaTime;

        // 3. Move the player
        cc.Move((move + new Vector3(0, velocity.y, 0)) * Time.deltaTime);
    }
}