using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManagerScript : MonoBehaviour
{
    //NOT: Singleton da script sadece tek bir objede ise kullanýlmalý.

    #region Singleton  
    public static ScoreManagerScript instance;
    

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] TextMeshProUGUI scoreText;


    public static int score = 0;
    public static int highScore;


    void Start()
    {
        scoreText.text = "Score : " + score.ToString();
    }

   
    void Update()
    {
        
    }

    public void AddPoint(int value)
    {
        score += value;
        scoreText.text = "Score : " + score.ToString();

        if (highScore<score)
        {
            PlayerPrefs.SetInt("High Score" , score);
        }
    }
}
