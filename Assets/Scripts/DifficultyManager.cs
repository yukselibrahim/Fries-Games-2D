using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{

    [HideInInspector] //Inspector kýsmýnda göstermiyor.
    public bool easyMode, normalMode, hardMode;



    void Start()
    {
        PlayerPrefs.DeleteKey("Easy Mode");
        PlayerPrefs.DeleteKey("Normal Mode");
        PlayerPrefs.DeleteKey("Hard Mode");

        easyMode = false;
        normalMode = false;
        hardMode = false;
    }

    public void EasyMode()
    {
        easyMode = true;
        PlayerPrefs.SetInt("Easy Mode", easyMode ? 1 : 0);
        SceneManager.LoadScene(1);
        
    } 
    
    public void NormalMode()
    {
        normalMode = true;
        PlayerPrefs.SetInt("Normal Mode", easyMode ? 1 : 0);
        SceneManager.LoadScene(1);
    }

    public void HardMode()
    {
        hardMode = true;
        PlayerPrefs.SetInt("Hard Mode", easyMode ? 1 : 0);
        SceneManager.LoadScene(1);
    }

}
