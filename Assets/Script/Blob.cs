using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public Coal coal;
    public Rigidbody rb;
    public GameObject Fireball;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        coal.OnCoalDied();
        Fireball.SetActive(false);
    }
}
