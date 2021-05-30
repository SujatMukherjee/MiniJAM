using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{


    Rigidbody2D rb;
    Animator animator;

    public float speed = 5f;
    Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space)) Attack();

        ChangeAnimationState();
        print(isAttacking);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement *speed * Time.fixedDeltaTime);
    }

    internal bool isAttacking;

    void Attack()
    {
        isAttacking = true;
        
        //attack
    }

    void Play(string name)
    {
        animator.Play(name);
    }

   void ChangeAnimationState()
    {
        if (isAttacking) Play("hit");
        else
        {
            if (movement.x != 0 || movement.y != 0) Play("walk");
            else Play("idle");
        }
    }
}
