using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private EnemyController enemyController;
    private EnemyAwareness enemyAwareness;

    private float currentPatrolCooldown = 0;
    private float randX;
    private float randY;
    [SerializeField]
    private Vector3 randomSpot;
    public Vector3 roomCenter;

    [SerializeField]
    private float rotationSpeed;

    private void Awake()
    {
        player = FindObjectOfType<Player>().transform;
        enemyController = GetComponent<EnemyController>();
        enemyAwareness = GetComponent<EnemyAwareness>();

        currentPatrolCooldown = Random.Range(0, enemyController.patrolCooldown);
        randomSpot = transform.position;
    }

    private void FixedUpdate()
    {
        /*UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();*/

        Movement();
        Patrol();
    }

    /*private void UpdateTargetDirection()
    {
        if (enemyAwareness.isAwareOfPlayer)
        {
            targetDirection = enemyAwareness.directionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (targetDirection == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = transform.up * enemyController.movementSpeed;
        }
    }*/

    private void Movement()
    {
        if (enemyAwareness.isAwareOfPlayer)
        {
            if (!enemyAwareness.isStopping && !enemyAwareness.isRetreating)
                transform.position = Vector2.MoveTowards(transform.position, player.position, enemyController.movementSpeed * Time.deltaTime);

            else if (enemyAwareness.isRetreating)
                transform.position = Vector2.MoveTowards(transform.position, player.position, -enemyController.movementSpeed * Time.deltaTime);
        }
    }

    private void Patrol()
    {
        if (!enemyAwareness.isAwareOfPlayer)
        {
            if (currentPatrolCooldown <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, randomSpot, enemyController.movementSpeed * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, randomSpot) <= 0.2f)
            {
                do
                {
                    randX = Random.Range(transform.position.x - enemyController.patrolDistance, transform.position.x + enemyController.patrolDistance);
                    randY = Random.Range(transform.position.y - enemyController.patrolDistance, transform.position.y + enemyController.patrolDistance);
                } while (Vector2.Distance(new Vector3(randX, randY, roomCenter.z), roomCenter) > 19);

                randomSpot = new Vector3(randX, randY, transform.position.z);

                currentPatrolCooldown = enemyController.patrolCooldown;
            }

            if (currentPatrolCooldown > 0)
                currentPatrolCooldown -= Time.deltaTime;
        }
    }
}