using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class Move_perso : MonoBehaviour
{
    public Rigidbody2D Rb;
    public float speed = 1f;
    public float jumpforce = 1f;
    public LayerMask Groundmask;
    public LayerMask Wallmask;
    public Animator myAnimator;
    public bool isGrounded;
    public bool isWall;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        var hDirection = 0f;
        var vDirection = 0f;
        isGrounded = CheckGround();
        isWall = CheckLeftWall() || CheckRightWall();

        myAnimator.SetFloat("VSpeed", Rb.linearVelocity.y);
        myAnimator.SetBool("isGrounded", isGrounded);


        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                vDirection += jumpforce;
                myAnimator.SetTrigger("JumpTrigger");
            }
        }
        if (CheckLeftWall() == false)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                hDirection += -1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        if (CheckRightWall() == false)
        {

            if (Input.GetKey(KeyCode.RightArrow))
            {
                hDirection += 1;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        if ((Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.RightArrow)))
        {
            myAnimator.SetBool("IsRunning", true);
        }
        else
        {
            myAnimator.SetBool("IsRunning", false);
        }


        Rb.linearVelocity = new Vector2(hDirection * speed, Rb.linearVelocityY + vDirection);

    }

  //  private bool CheckGround()
  //  {
  //      if (isGrounded == true)
  //      {
  //          return true;
  //      }      
  //      return false;    
  //  }

 //   private void OnTriggerEnter2D(Collider2D triger)
 //       {
 //           if (triger.gameObject.CompareTag("Ground"))
 //           {
 //               isGrounded = true;
 //           }
 //       }
  //  private void OnTriggerExit2D(Collider2D triger)
    //    {
    //        if(triger.gameObject.CompareTag("ground"))
   //        {
    //            isGrounded = false;
   //         }
   //     }



   

    public bool CheckGround()
    {
       var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.5f,Groundmask);
        if (rayCastHit)
        {
            return true;       
        }
         return false;

     }
    public bool CheckRightWall()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(1, 0), 1.3f, Wallmask);
        if (rayCastHit)
        {
            return true;
        }
        return false;
    }
    public bool CheckLeftWall()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 3f, Wallmask);
        if (rayCastHit)
        { 
            return true;
        }
        return false;

    }
}
