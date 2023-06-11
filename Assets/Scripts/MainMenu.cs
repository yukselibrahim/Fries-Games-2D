using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    private void Update()
    {
        ScoreManagerScript.highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = "High Score: " + ScoreManagerScript.highScore.ToString();
    }

    public void Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }







}
