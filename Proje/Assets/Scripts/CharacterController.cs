using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 15f;
    private Rigidbody2D r2d;
    private Animator anmtr;


    private bool grounded;
    private bool started;
    private bool jumping;


    private void Awake()
    {
        r2d = GetComponent<Rigidbody2D>();
        anmtr = GetComponent<Animator>();
        grounded = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(started && grounded)
            {
                anmtr.SetTrigger("Jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                anmtr.SetBool("GameStarted", true);
                started = true;
            }
            
        }
        anmtr.SetBool("Grounded", grounded);
    }


    private void FixedUpdate()
    {
        if (started)
        {
            r2d.velocity = new Vector2(speed, r2d.velocity.y);
        }

        if (jumping)
        {
            Debug.Log("jumping");
            r2d.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
