using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickupable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            HandleAction(other);
            Destroy(gameObject);
        }
    }

    protected abstract void HandleAction(Collider2D other);
}
