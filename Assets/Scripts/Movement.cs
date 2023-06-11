using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer tr;
    [SerializeField] float playerYboundry;
    LevelMenager levelManager; //LevelMenager burda scriptimizin adý
    SoundManager soundManager;
    UIManager uiManager;
    Delay delayScript;
    PlayerHealthScript playerHealth;
    [SerializeField] float horizontalMove;
    public static bool canDash = true;
    public static bool isDashing = false;
    public static bool blocking;
    [SerializeField] float dashAmount;
    [SerializeField] float dashCooldown;
    [SerializeField] float dashTime;
    public static bool dashed;
    [SerializeField] Animator anim;


    

    public float moveSpeed;

    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.Find("Level Menager").GetComponent<LevelMenager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        delayScript = GameObject.Find("Level Menager").GetComponent<Delay>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        playerHealth = GameObject.Find("Level Menager").GetComponent<PlayerHealthScript>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && horizontalMove != 0)
        {
            StartCoroutine(Dash());
        }
        horizontalMove = Input.GetAxis("Horizontal");
        MovementAction();
        PlayerDestroyer();
        Block();
    }

    void PlayerDestroyer()
    {
        if (transform.position.y < playerYboundry)
        {
            playerHealth.Lives();
            if (delayScript.delayTime==true)
            {
                delayScript.StartDelayTime();
            }
            
            Destroy(gameObject);          
            soundManager.DeathbyFall();
            Cancel();

        }

        
    }



    void MovementAction()
    {
        if (isDashing)
        {
            return;
        }
        if (LevelMenager.canMove)
        {
           
            rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
            SpriteFlip(horizontalMove);
            anim.SetFloat("Move", Mathf.Abs(horizontalMove));
        }
       

    }


    void SpriteFlip(float horizontalMove)
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        tr.emitting = true;
        rb.gravityScale = 0;
        Jump.fallGravityScale = 0;
        rb.velocity = new Vector2(horizontalMove * dashAmount, 0);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = 1;
        Jump.fallGravityScale = 15;
        isDashing = false;
        tr.emitting = false;
        dashed = true;
        yield return new WaitForSeconds(dashCooldown);
        dashed = false;
        canDash = true;
    }

    public static void Cancel()
    {
        canDash = true;
        isDashing = false;
        dashed = false;
        Jump.fallGravityScale = 15;
    }

    public void Die()
    {
        Destroy(gameObject);
        PlayerHealthScript.instance.Lives();
        Cancel();
        if (Delay.instance.delayTime)
        {
            Delay.instance.StartDelayTime();
        }
    }

    void Block()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("Sheild", true);
            blocking = true;
            rb.velocity = Vector2.zero;
            LevelMenager.canMove = false;
        }
        else if(Input.GetMouseButton(0))
        {
            anim.SetBool("Sheild", false);
            blocking = false;
            LevelMenager.canMove = true;
        }
    }
}
