using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] GameObject winPanel;
    //[SerializeField] GameObject runText;

    public static bool doorOpen;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winPanel.SetActive(true);

            //runText.SetActive(false);
            SoundManager.instance.RunDoorSound();
            collision.gameObject.SetActive(false);
            
        }
    }










}
