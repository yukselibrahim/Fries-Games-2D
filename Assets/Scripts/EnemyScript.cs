using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float enemyAttackSpeed;
    [SerializeField] float xBoundry;
    [SerializeField] float yBoundry;
    LevelMenager levelManager;
    SoundManager soundManager;
    UIManager uiManager;
    Delay delayScript;
    PlayerHealthScript playerHealth;
    bool isAttacking;


    private void Awake()
    {
        levelManager = GameObject.Find("Level Menager").GetComponent<LevelMenager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        delayScript = GameObject.Find("Level Menager").GetComponent<Delay>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        playerHealth = GameObject.Find("Level Menager").GetComponent<PlayerHealthScript>();

    }


    private void Update()
    {
        EnemyDestroyer();
        
    }

    private void FixedUpdate()
    {
        EnemyAttack();
    }


    void EnemyAttack()
    {
        transform.Translate(-1 * enemyAttackSpeed * Time.deltaTime, 0, 0);
        

        while (!isAttacking)
        {
            soundManager.AttackEnemySound();
            Debug.Log("Test");
            isAttacking = true;
        }
    }

    void EnemyDestroyer()
    {
        if(transform.position.x < xBoundry || transform.position.y < yBoundry)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game over");
            
            Destroy(collision.gameObject);
            Movement.Cancel();
            playerHealth.Lives();

            if (delayScript.delayTime==true)
            {
                delayScript.StartDelayTime();
            }
            
            soundManager.DiebyEnemy();
            
           
           
        }
    }








}
