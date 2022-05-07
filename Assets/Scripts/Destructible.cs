using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    private GameObject destructibleDust;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Bullet"))
        {
            Instantiate(destructibleDust, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
