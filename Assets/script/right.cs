using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class right : MonoBehaviour
{
    public float speed;
    bool isMoveLeft;
    bool isMoveRight;
    float horizontalMove;
    bool ground = false;

    public Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PointerDownLeft()
    {
        isMoveLeft = true;
        spriteRenderer.flipX = true;
    }

    public void PointerDownRight()
    {
        isMoveRight = true;
        spriteRenderer.flipX = false;
    }

    public void PointerUpLeft()
    {
        isMoveLeft = false;
    }

    public void PointerUpRight()
    {
        isMoveRight = false;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }

    private void MovePlayer()
    {
        if (isMoveLeft)
        {
            horizontalMove = -1;
        }
        else if (isMoveRight)
        {
            horizontalMove = 1;
        }
        else
        {
            horizontalMove = 0;
        }
    }
}