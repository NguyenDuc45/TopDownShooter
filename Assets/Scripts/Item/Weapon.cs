using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class Weapon : Item
{
    public GameObject bullet;

    [Space]
    public float damage;
    public float fireRate;              //Bullet shots per second
    public float bulletSpeed;
    public float energyCost;            //Energy required per shot
    public float knockBack;

    [Space]
    public float windUpTime;            //Time required to shoot after firing
    public float simultaneouslyShot;    //Number of shots firing simultaneously
    public float rapidShotTime;         //Time between each shot in the salvo
    public float shotsPerBurst;         //Number of shots firing at the same time
    public float spreadAngle;           //Accuracy
}