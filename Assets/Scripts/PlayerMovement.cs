using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float rotationSpeed = 10f;

    private Vector2 moveInput;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
    }

    void Update()
    {
        
        moveInput = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        
        if (jumpAction.triggered)
        {
            transform.position += Vector3.up * jumpHeight;
        }
    }
}
