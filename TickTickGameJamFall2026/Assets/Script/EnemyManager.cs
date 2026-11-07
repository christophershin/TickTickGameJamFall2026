using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject player;
    private float spawnRadius = 80;
    public GameObject enemyTicks;

    private float enemyTimer;
    public float enemyTimerMax = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        enemyTimer -= Time.deltaTime;


        if(enemyTimer<=0)
        {
            SpawnEnemy();

            enemyTimer = enemyTimerMax;
        }
        
    }


    void SpawnEnemy()
    {
        Vector2 spawnPos = (Vector2)player.transform.position + Random.insideUnitCircle.normalized * spawnRadius;

        GameObject tick = Instantiate(enemyTicks, spawnPos, Quaternion.identity);
        tick.GetComponent<Tick>().player = player; 
    }
}
