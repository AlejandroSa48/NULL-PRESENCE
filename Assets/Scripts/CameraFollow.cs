using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [Header("References")]
    public Transform target;   // Player

    [Header("Settings")]
    public Vector3 offset = new Vector3(0, 2f, -4f);
    public float mouseSensitivity = 3f;

    private float yaw;

    void LateUpdate()
    {
        if (target == null) return;

        // Leer movimiento del mouse
        float mouseX = Mouse.current.delta.x.ReadValue();
        yaw += mouseX * mouseSensitivity;

        // Rotar cámara alrededor del jugador
        Quaternion rotation = Quaternion.Euler(0f, yaw, 0f);
        transform.position = target.position + rotation * offset;

        // Mirar al jugador
        transform.LookAt(target.position + Vector3.up);
    }
}
