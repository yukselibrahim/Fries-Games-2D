using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    UIManager uiManager;
    [SerializeField] Image[] playerHealthIcons;
    [SerializeField] int playerLifeCount = 3;
    Delay delay;

    public static PlayerHealthScript instance;  //Singleton

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Sahnede fazlada player health var");
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        delay = GameObject.Find("Level Menager").GetComponent<Delay>();
    }

    public void Lives()
    {
        playerLifeCount--;
        Destroy(playerHealthIcons[playerLifeCount]);

        if (playerLifeCount<1)
        {
            uiManager.GetComponent<Canvas>().enabled = true;
            LevelMenager.knifeStop = true;
            delay.delayTime = false;
        }
    }

   
    void Update()
    {
        
    }
}
