using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTemplate : MonoBehaviour
{
    public int currentMultRoomCount = 1;
    public int maxMultRoomCount = 7;
    public float generatingSpeed = 0.1f;

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
    }
}

public enum OpeningDirection
{
    Top,
    Bottom,
    Left,
    Right,
}