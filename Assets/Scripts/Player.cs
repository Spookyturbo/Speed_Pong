using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput input;
    private CircleCollider2D powerShotRange;
    private BoxCollider2D boxCollider;
    private Animator anim;
    public float powerShotSpeed = 2;
    public float speed = 50;

    private bool powerShotActive;
    private bool powerShotAvailable;
    private List<Collider2D> ballsInRange;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        boxCollider = GetComponent<BoxCollider2D>();
        string controlScheme = input.defaultControlScheme;
        powerShotRange = GetComponentInChildren<CircleCollider2D>();
        if(Gamepad.current != null)
        {
            input.SwitchCurrentControlScheme(controlScheme, Keyboard.current, Gamepad.current);
        }
        else
        {
            input.SwitchCurrentControlScheme(controlScheme, Keyboard.current);
        }
        powerShotActive = false;
        powerShotAvailable = true;
    }

    private void FixedUpdate()
    {
        rb.velocity = input.currentActionMap["Move"].ReadValue<Vector2>() * speed;
        rb.isKinematic = (rb.velocity == Vector2.zero) ? true : false;
    }

    //For the continous spinning of powershot, only hit things that have just entered
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(powerShotActive)
        {
            if(collision.gameObject.tag == "Ball")
            {
                Ball ball = collision.GetComponent<Ball>();
                ball.PowerShot(ball.transform.position - transform.position, powerShotSpeed);
            }
        }
    }

    //Sends the ball directly back after drawing a line from center of player
    //to the ball, and increase its speed
    public void PowerShot(InputAction.CallbackContext context)
    {
        if (!context.performed || !powerShotAvailable)
            return;

        //Hit all balls in range ONCE
        //Any additional balls that enter the range while spinning
        //are handled by TriggerEnter2D

        //Get the balls in hit range
        Collider2D[] balls = Physics2D.OverlapCircleAll(powerShotRange.transform.position,
            powerShotRange.radius, LayerMask.GetMask("Balls"));

        //Powershot each the balls
        foreach (Collider2D colBall in balls)
        {
            Ball ball = colBall.GetComponent<Ball>();
            ball.PowerShot(ball.transform.position - transform.position, powerShotSpeed);
        }

        anim.SetTrigger("Powershot");
        powerShotAvailable = false;
    }

    public void PowerShotStart()
    {
        powerShotActive = true;
    }

    public void PowerShotEnd()
    {
        powerShotActive = false;
    }

    public void PowerShotRecharged() => powerShotAvailable = true;

}
