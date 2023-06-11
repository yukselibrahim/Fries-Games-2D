using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] SoundManager soundManager;
    [SerializeField] private float jumpPower;
    [SerializeField] float radius;

    public static float gravityScale=1;
    public static float fallGravityScale=15;

    [SerializeField] Transform feetPos;
    [SerializeField] LayerMask layerMask;
    //[SerializeField] Animator anim;

    [SerializeField] float startJump;
    float jumpTime;
    bool isJumping;
    bool doubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    void Update()
    {
        
        JumpAction();
        Gravity();
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }

    void Gravity()
    {

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y< 0)
        {
            rb.gravityScale = fallGravityScale;
        }
    }

    void JumpAction()
    {
        if (Movement.isDashing)
        {
            return;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded() && LevelMenager.canMove)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
            doubleJump = true;
            jumpTime = startJump;
            //anim.SetBool("Jump", true);
            soundManager.JumpSound();
        }
        else if (Input.GetButtonDown("Jump")&& doubleJump)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            doubleJump = false;
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTime>0)
            {
                rb.AddForce(Vector2.up, ForceMode2D.Force);
                jumpTime = Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        //if (Input.GetButtonUp("Jump"))
        //{
        //    isJumping = false;
        //}
        //if (Mathf.Approximately(rb.velocity.y,0)&& anim.GetBool("Jump"))
        //{
        //    anim.SetBool("Jump", false);
        //}

        Gravity();

        

        
    }
}
