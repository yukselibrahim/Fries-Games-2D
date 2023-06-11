using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] ParticleSystem particle;
    [SerializeField] float destroyLimit;

    private Rigidbody2D rb;

    [Header("Mode Speed")]
    [SerializeField] float easySpeed;
    [SerializeField] float normalSpeed;
    [SerializeField] float hardSpeed;
    

    void Start()
    {
        moveSpeed= HardenedScript.instance.HardenedLevel(moveSpeed, easySpeed,normalSpeed, hardSpeed);
        rb =GetComponent<Rigidbody2D>();
       
    }

   
    void Update()
    {
       

        if (transform.position.x<destroyLimit)
        {
            Destroy(gameObject);
        }
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(-transform.right * turnSpeed);
        rb.velocity = Vector2.left * moveSpeed;
    }

    private void HardenedLevel()
    {
        if (PlayerPrefs.HasKey("Easy Mode"))
        {
            moveSpeed -= easySpeed;
        }
        else if (PlayerPrefs.HasKey("Normal Mode"))
        {
            moveSpeed = easySpeed;
        }
        else if (PlayerPrefs.HasKey("Hard Mode"))
        {
            moveSpeed += hardSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.KnifeSound();
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            //LevelMenager.canMove = false;
            Destroy(collision.gameObject);
            //Animator anim = collision.gameObject.GetComponent<Animator>();
            //anim.SetTrigger("Die");
            PlayerHealthScript.instance.Lives();

            if (Delay.instance.delayTime)
            {
                Delay.instance.StartDelayTime();
            }

            
            //Movement.Cancel();
            Destroy(gameObject);
        }
    }


}
