using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Coal;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Coal.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Coal.transform.position + offset;
    }
}
