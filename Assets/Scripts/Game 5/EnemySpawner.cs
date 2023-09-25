using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float xLimit;
    [SerializeField] private float[] xPositions;
    //[SerializeField] private GameObject[] enemyPrefabs; //list //comment
    [SerializeField] private Wave[] wave;

    private float currentTime;  //calculate time passed since the wave started
    List<float> remainingPositions = new List<float>();
    private int waveIndex;  //which wave to spawn
    float xPos = 0; //position at which enemy will be spawned
    int rand;       //not asssiged private cuz these variables will be assigned private by default

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        remainingPositions.AddRange(xPositions);
    } 

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.StartMoving == true && MenuManager.instance.gameOver == false) //enemies will only spawn if the player starts moving AND when the game isn't over
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                SelectWave();
            }
        }
    }

    void SpawnEnemy(float xPos)
    {
        int r  = Random.Range(0, 4); //3 types
        //GameObject enemyObj = Instantiate(enemyPrefabs[r], new Vector3(xPos, transform.position.y, 0), Quaternion.identity); //comment
        string enemyName = "";

        switch (r)
        {
            case 0: enemyName = "Enemy1";
                break;
            case 1: enemyName = "Enemy2";
                break;
            case 2: enemyName = "Enemy3";
                break;
            case 3: enemyName = "Enemy4";
                break;
            default: enemyName = "Enemy";
                break;
        }

        GameObject enemy = ObjectPooling.instance.GetPooledObject(enemyName);
        enemy.transform.position = new Vector3(xPos, transform.position.y, 0);
        enemy.SetActive(true);
    }

    void SelectWave()
    {
        remainingPositions = new List<float>();
        remainingPositions.AddRange(xPositions);

        waveIndex = Random.Range(0, wave.Length);
        currentTime = wave[waveIndex].delayTime;

        if (wave[waveIndex].spawnAmount == 1)
        { //spawn 1 enemy
            xPos = Random.Range(-xLimit, xLimit);
        } else if (wave[waveIndex].spawnAmount > 1)
        {  //spawn more than 1 enemy
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);  //to avoid repeating positinos
        }

        for (int i = 0; i < wave[waveIndex].spawnAmount; i++)  //this method spawns enemies
        {
            SpawnEnemy(xPos);
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        }
    }
}

[System.Serializable]
public class Wave
{
    public float delayTime;
    public float spawnAmount;
}


//Enemy Spawner is a game object which indicates where the enemies will spawn from. it is placed at the top of the screen
//Code by Salma Elabsi