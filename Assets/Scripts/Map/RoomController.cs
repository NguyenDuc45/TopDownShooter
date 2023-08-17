using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    GameObject doors;
    GameObject[] pool;
    GameObject portal;
    EnemyPool enemyPool;
    MapTemplate mapTemplate;
    Transform player;

    bool isSpawned = false;
    public bool isBossRoom = false;
    float enemyCount;
    float distanceToPlayer;

    Vector3 spawnOffset;
    [SerializeField]
    int spawnCount = 5;
    int rand;

    public EnemyPoolName enemyPoolName;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemyPool = GameObject.FindWithTag("EnemyPool").GetComponent<EnemyPool>();
        mapTemplate = GameObject.FindWithTag("MapTemplate").GetComponent<MapTemplate>();
        doors = transform.Find("Grid/Doors").gameObject;
    }

    private void Start()
    {
        GetEnemyPool();
    }

    private void Update()
    {
        UpdateDoors();
        PlayerDistance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            enemyCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            enemyCount--;
    }

    private void UpdateDoors()
    {
        if (isSpawned == true && enemyCount > 0 && !doors.activeSelf)
            doors.SetActive(true);

        if (isSpawned == true && enemyCount == 0)
        {
            if (portal != null)
                portal.SetActive(true);
            doors.SetActive(false);
        }
    }

    private void GetEnemyPool()
    {
        if (enemyPoolName == EnemyPoolName.Pool1)
            pool = enemyPool.pool1;
        else if (enemyPoolName == EnemyPoolName.Pool2)
            pool = enemyPool.pool2;
        else if (enemyPoolName == EnemyPoolName.Pool3)
            pool = enemyPool.pool3;
    }

    private void PlayerDistance()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= 9.5f)
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        if (!isSpawned)
        {
            for (int i = 0; i < Random.Range(spawnCount - 1, spawnCount + 2); i++)
            {
                spawnOffset = new Vector3(Random.Range(-9, 9), Random.Range(-9, 9), 0);
                rand = Random.Range(0, pool.Length);

                GameObject newEnemy = Instantiate(pool[rand], transform.position + spawnOffset, Quaternion.identity);
                newEnemy.GetComponent<EnemyMovement>().roomCenter = transform.position;
            }

            if (isBossRoom)
            {
                GameObject boss = Instantiate(mapTemplate.boss, transform.position, Quaternion.identity);
                boss.GetComponent<EnemyMovement>().roomCenter = transform.position;

                portal = Instantiate(mapTemplate.portal, transform.position, Quaternion.identity);
                portal.SetActive(false);
            }

            isSpawned = true;
        }
    }
}
