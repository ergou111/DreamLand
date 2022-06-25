using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float runSpeed;
   public float jumpSpeed;
   public float doubleJumpSpeed;


   private Rigidbody2D myRigidbody;
   private Animator myAnim;
   private BoxCollider2D myFeet;
   private bool isGround;
   private bool canDoubleJump;

   // Start is called before the first frame update
   void Start()
   {
       myRigidbody = GetComponent<Rigidbody2D>();
       myAnim = GetComponent<Animator>();
       myFeet=GetComponent<BoxCollider2D>();
   }

   // Update is called once per frame
   void Update()
   {
       Flip();
       Run();
       Jump();
       CheckGrounded();
       SwitchAnimation();
   }

   //check ground
   void CheckGrounded()
   {
       isGround= myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) || myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlantform"));
   }

   //Move left and right task inversion
   void Flip()
   {
       bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x)>Mathf.Epsilon;
       if(playerHasXAxisSpeed)
       {
           if(myRigidbody.velocity.x>0.1f)
           {
               transform.localRotation = Quaternion.Euler(0,0,0);
           }
           if(myRigidbody.velocity.x<-0.1f)
           {
               transform.localRotation = Quaternion.Euler(0,180,0);
           }
       }
   }

   void Run()
   {
       float moveDir = Input.GetAxis("Horizontal");
       Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
       myRigidbody.velocity = playerVel;
       bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x)>Mathf.Epsilon;
       myAnim.SetBool("run",playerHasXAxisSpeed);
   }

   void Jump()
   {
       if(Input.GetButtonDown("Jump"))
       {
           if(isGround)
            {
                myAnim.SetBool("jump", true);
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVel;
                canDoubleJump = true;
            }
            else
            {
                if(canDoubleJump)
                {
                    myAnim.SetBool("doublejump",true);
                    Vector2 doubleJumpVel = new Vector2(0.0f, doubleJumpSpeed);
                    myRigidbody.velocity = Vector2.up * doubleJumpVel;
                    canDoubleJump = false;
                }
            }
        }
   }

   //change anim
   void SwitchAnimation()
   {
       myAnim.SetBool("idle",false);
       if (myAnim.GetBool("jump"))
        {
            if(myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("jump", false);
                myAnim.SetBool("fall", true);
            }
        }
        else if(isGround)
        {
            myAnim.SetBool("fall", false);
            myAnim.SetBool("idle", true);
        }

        if (myAnim.GetBool("doublejump"))
        {
            if(myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("doublejump", false);
                myAnim.SetBool("doublefall", true);
            }
        }
        else if(isGround)
        {
            myAnim.SetBool("doublefall", false);
            myAnim.SetBool("idle", true);
        }

        
   }
}
