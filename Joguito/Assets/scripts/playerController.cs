﻿using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool facingRight = true;
    public bool isGrounded = true;
    public int coinCount = 0;
    public int lifes = 3;
    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        print("eae jogo bosta");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        anim.speed = 0.5f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            FlipRight();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            FlipLeft();
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true || Input.GetKey(KeyCode.UpArrow) && isGrounded==true)
        {
            Jump();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("Chest")
            || collision.gameObject.CompareTag("Spike"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            print("qtd de coins: " + coinCount);
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            lifes--;
            print("-1 de vida, vidas restantes: " + lifes);
            if (lifes == 0)
            {
                Destroy(gameObject);
            }
            switch (lifes)
            {
                case 2:
                    Destroy(l1);
                    break;
                case 1:
                    Destroy(l2);
                    break;
                case 0:
                    Destroy(l3);
                    break;
                default:
                    print("");
                    break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("Chest")
            || collision.gameObject.CompareTag("Spike"))
        {
            isGrounded = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Impact"))
        {
            lifes--;
            print("-1 de vida, vidas restantes: " + lifes);
            if (lifes == 0)
            {
                Destroy(gameObject);
            }
            switch (lifes)
            {
                case 2:
                    Destroy(l1);
                    break;
                case 1:
                    Destroy(l2);
                    break;
                case 0:
                    Destroy(l3);
                    break;
                default:
                    print("");
                    break;
            }
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 10f);
    }

    void FlipRight()
    {
        if (facingRight == true)
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = false;
        }
    }
    void FlipLeft()
    {
        if (facingRight == false)
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = true;
        }
    }
}  //testeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee