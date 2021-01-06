using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject spawn7;
    public GameObject spawn8;
    public GameObject initSpawnPos;

    private GameObject[] enemy;
    private float timeSinceLastSpawn;
    private float spawnRate = 2f;
    private int currentEnemy = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = 0f;
        enemy = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            enemy[i] = Instantiate(enemyPrefab, initSpawnPos.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= spawnRate && currentEnemy < poolSize)
        {
            timeSinceLastSpawn = 0f;
            enemy[currentEnemy].transform.position = RandomPosition();
            currentEnemy++;
        }

    }
    public Vector3 RandomPosition()
    {
        Vector3 spawnPostition = new Vector3(0, 0);
        int minPos = 1;
        int maxPos = 9;
        int randomPos = Random.Range(minPos, maxPos);


        switch (randomPos)
        {
            case 1:
                spawnPostition = spawn1.transform.position;
                break;
            case 2:
                spawnPostition = spawn2.transform.position;
                break;
            case 3:
                spawnPostition = spawn3.transform.position;
                break;
            case 4:
                spawnPostition = spawn4.transform.position;
                break;
            case 5:
                spawnPostition = spawn5.transform.position;
                break;
            case 6:
                spawnPostition = spawn6.transform.position;
                break;
            case 7:
                spawnPostition = spawn7.transform.position;
                break;
            case 8:
                spawnPostition = spawn8.transform.position;
                break;
        }
        return spawnPostition;
    }
    /*public Color RandomColor()
    {
        return ColorUtility.;
    }*/
}
