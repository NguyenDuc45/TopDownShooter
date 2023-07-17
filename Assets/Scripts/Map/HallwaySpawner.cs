using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwaySpawner : MonoBehaviour
{
    [SerializeField]
    private OpeningDirection openingDirection;
    private MapTemplate mapTemplate;
    private int rand;
    private GameObject spawnedHallway;

    private void Start()
    {
        mapTemplate = GameObject.FindWithTag("MapTemplate").GetComponent<MapTemplate>();
        Invoke("SpawnHallway", mapTemplate.generatingSpeed);
    }

    private void SpawnHallway()
    {
        if (openingDirection == OpeningDirection.Top)
        {
            rand = Random.Range(0, mapTemplate.topHallways.Length);
            spawnedHallway = Instantiate(mapTemplate.topHallways[rand], transform.position, mapTemplate.topHallways[rand].transform.rotation);
        }

        else if (openingDirection == OpeningDirection.Bottom)
        {
            rand = Random.Range(0, mapTemplate.bottomHallways.Length);
            spawnedHallway = Instantiate(mapTemplate.bottomHallways[rand], transform.position, mapTemplate.bottomHallways[rand].transform.rotation);
        }

        else if (openingDirection == OpeningDirection.Left)
        {
            rand = Random.Range(0, mapTemplate.leftHallways.Length);
            spawnedHallway = Instantiate(mapTemplate.leftHallways[rand], transform.position, mapTemplate.leftHallways[rand].transform.rotation);
        }

        else if (openingDirection == OpeningDirection.Right)
        {
            rand = Random.Range(0, mapTemplate.rightHallways.Length);
            spawnedHallway = Instantiate(mapTemplate.rightHallways[rand], transform.position, mapTemplate.rightHallways[rand].transform.rotation);
        }
    }
}
