using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marbles : MonoBehaviour
{
    public Transform dire;
    private Rigidbody rb;

    void Start()
    {
        NotificationManager.Instance.AddListener(this, "Marble");
        rb = GetComponent<Rigidbody>();
        rb.mass = 100f;
    }

    public void Marble()
    {
        rb.AddForce(dire.forward * 200f * Random.Range(.7f, 1f), ForceMode.Impulse);
    }
}
