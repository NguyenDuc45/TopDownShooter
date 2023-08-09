using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject[] pool1;
    public GameObject[] pool2;
    public GameObject[] pool3;
}

public enum EnemyPoolName
{
    Pool1,
    Pool2,
    Pool3,
}