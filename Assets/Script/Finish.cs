using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Coal coal)) return;
        coal.ReachFinish();
    }
}
