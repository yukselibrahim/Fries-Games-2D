using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenager : MonoBehaviour
{
    
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawnPos;
    [SerializeField] GameObject RunText;
    [SerializeField] GameObject prefabFries;
    [SerializeField] GameObject door;

    [Header("Knife Spawner")]
    [SerializeField] GameObject knifePrefab;
    [SerializeField] Vector2 spawnValues;
    [SerializeField] float startSpawn;
    [SerializeField] float minSpawn;
    [SerializeField] float maxSpawn;
    [SerializeField] float startWait;
    public static bool knifeStop;
    private float xSpawn = 10f;

    [Header("Mode Spawn")]
    [SerializeField] float easySpawn;
    [SerializeField] float normalSpawn;
    [SerializeField] float hardSpawn;


    [Header("Bool")]
    public bool canWin;
    public static bool canMove = true;

    public int count;


    private void Awake()
    {
        PlayerSpawner();
    }

    private void Start()
    {
        
        FriesSpawnerCoroutine();
        StartCoroutine(CreateKnife());
        maxSpawn = HardenedScript.instance.HardenedLevel(maxSpawn, easySpawn, normalSpawn, hardSpawn);
        canMove = true;
        knifeStop = false;
    }


    void PlayerSpawner()
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
    }

    public void ReSpawnPlayer()
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
    }

    public void FriesSpawner()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-3.6f, 0), 0);
        Instantiate(prefabFries, spawnPos, Quaternion.identity);
    }

    IEnumerator SpawnFries()
    {
        if (count==3)
        {
            canWin = true;
            door.SetActive(true);
            knifeStop = true;
            RunText.SetActive(true);
            SoundManager.instance.WinSound();
        }

        yield return new WaitForSeconds(1.5f);

        if (count<3)
        {
            FriesSpawner();
        }
    }

    private IEnumerator CreateKnife()
    {
        yield return new WaitForSeconds(startWait);

        while (!knifeStop)
        {
            Vector2 spawnPos = new Vector2(xSpawn, Random.Range(-spawnValues.y, spawnValues.y));
            Instantiate(knifePrefab, spawnPos, Quaternion.identity);
            SoundManager.instance.KnifeSound();
            yield return new WaitForSeconds(startSpawn);
        }
    }

    public void FriesSpawnerCoroutine()
    {
        StartCoroutine(SpawnFries());
    }

    private void Update()
    {
        startSpawn = Random.Range(minSpawn, maxSpawn);
    }

    private void HardenedLevel()
    {
        if (PlayerPrefs.HasKey("Easy Mode"))
        {
            maxSpawn -= easySpawn;
        }
        else if (PlayerPrefs.HasKey("Normal Mode"))
        {
            maxSpawn = easySpawn;
        }
        else if (PlayerPrefs.HasKey("Hard Mode"))
        {
            maxSpawn += hardSpawn;
        }
    }




}
