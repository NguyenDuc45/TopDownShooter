using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerShoot : MonoBehaviour
{
    public Player player;
    public PlayerMovement playerMovement;

    [SerializeField]
    private GameObject bulletPrefab;
    private float bulletTravelDistance;

    [SerializeField]
    private GameObject firePoint;

    private float timeBetweenShot;
    private float currentShootingCooldown = 0f;

    [Space]
    public float currentEnergy;
    public float currentChargingCooldown;

    private bool isShooting;
    public bool isAbleToShoot = true;
    private bool isWindingUp = false;

    #region PlayerStats
    [Space]
    public float damage;
    public float fireRate;
    public float bulletSpeed;
    public float energyCost;
    public float knockBack;
    public float stability;

    [Space]
    public float windUpTime;
    public float simultaneouslyShot;
    public float rapidShotTime;
    public float shotsPerBurst;
    public float spreadAngle;

    [Space]
    public float maximumEnergy;
    public float chargingTime; 
    public float chargingSpeed;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player.ApplyStatBonuses();
        currentEnergy = player._maximumEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting && isAbleToShoot && currentShootingCooldown <= 0)
        {
            Shoot();
        }

        GetPlayerStats();
        RechargeEnergy();

        if (currentShootingCooldown > 0)
            currentShootingCooldown -= Time.deltaTime;

        bulletTravelDistance = player.weapons[player.currentWeaponIndex].bulletTravelDistance;
    }

    void GetPlayerStats()
    {
        bulletPrefab = player.bullet;

        damage = player._damage;
        fireRate = player._fireRate;
        bulletSpeed = player._bulletSpeed;
        energyCost = player._energyCost;
        knockBack = player._knockBack;
        stability = player._stability;

        windUpTime = player._windUpTime;
        simultaneouslyShot = player._simultaneouslyShot;
        rapidShotTime = player._rapidShotTime;
        shotsPerBurst = player._shotsPerBurst;
        spreadAngle = player._spreadAngle;

        maximumEnergy = player._maximumEnergy;
        chargingTime = player._chargingTime;
        chargingSpeed = player._chargingSpeed;
    }

    private void OnFire(InputValue inputValue)
    {
        isShooting = inputValue.isPressed;
    }

    private void Shoot()
    {
        timeBetweenShot = 1 / fireRate;

        if (!isWindingUp)
            StartCoroutine(FireBullet());

        currentShootingCooldown = timeBetweenShot;
        currentChargingCooldown = chargingTime;
    }

    IEnumerator FireBullet()
    {
        isWindingUp = true;
        yield return new WaitForSeconds(windUpTime);

        //Apply Simultaneously Shooting
        for (int i = 0; i < simultaneouslyShot; i++)
        {
            //Apply Burst Shooting
            for (int j = 0; j < shotsPerBurst; j++)
            {
                float spread = Random.Range(-spreadAngle / 2, spreadAngle / 2);
                Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0, spread + playerMovement.angle));

                GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, bulletRotation);
                Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
                rb2d.velocity = bulletSpeed * bullet.transform.up;

                float damageFloor = (stability / (stability + 1000)) + 0.2f;
                float finalDamage = Random.Range(damage * damageFloor, damage);
                bullet.GetComponent<Bullet>().damage = (int)finalDamage;
                bullet.GetComponent<Bullet>().knockBack = knockBack;
                bullet.GetComponent<Bullet>().piercingCount = player.weapons[player.currentWeaponIndex].piercingCount;

                //Destroy(bullet, bulletTravelDistance / bulletSpeed);
                StartCoroutine(DestroyBullet(bullet, bulletTravelDistance / bulletSpeed));

                currentEnergy -= energyCost;

                //playerRb2d.AddForce(transform.up * -player.recoil * 100);
            }

            yield return new WaitForSeconds(rapidShotTime);
        }
             
        isWindingUp = false;
    }

    IEnumerator DestroyBullet(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);

        if (bullet != null)
            bullet.GetComponent<Bullet>().DestroyBullet();
    }

    private void RechargeEnergy()
    {
        if (currentEnergy < maximumEnergy && currentChargingCooldown <= 0f)
            currentEnergy += Time.deltaTime * chargingSpeed;

        if (currentEnergy > maximumEnergy)
        {
            currentEnergy = maximumEnergy;
            isAbleToShoot = true;
        }

        if (currentEnergy == maximumEnergy)
            isAbleToShoot = true;

        if (currentChargingCooldown > 0f  && !isWindingUp)
            currentChargingCooldown -= Time.deltaTime;

        if (currentEnergy <= 0f)
        {
            isAbleToShoot = false;
            currentEnergy = 0f;
        }
    }
}
