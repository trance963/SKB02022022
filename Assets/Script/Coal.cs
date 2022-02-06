using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coal : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Game Game;

    public void ReachFinish()
    {
        Game.OnCoalReachedFinish();
        Rigidbody.velocity = Vector3.zero;
    }

    public void Die()
    {
        Game.OnCoalDied();
        Rigidbody.velocity = Vector3.zero;
    }
}
