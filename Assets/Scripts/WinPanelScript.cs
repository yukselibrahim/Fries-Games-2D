using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinPanelScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private void Update()
    {
        scoreText.text = "Score : " + ScoreManagerScript.score.ToString();
    }

    public void NextLevel()
    {
        int scorePoint = ScoreManagerScript.score;
        scoreText.text = scorePoint.ToString();
        SceneManager.LoadScene(1);
        LevelMenager.canMove = true;
        LevelMenager.knifeStop = false;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }





}
