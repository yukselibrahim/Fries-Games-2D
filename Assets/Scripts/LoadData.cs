using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadData : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI loadText;
    
   

    
    void Update()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            loadText.text ="Your Name is "+ PlayerPrefs.GetString("Name");
        }
        else
        {
            loadText.text = "There is no registered key";
        }
    }

    public void Delete()
    {
        PlayerPrefs.DeleteKey("Name");
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void Game()
    {
        SceneManager.LoadScene(2);
    }
    
}
