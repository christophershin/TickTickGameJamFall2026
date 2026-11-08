using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Sprite> sprites;
    public GameObject player;
    private float spawnRadius = 80;
    public GameObject enemyTicks;
    public int enemyHealthIncrease;

    private float enemyTimer;
    public float enemyTimerMax = 3;

    [Range(1,50)]
    public int SpawnAmountMax = 2;
    int spawnAmount;

    [Range(1,10)]
    public int enemyAmountPerSpawn = 2;


    int difficulty = 1;


    public float waveTimerMax = 10;
    float waveTimer;



    void Start()
    {
        waveTimer = waveTimerMax;
        spawnAmount = 0;
    }


    void Update()
    {
        difficultyManager();

        if (spawnAmount < SpawnAmountMax)
        {
            enemyTimer -= Time.deltaTime;


            if (enemyTimer <= 0)
            {
                spawnAmount += 1;
                SpawnEnemy();

                enemyTimer = enemyTimerMax;
            }

        }

    }


    void SpawnEnemy()
    {
        Vector2 spawnPos = (Vector2)player.transform.position + Random.insideUnitCircle.normalized * spawnRadius;

        for(int i=0; i<enemyAmountPerSpawn; i++)
        {
            spawnPos += new Vector2(Random.Range(-8, 8), Random.Range(-8, 8));

            GameObject tick = Instantiate(enemyTicks, spawnPos, Quaternion.identity);
            tick.GetOrAddComponent<SpriteRenderer>().sprite = sprites[random()];
            tick.GetComponent<Tick>().player = player;
            tick.GetComponent<Tick>().health *= enemyHealthIncrease*difficulty;
            tick.GetComponent<Tick>().damage += difficulty;
            tick.GetComponent<Tick>().moveSpeed += (difficulty/20);
        }
    }


    void difficultyManager()
    {
        waveTimer -= Time.deltaTime;

        if (waveTimer <= 0)
        {
            difficulty += 1;

            waveTimer = waveTimerMax;
            enemyAmountPerSpawn += difficulty;
            SpawnAmountMax += difficulty;
            spawnAmount = 0;
        }
    }


    int random()
    {

        int rand = Random.Range(0, sprites.Count);

        return rand;
    }

}
