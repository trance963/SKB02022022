using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTrigger : MonoBehaviour
{
    public Coal coal;
    public Rigidbody rb;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Coal coal))
        {
            if (rb.velocity.magnitude < 0.00000001) coal.OnCoalDied();
        }
    }
}
