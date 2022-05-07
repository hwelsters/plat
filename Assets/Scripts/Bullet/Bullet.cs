using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : DestroySelfTimed
{
    [SerializeField]
    private float BULLET_SPEED = 45f;

    [SerializeField]
    private GameObject gunDust;

    private Rigidbody2D rb2D;
    private float direction = 1f;

    private void Start() 
    {
        base.Start();

        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(direction * BULLET_SPEED, 0);
        CreateDust();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        DestroySelf();
    }

    private void DestroySelf()
    {
        CreateDust();

        base.DestroySelf();
    }

    public void SetDirection(float direction)
    {
        this.direction = direction;
    }

    // RENAME
    private void CreateDust()
    {
        Instantiate(gunDust, transform.position, Quaternion.identity);
    }
}
