using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float bulletSpeed;
    Rigidbody2D rb;
    Delay delay;
    PlayerHealthScript health;
    [SerializeField] ParticleSystem groundParticle;
    [SerializeField] ParticleSystem playerParticle;
    [SerializeField] ParticleSystem playerHitParticle;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        delay = GameObject.Find("Level Menager").GetComponent<Delay>();
        health = GameObject.Find("Level Menager").GetComponent<PlayerHealthScript>();
        

    }


    private void FixedUpdate()
    {
        rb.velocity = -transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(groundParticle, transform.position, Quaternion.identity);
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Movement.Cancel();
            health.Lives();
            Instantiate(playerParticle, transform.position, Quaternion.identity);
            Instantiate(playerHitParticle, transform.position, Quaternion.identity);

            if (delay.delayTime)
            {
                delay.StartDelayTime();
            }
        }
    }
}
