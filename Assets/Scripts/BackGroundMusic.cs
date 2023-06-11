using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public static BackGroundMusic instance;

    
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("sahnede birden fazla backgrounmusic var");

        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        MuteMusic();
    }

    void MuteMusic()
    {
        if (PauseMenuScript.isPause)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }

      
    
}
