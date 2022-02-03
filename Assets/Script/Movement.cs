using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float Speed;
    public int Sensitivity = 10;
    public float Jump;
    public Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.freezeRotation = enabled;
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb.transform.position += rb.transform.forward * Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.position += rb.transform.right * Sensitivity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.position -= rb.transform.right * Sensitivity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.transform.position -= rb.transform.forward * Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * Jump, ForceMode.Impulse);
        }
    }
}
