using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Controls controls;
    public float mouseSensitivity = 100f;
    public Transform  orientation;

    void OnEnable()
    {
        controls.Camera.Enable();
    }

    void OnDisable()
    {
        controls.Camera.Disable();
    }

    void Awake()
    {
        controls = new Controls();
    }

    float yRot;

    void LateUpdate()
    {
        float mouseX = controls.Camera.Delta.ReadValue<Vector2>().x * mouseSensitivity;

        yRot += mouseX;

        transform.localRotation = Quaternion.Euler(transform.rotation.x, yRot, 0f);
        orientation.Rotate(Vector3.up * mouseX);
    }
}
