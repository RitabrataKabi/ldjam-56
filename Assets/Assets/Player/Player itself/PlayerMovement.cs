using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Controls controls;
    private Rigidbody rb;

    public Transform orientation;
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
    Vector3 moveDirection;
    void Update()
    {
        input = controls.Player.Movement.ReadValue<Vector2>();
        moveDirection = orientation.forward * input.y + orientation.right * input.x;
    }

    void FixedUpdate()
    {
        
        rb.velocity = new Vector3(moveDirection.x * speed * 0.01f, rb.velocity.y, moveDirection.z * speed * 0.01f);
    }
}
