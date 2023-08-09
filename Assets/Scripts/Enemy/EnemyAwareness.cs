using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    private Transform player;

    public bool isAwareOfPlayer;
    public bool isStopping;
    public bool isRetreating;

    [SerializeField]
    private float awarenessDistance;
    [SerializeField]
    private float outOfSightDistance;
    [SerializeField]
    private float stoppingDistance;
    [SerializeField]
    private float retreatDistance;

    private void Awake()
    {
        player = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= awarenessDistance)
        {
            isAwareOfPlayer = true;
        }

        if (distance >= outOfSightDistance)
        {
            isAwareOfPlayer = false;
        }

        if (distance < stoppingDistance && distance > retreatDistance)
            isStopping = true;
        else isStopping = false;

        if (distance < retreatDistance)
            isRetreating = true;
        else isRetreating = false;
    }
}