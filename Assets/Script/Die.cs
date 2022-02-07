using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    public Coal coal;
    public GameObject Fireball;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coal coal))
        {
            coal.OnCoalDied();
            Fireball.SetActive(false); // тушим уголек (партикл)
        }
    }
}
