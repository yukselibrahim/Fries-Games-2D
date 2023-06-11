using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText ;
    [SerializeField] TextMeshProUGUI highScoreText;


    Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        scoreText.text = "Your Score: " + ScoreManagerScript.score.ToString();
        ScoreManagerScript.highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = "You High Score: " + ScoreManagerScript.highScore.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canvas.enabled = false;
        ScoreManagerScript.score = 0;
        LevelMenager.knifeStop = false;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        ScoreManagerScript.score=0;
        LevelMenager.knifeStop = false;
    }
}
