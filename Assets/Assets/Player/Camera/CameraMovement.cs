using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Controls controls;
    public float mouseSensitivity = 100f;
    public Transform playerBody;

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
        playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
    }
}
