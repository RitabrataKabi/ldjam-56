using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Controls controls;
    private Rigidbody rb;
    private Vector2 input;

    public float speed = 100f;
    
    void Awake()
    {
        controls = new Controls();
        rb = GetComponent<Rigidbody>();


        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    void Update()
    {
        input = controls.Player.Movement.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * input.y + transform.right * speed * input.x + Vector3.up * rb.velocity.y;
        print(rb.velocity);
    }
}
