using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class ZeroGLocomotion : MonoBehaviour
{
    [Header("Input Setup")]
    public InputActionReference moveAction;

    [Header("Movement Settings")]
    public Transform headCamera; // We need to know where the player is looking
    public float flightSpeed = 10f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Read the thumbstick input
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        // Convert the 2D thumbstick input into 3D movement
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);

        // This makes "Forward" equal to exactly where the headset is looking
        moveDirection = headCamera.TransformDirection(moveDirection);

        // Apply the movement
        characterController.Move(moveDirection * flightSpeed * Time.deltaTime);
    }
}