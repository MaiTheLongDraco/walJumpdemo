using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] Rigidbody2D rb;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float jumpForce;
    int JumpCount;
    int wallJumpCount;
    bool touchWall;
    // Start is called before the first frame update
    void Start()
    {
        JumpCount = 1;
        wallJumpCount = 1;
    }
    private void FixedUpdate()
    {
    }
    private void Update()
    {
        InPutControl();
    }
    private void InPutControl()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            HorizontalMove();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VerticalMove();
        }
        if(Input.GetKeyDown(KeyCode.Space)&&rb.velocity.y>0&& touchWall)
        {
            WallJump();
        }
    }
    private void HorizontalMove()
    {
      rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") *horizontalSpeed, rb.velocity.y);
    }
    private void VerticalMove()
    {
        if(JumpCount>0)
        {
        JumpCount--;
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void WallJump()
    {
        rb.velocity = new Vector2(-rb.velocity.x*15, jumpForce);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            JumpCount = 1;
        }
        if(collision.gameObject.tag == "wall")
        {
            Debug.Log(wallJumpCount);

            touchWall = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "wall")
        {
            Debug.Log(wallJumpCount);

            wallJumpCount = 1;
            touchWall = false;
        }
    }
}
