using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField]
    private OpeningDirection openingDirection;
    private MapTemplate mapTemplate;
    private int rand;
    public bool isSpawned = false;
    private GameObject spawnedRoom;

    private void Start()
    {
        mapTemplate = GameObject.FindWithTag("MapTemplate").GetComponent<MapTemplate>();
        Invoke("SpawnRoom", mapTemplate.generatingSpeed);
    }

    private void SpawnRoom()
    {
        if (!isSpawned)
        {
            if (mapTemplate.currentMultRoomCount < mapTemplate.maxMultRoomCount)
            {
                if (openingDirection == OpeningDirection.Bottom)
                {
                    rand = Random.Range(0, mapTemplate.mBottomRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.mBottomRooms[rand], transform.position, mapTemplate.mBottomRooms[rand].transform.rotation);
                    Destroy(spawnedRoom.transform.Find("Hallway Spawners/Bottom").gameObject);
                }
                else if (openingDirection == OpeningDirection.Top)
                {
                    rand = Random.Range(0, mapTemplate.mTopRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.mTopRooms[rand], transform.position, mapTemplate.mTopRooms[rand].transform.rotation);
                    Destroy(spawnedRoom.transform.Find("Hallway Spawners/Top").gameObject);
                }
                else if (openingDirection == OpeningDirection.Left)
                {
                    rand = Random.Range(0, mapTemplate.mLeftRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.mLeftRooms[rand], transform.position, mapTemplate.mLeftRooms[rand].transform.rotation);
                    Destroy(spawnedRoom.transform.Find("Hallway Spawners/Left").gameObject);
                }
                else if (openingDirection == OpeningDirection.Right)
                {
                    rand = Random.Range(0, mapTemplate.mRightRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.mRightRooms[rand], transform.position, mapTemplate.mRightRooms[rand].transform.rotation);
                    Destroy(spawnedRoom.transform.Find("Hallway Spawners/Right").gameObject);
                }

                mapTemplate.currentMultRoomCount++;
                isSpawned = true;
            }

            else
            {
                if (openingDirection == OpeningDirection.Bottom)
                {
                    rand = Random.Range(0, mapTemplate.sBottomRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.sBottomRooms[rand], transform.position, mapTemplate.sBottomRooms[rand].transform.rotation);
                }
                else if (openingDirection == OpeningDirection.Top)
                {
                    rand = Random.Range(0, mapTemplate.sTopRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.sTopRooms[rand], transform.position, mapTemplate.sTopRooms[rand].transform.rotation);
                }
                else if (openingDirection == OpeningDirection.Left)
                {
                    rand = Random.Range(0, mapTemplate.sLeftRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.sLeftRooms[rand], transform.position, mapTemplate.sLeftRooms[rand].transform.rotation);
                }
                else if (openingDirection == OpeningDirection.Right)
                {
                    rand = Random.Range(0, mapTemplate.sRightRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.sRightRooms[rand], transform.position, mapTemplate.sRightRooms[rand].transform.rotation);
                }

                isSpawned = true;
            }

            mapTemplate.rooms.Add(spawnedRoom);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RoomSpawner"))
        {
            RoomSpawner other = collision.GetComponent<RoomSpawner>();
            Debug.Log("UwU");

            if (isSpawned == false && other.isSpawned == false)
            {
                if ((openingDirection == OpeningDirection.Top && other.openingDirection == OpeningDirection.Bottom)
                    || (openingDirection == OpeningDirection.Bottom && other.openingDirection == OpeningDirection.Top))
                {
                    // Need to spawn a room with a bottom door and a top door
                    rand = Random.Range(0, mapTemplate.TBRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.TBRooms[rand], transform.position, mapTemplate.TBRooms[rand].transform.rotation);
                }
                else if ((openingDirection == OpeningDirection.Bottom && other.openingDirection == OpeningDirection.Left)
                    || (openingDirection == OpeningDirection.Left && other.openingDirection == OpeningDirection.Bottom))
                {
                    // Need to spawn a room with a bottom door and a left door
                    rand = Random.Range(0, mapTemplate.LBRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.LBRooms[rand], transform.position, mapTemplate.LBRooms[rand].transform.rotation);
                }
                else if ((openingDirection == OpeningDirection.Bottom && other.openingDirection == OpeningDirection.Right)
                    || (openingDirection == OpeningDirection.Right && other.openingDirection == OpeningDirection.Bottom))
                {
                    // Need to spawn a room with a bottom door and a right door
                    rand = Random.Range(0, mapTemplate.RBRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.RBRooms[rand], transform.position, mapTemplate.RBRooms[rand].transform.rotation);
                }
                else if ((openingDirection == OpeningDirection.Top && other.openingDirection == OpeningDirection.Left)
                    || (openingDirection == OpeningDirection.Left && other.openingDirection == OpeningDirection.Top))
                {
                    // Need to spawn a room with a top door and a left door
                    rand = Random.Range(0, mapTemplate.TLRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.TLRooms[rand], transform.position, mapTemplate.TLRooms[rand].transform.rotation);
                }
                else if ((openingDirection == OpeningDirection.Top && other.openingDirection == OpeningDirection.Right)
                    || (openingDirection == OpeningDirection.Right && other.openingDirection == OpeningDirection.Top))
                {
                    // Need to spawn a room with a top door and a right door
                    rand = Random.Range(0, mapTemplate.TRRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.TRRooms[rand], transform.position, mapTemplate.TRRooms[rand].transform.rotation);
                }
                else if ((openingDirection == OpeningDirection.Left && other.openingDirection == OpeningDirection.Right)
                    || (openingDirection == OpeningDirection.Right && other.openingDirection == OpeningDirection.Left))
                {
                    // Need to spawn a room with a left door and a right door
                    rand = Random.Range(0, mapTemplate.LRRooms.Length);
                    spawnedRoom = Instantiate(mapTemplate.LRRooms[rand], transform.position, mapTemplate.LRRooms[rand].transform.rotation);
                }

                mapTemplate.rooms.Add(spawnedRoom);

                GameObject temp = spawnedRoom.transform.Find("Hallway Spawners").gameObject;
                if (temp != null)
                    Destroy(temp);

                isSpawned = true;
                other.isSpawned = true;
            }
        }

        if (collision.CompareTag("RoomCenter"))
        {
            isSpawned = true;
        }
    }
}
