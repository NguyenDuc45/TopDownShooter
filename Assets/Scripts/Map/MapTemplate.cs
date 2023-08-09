using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTemplate : MonoBehaviour
{
    public int currentMultRoomCount = 1;
    public int maxMultRoomCount = 7;
    public float generatingSpeed = 0.1f;
    public float timeBeforeSpawningBoss = 4f;
    private bool isSpawnedBoss = false;
    private bool isSpawnedWeapon = false;
    public GameObject boss;
    WeaponPool weaponPool;

    [Space]
    public List<GameObject> rooms;

    [Space]
    public GameObject initialRoom;

    [Space] [Header("Multiway Rooms")] [Space]
    public GameObject[] mBottomRooms;
    public GameObject[] mTopRooms;
    public GameObject[] mLeftRooms;
    public GameObject[] mRightRooms;

    [Space] [Header("Singleway Rooms")] [Space]
    public GameObject[] sBottomRooms;
    public GameObject[] sTopRooms;
    public GameObject[] sLeftRooms;
    public GameObject[] sRightRooms;

    [Space][Header("Hallways")][Space]
    public GameObject[] bottomHallways;
    public GameObject[] topHallways;
    public GameObject[] leftHallways;
    public GameObject[] rightHallways;

    [Space] [Header("Filler Rooms")] [Space]
    public GameObject[] TLRooms;
    public GameObject[] TRRooms;
    public GameObject[] TBRooms;
    public GameObject[] LRRooms;
    public GameObject[] LBRooms;
    public GameObject[] RBRooms;

    void Start()
    {
        rooms.Add(initialRoom);
        weaponPool = GameObject.FindGameObjectWithTag("WeaponPool").GetComponent<WeaponPool>();
    }

    void Update()
    {
        SpawnBossAndItem();
    }

    private void SpawnBossAndItem()
    {
        if (timeBeforeSpawningBoss <= 0f)
        {
            if (!isSpawnedBoss)
            {
                GameObject lastRoom = rooms[rooms.Count - 1];
                //Instantiate(boss, lastRoom.transform.position, Quaternion.identity);
                isSpawnedBoss = true;
            }

            if (!isSpawnedWeapon)
            {
                int randWeapon = Random.Range(0, weaponPool.pool1.Length);
                GameObject randRoom = rooms[Random.Range(1, rooms.Count)];
                Instantiate(weaponPool.pool1[randWeapon], randRoom.transform.position, Quaternion.identity);
                isSpawnedWeapon = true;
            }

        }
        else timeBeforeSpawningBoss -= Time.deltaTime;
    }
}

public enum OpeningDirection
{
    Top,
    Bottom,
    Left,
    Right,
}