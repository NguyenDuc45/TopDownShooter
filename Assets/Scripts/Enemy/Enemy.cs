using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public new string name;
    public Sprite sprite;

    public float hitPoint;
    public float movementSpeed;

    public float damage;
    public float fireRate;
    public float bulletSpeed;

    public float defense;

    public float patrolDistance;
    public float patrolCooldown;
}
