using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{

    LevelMenager levelManager;
    [SerializeField] float delayTimer;
    public bool delayTime = true;

    public static Delay instance; //Singleton

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Sahnede fazlada delay var");
        }
        else
        {
            instance = this;
        }
    }


    void Start()
    {
        levelManager = GetComponent<LevelMenager>();
    }

    public void StartDelayTime()
    {
        StartCoroutine("DelayNewTime");
    }

    IEnumerator DelayNewTime()
    {
        yield return new WaitForSeconds(delayTimer);
        levelManager.ReSpawnPlayer();
    }
}
