using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Coal coal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coal coal))
        {
            coal.OnCoalReachedFinish(); // метод финиша
        }
    }
}
