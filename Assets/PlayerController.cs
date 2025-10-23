using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode L;
    public KeyCode R;
    public KeyCode spaceBar;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    private bool grounded;
   private Animator anim;
    private Rigidbody2D rb;
    void Start()
    {
       anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

anim.SetFloat ("Speed" ,  Mathf.Abs(rb.velocity.x));
          anim.SetFloat("Height", rb.velocity.y);
          anim.SetBool("Grounded", grounded);

        Debug.Log("Speed: " + rb.velocity.x + "| Grounded: " + grounded );
          

        if (Input.GetKeyDown(spaceBar) && grounded) {
            jump();}
        
if (Input.GetKey(L) ) {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
             if (GetComponent<SpriteRenderer>() != null) {
             GetComponent<SpriteRenderer>().flipX = true;
            } }
        

        if (Input.GetKey(R) ) {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y); 
            if (GetComponent<SpriteRenderer>() != null) {
             GetComponent<SpriteRenderer>().flipX = false;
            }
            }





    }
    void jump(){
    rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        
}
void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); }
   
   
   
   
   
}