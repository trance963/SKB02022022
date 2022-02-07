using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTrigger : MonoBehaviour
{
    public Coal coal;
    public Rigidbody rb;
    public float speed;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 v3Velocity = rb.velocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coal coal))
        {
            speed = rb.velocity.magnitude;
            if (rb.velocity.z < 0.00000001) coal.OnCoalDied();
        }
    }
}
