using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landSound;
    [SerializeField] AudioClip deathbyFall;
    [SerializeField] AudioClip diebyEnemy;
    [SerializeField] AudioClip attackEnemySound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip runDoorSound;
    [SerializeField] AudioClip knifeSound;

    public AudioClip[] sounds;


    public static SoundManager instance; //Singleton

    private void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
            Debug.Log("Sahnede fazlada sound manager var");
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWithIndex(int index)
    {
        audioSource.PlayOneShot(sounds[index]);
    }


    void Update()
    {
        
    }

    public void JumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
        Debug.Log("Jump");
    }

    public void LandSound()
    {
        audioSource.PlayOneShot(landSound);
        Debug.Log("Land");
    }

    public void DeathbyFall()
    {
        audioSource.PlayOneShot(deathbyFall);
        Debug.Log("Fall");
    } 
    
    public void DiebyEnemy()
    {
        audioSource.PlayOneShot(diebyEnemy);
        Debug.Log("Die");
    }

    public void AttackEnemySound()
    {
        audioSource.PlayOneShot(attackEnemySound);
        Debug.Log("Attack");
    }

    public void WinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void RunDoorSound()
    {
        audioSource.PlayOneShot(runDoorSound);
    } 
    
    public void KnifeSound()
    {
        audioSource.PlayOneShot(knifeSound);
    }
}

