using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isJumping;

    private float moveHorizontal;
    private float moveVertical;
    
    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 15f;
        jumpForce = 40f;
        isJumping = false;
    }

    
    private void Update()
    {
        //Player Inputs
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");     

        //Player Jumping
        if(!isJumping && Input.GetButtonDown("Jump"))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }


    private void FixedUpdate() 
    {
        //Player Movement
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            //rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            rb2D.velocity = new Vector2(moveHorizontal * moveSpeed, rb2D.velocity.y);
        }
    }


    //Collision Detection
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }   
    }
}
