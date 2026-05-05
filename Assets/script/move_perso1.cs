using UnityEngine;

public class est_attack : MonoBehaviour
{
    public Rigidbody2D Rb;
    public float speed = 1;
    public float jumpforce = 1;
    public LayerMask mask;
    public Animator myAnimator;
    public SpriteRenderer mySpriteRenderer;
    public bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var hDirection = 0f;
        var vDirection = 0f;
        isGrounded = CheckGround();
        if(CheckGround())
        {
            if (Input.GetKeyDown (KeyCode.UpArrow))
            {
                vDirection += jumpforce;
            }


        }
        if (CheckLeftWall() == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                hDirection += -1;
            }
        }
        if (CheckRightWall() == false)
        {
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                hDirection += 1;
            }
        }


        Rb.linearVelocity = new Vector2(hDirection * speed, Rb.linearVelocityY + vDirection);
       
        
        transform.localScale = new Vector3(Mathf.Sign(Rb.linearVelocityX),1,1);
    }

    public bool CheckGround()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.3f,mask);
        if (rayCastHit)
        {
            return true;
        }
        return false;
    }
    public bool CheckRightWall()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.6f, mask);
        if (rayCastHit)
        {
            return true;
        }
        return false;
    }
    public bool CheckLeftWall()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.6f, mask);
        if (rayCastHit)
        {
            return true;
        }
        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.purple;
        Gizmos.DrawRay(transform.position, Vector3.down*1.3f);
    }



}
