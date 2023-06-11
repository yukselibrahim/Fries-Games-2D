using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPos;
    bool moveEnemy = false;


    private void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (moveEnemy)
        {
            SpawnEnemy();
            moveEnemy = false;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPos.position, enemyPrefab.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveEnemy = true;
        }
    }


}
