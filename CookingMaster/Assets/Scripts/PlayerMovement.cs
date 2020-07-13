using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed at which the player moves
    public float movementSpeed = 5;

    //Input axes
    public string horizontalInput;
    public string verticalInput;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Horizontal movement
        if (Input.GetAxis(horizontalInput) != 0)
        {
            rb.velocity = new Vector2(Input.GetAxis(horizontalInput) * movementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);    //if the player isn't pressing any buttons then stop moving
        }

        //Vertical movement
        if (Input.GetAxis(verticalInput) != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis(verticalInput) * movementSpeed);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);    //if the player isn't pressing any buttons then stop moving
        }
    }
}
