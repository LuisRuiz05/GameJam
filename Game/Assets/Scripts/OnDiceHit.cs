using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDiceHit : MonoBehaviour
{
    public Collider collider;

    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<DestroyDice>().HandleCollision();
    }
}
