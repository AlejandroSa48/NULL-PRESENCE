using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovementRb : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public float rotationSpeed = 720f;

    private Rigidbody rb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 moveInput;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];

        // Evita que el jugador se caiga de lado
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (jumpAction.triggered && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        if (Camera.main == null) return;

        Vector3 move =
            Camera.main.transform.forward * moveInput.y +
            Camera.main.transform.right * moveInput.x;

        move.y = 0f;

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        if (move.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            rb.MoveRotation(
                Quaternion.RotateTowards(
                    rb.rotation,
                    targetRotation,
                    rotationSpeed * Time.fixedDeltaTime
                )
            );
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
