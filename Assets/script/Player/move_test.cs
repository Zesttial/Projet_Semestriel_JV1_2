using UnityEngine;

public class move_test : MonoBehaviour
{
    public float Vspeed = 5f;
    public float jumpforce = 7f;

    private Rigidbody2D Rb;
    private Animator myAnimator;
    private bool isGrounded;
    private bool isAttack;
    private bool isBox;
    private float AttackTime;
    private float timeAfterAttackingAnimation;


    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Rb.linearVelocity = new Vector2(moveInput* Vspeed, Rb.linearVelocity.y);

            if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true || Input.GetKey(KeyCode.Space) && isGrounded ==true || Input.GetKey(KeyCode.UpArrow) && isBox == true || Input.GetKey(KeyCode.Space) && isBox == true)
            {
                Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, jumpforce);

            }

        float speed = Mathf.Abs(Rb.linearVelocity.x);
        myAnimator.SetFloat("Speed", speed);
        myAnimator.SetBool("Ground", isGrounded || isBox);
        if (moveInput !=0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
                 


    }

    public void Attack()
    {
        myAnimator.SetBool("isAttack", true); 
    }

    public void FinishAttacking()
    {
        myAnimator.SetBool("isAttack", false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            isBox = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            isBox = false;
        }
    }

}
