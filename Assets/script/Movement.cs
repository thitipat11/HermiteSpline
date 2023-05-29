using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    public float speed = 5;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;
    }
    public void PointerDownLeft(BaseEventData bed)
    {
        moveLeft = true;
       
    }
    public void PointerUpLeft(BaseEventData bed)
    {
        moveLeft = false;
       
    }
    public void PointerDownRight(BaseEventData bed)
    {
        moveRight = true;
     
    }
    public void PointerUpRight(BaseEventData bed)
    {
        moveRight = false;
     
    }
    void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
         
    }
    private void FixedUpdate()
    {
        // rb.velocity += Vector2.right *100;
        // Debug.Log(rb.velocity);
         var tempvec = new Vector2(horizontalMove, rb.velocity.y);
          Debug.Log(tempvec);
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}