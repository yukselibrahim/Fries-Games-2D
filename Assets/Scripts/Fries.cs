using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : MonoBehaviour
{
    private int friesValue;
    LevelMenager levelMenager;


    private void Awake()
    {
        levelMenager = GameObject.Find("Level Menager").GetComponent<LevelMenager>();
    }

    private void Start()
    {
        friesValue = Random.Range(1, 10);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelMenager.count++;
            ScoreManagerScript.instance.AddPoint(friesValue);
            Destroy(gameObject);
            levelMenager.FriesSpawnerCoroutine();
        }
    }
}
