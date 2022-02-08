using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public Coal coal;
    public Rigidbody rb;
    public GameObject Fireball;
    public ParticleSystem Crack;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
        Crack = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision other)
    {
        coal.OnCoalDied();
        Fireball.SetActive(false);
        Crack.Play();
    }
}
