using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLenght = 4f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private LayerMask Midground;
    private Collider2D coll;
    private Rigidbody2D rb;

    private bool facingLeft = true;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(animator.GetBool("IsJumping"))
        {
            if(rb.velocity.y < -1)
            {
                animator.SetBool("IsFalling", true);
                animator.SetBool("IsJumping", false);
            }
        }
       if(coll.IsTouchingLayers(Midground) && animator.GetBool("IsFalling"))
        {
            animator.SetBool("IsFalling", false);
        }
    }

    private void Move()
    {
        if (facingLeft)
        {
            if (transform.position.x > leftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(Midground))
                {
                    rb.velocity = new Vector2(-jumpLenght, jumpHeight);
                    animator.SetBool("IsJumping", true);
                }
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                if (coll.IsTouchingLayers(Midground))
                {
                    rb.velocity = new Vector2(jumpLenght, jumpHeight);
                    animator.SetBool("IsJumping", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }


}
