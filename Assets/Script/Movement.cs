using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float Speed;
    public float Sensitivity;
    public float Jump;
    public bool isGrounded;
    public Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.freezeRotation = enabled;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            
            rb.AddForce(0, 0, Speed * Time.deltaTime, ForceMode.VelocityChange);
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
            rb.AddForce(0, 0, Speed * -1 * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * Jump, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
