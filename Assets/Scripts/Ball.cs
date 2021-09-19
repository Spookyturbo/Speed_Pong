using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 4;
    public float acceleration = 0.1f;
    private Vector2 prevVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = Vector2.down * speed;
        prevVelocity = rb.velocity;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;

        prevVelocity = rb.velocity;
        speed += Time.deltaTime * acceleration;
    }

    //Get power shot
    public void PowerShot(Vector2 direction, float speedIncrease)
    {
        speed += speedIncrease;
        rb.velocity = direction * speed;
    }

    //If the collision resulted in the ball to stop moving because of
    //how the physics system works, manually do the collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        //If hit something moveable, it might have nullified the bounce physics
        //No stopping, no straight vertical
        if (tag == "Ball" || tag == "Player")
        {
            //Fix the bounce
            if(rb.velocity == Vector2.zero || rb.velocity.x == 0)
            {
                rb.velocity = Vector2.Reflect(prevVelocity, collision.GetContact(0).normal);
            }
        }

    }

    //Prevents it from ever stopping
    private void OnCollisionStay2D(Collision2D collision)
    {
        OnCollisionEnter2D(collision);
    }

}
