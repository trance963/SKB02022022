using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrrentSpeed : MonoBehaviour
{
    public Text Text;
    public Rigidbody rb;

    private void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Text.text = "Speed " + (rb.velocity.magnitude * 3.4f).ToString("0.00");
    }
}
