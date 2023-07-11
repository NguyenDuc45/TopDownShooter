using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float hitPoint;
    [SerializeField]
    private float currentHitPoint;
    private float depleteHitPoint;
    public float movementSpeed;

    [SerializeField]
    private Weapon defaultWeapon;

    [Space]
    public string weaponName;
    public Sprite weaponSprite;
    public GameObject bullet;

    [Space]
    public float damage;
    public float fireRate;              //Bullet shots per second
    public float bulletSpeed;

    [Space]
    public float windUpTime;            //Time required to shoot after firing
    public float simultaneouslyShot;    //Number of shots firing simultaneously
    public float rapidShotTime;         //Time between each shot in the salvo
    public float shotsPerBurst;         //Number of shots firing at the same time
    public float spreadAngle;           //Accuracy

    [Space]
    public float knockBack;
    public float recoil;

    [Space]
    public float maximumEnergy;
    public float energyCost;            //Energy required per shot
    public float chargingTime;          //Amount of time (second) required to start charging energy after stopping shooting
    public float chargingSpeed;         //Amount of energy gained when charging per second

    #region FinalStats
    [System.NonSerialized] public float _hitPoint;
    [System.NonSerialized] public float _movementSpeed;
    [System.NonSerialized] public float _damage;
    [System.NonSerialized] public float _fireRate;              
    [System.NonSerialized] public float _bulletSpeed;
    [System.NonSerialized] public float _windUpTime;            
    [System.NonSerialized] public float _simultaneouslyShot;    
    [System.NonSerialized] public float _rapidShotTime;         
    [System.NonSerialized] public float _shotsPerBurst;         
    [System.NonSerialized] public float _spreadAngle;
    [System.NonSerialized] public float _knockBack;
    [System.NonSerialized] public float _recoil;
    [System.NonSerialized] public float _maximumEnergy;
    [System.NonSerialized] public float _energyCost;            
    [System.NonSerialized] public float _chargingTime;          
    [System.NonSerialized] public float _chargingSpeed;
    #endregion

    #region StatBonuses
    //fb: Flat Bonus
    [System.NonSerialized] public float fb_hitPoint;
    [System.NonSerialized] public float fb_movementSpeed;
    [System.NonSerialized] public float fb_damage;
    [System.NonSerialized] public float fb_fireRate;
    [System.NonSerialized] public float fb_bulletSpeed;
    [System.NonSerialized] public float fb_windUpTime;
    [System.NonSerialized] public float fb_simultaneouslyShot;
    [System.NonSerialized] public float fb_rapidShotTime;
    [System.NonSerialized] public float fb_shotsPerBurst;
    [System.NonSerialized] public float fb_spreadAngle;
    [System.NonSerialized] public float fb_knockBack;
    [System.NonSerialized] public float fb_recoil;
    [System.NonSerialized] public float fb_maximumEnergy;
    [System.NonSerialized] public float fb_energyCost;
    [System.NonSerialized] public float fb_chargingTime;
    [System.NonSerialized] public float fb_chargingSpeed;

    //pb: Percentage Bonus
    [System.NonSerialized] public float pb_hitPoint;
    [System.NonSerialized] public float pb_movementSpeed;
    [System.NonSerialized] public float pb_damage;
    [System.NonSerialized] public float pb_fireRate;
    [System.NonSerialized] public float pb_bulletSpeed;
    [System.NonSerialized] public float pb_windUpTime;
    [System.NonSerialized] public float pb_simultaneouslyShot;
    [System.NonSerialized] public float pb_rapidShotTime;
    [System.NonSerialized] public float pb_shotsPerBurst;
    [System.NonSerialized] public float pb_spreadAngle;
    [System.NonSerialized] public float pb_knockBack;
    [System.NonSerialized] public float pb_recoil;
    [System.NonSerialized] public float pb_maximumEnergy;
    [System.NonSerialized] public float pb_energyCost;
    [System.NonSerialized] public float pb_chargingTime;
    [System.NonSerialized] public float pb_chargingSpeed;
    #endregion

    public List<Weapon> weapons = new List<Weapon>();
    public int weaponLimit = 2;
    public int currentWeaponIndex = 0;

    WeaponController weaponController;
    PlayerShoot playerShoot;

    [Space]
    public StatBar hitPointBar;
    public StatBar depleteHitPointBar;
    public StatBar energyBar;
    public StatBar chargingCooldownBar;

    [Space]
    private bool isCollidingWithWeapon = false;

    private void Awake()
    {
        //Add the default weapon
        weapons.Add(defaultWeapon);
        ApplyWeapon(weapons[0]);
    }

    void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();

        //Set the player's HP to player's max HP
        currentHitPoint = CalculateStats(hitPoint, _hitPoint, fb_hitPoint, pb_hitPoint, true);
    }

    void Update()
    {
        ApplyStatBonuses();
        UpdateStatBars();
        SetDepleteHitPoint();
    }

    public void ApplyStatBonuses()
    {
        _hitPoint = CalculateStats(hitPoint, _hitPoint, fb_hitPoint, pb_hitPoint, true);
        _movementSpeed = CalculateStats(movementSpeed, _movementSpeed, fb_movementSpeed, pb_movementSpeed, false);
        _damage = CalculateStats(damage, _damage, fb_damage, pb_damage, false);
        _fireRate = CalculateStats(fireRate, _fireRate, fb_fireRate, pb_fireRate, false);
        _bulletSpeed = CalculateStats(bulletSpeed, _bulletSpeed, fb_bulletSpeed, pb_bulletSpeed, false);
        _windUpTime = CalculateStats(windUpTime, _windUpTime, fb_windUpTime, pb_windUpTime, false);
        _simultaneouslyShot = CalculateStats(simultaneouslyShot, _simultaneouslyShot, fb_simultaneouslyShot, pb_simultaneouslyShot, true);
        _rapidShotTime = CalculateStats(rapidShotTime, _rapidShotTime, fb_rapidShotTime, pb_rapidShotTime, false);
        _shotsPerBurst = CalculateStats(shotsPerBurst, _shotsPerBurst, fb_shotsPerBurst, pb_shotsPerBurst, true);
        _spreadAngle = CalculateStats(spreadAngle, _spreadAngle, fb_spreadAngle, pb_spreadAngle, false);
        _knockBack = CalculateStats(knockBack, _knockBack, fb_knockBack, pb_knockBack, false);
        _recoil = CalculateStats(recoil, _recoil, fb_recoil, pb_recoil, false);
        _maximumEnergy = CalculateStats(maximumEnergy, _maximumEnergy, fb_maximumEnergy, pb_maximumEnergy, true);
        _energyCost = CalculateStats(energyCost, _energyCost, fb_energyCost, pb_energyCost, true);
        _chargingTime = CalculateStats(chargingTime, _chargingTime, fb_chargingTime, pb_chargingTime, false);
        _chargingSpeed = CalculateStats(chargingSpeed, _chargingSpeed, fb_chargingSpeed, pb_chargingSpeed, false);
    }

    float CalculateStats(float bStat, float stat, float fbStat, float pbStat, bool isNeedToRound)
    {
        //bStat: Base Stat
        stat = (bStat + fbStat) * (1 + pbStat);

        if (isNeedToRound)
        {
            if (stat < bStat)
                stat = (int)stat;
            else stat = Mathf.Round(stat);
        }
        else stat = (float)Math.Round(stat, 2);

        return stat;
    }

    private void OnInteract(InputValue inputValue)
    {
        if (isCollidingWithWeapon)
            weaponController.GetWeapon();
    }

    private void OnChangeWeapon(InputValue inputValue)
    {
        if (weapons.Count >= 2)
        {
            currentWeaponIndex++;

            if (currentWeaponIndex == weapons.Count)
                currentWeaponIndex = 0;

            ApplyWeapon(weapons[currentWeaponIndex]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Weapon"))
        {
            isCollidingWithWeapon = true;
            weaponController = collision.GetComponent<WeaponController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Weapon"))
            isCollidingWithWeapon = false;
    }

    public void ApplyWeapon(Weapon weapon)
    {
        weaponName = weapon.name;

        weaponSprite = weapon.sprite;

        bullet = weapon.bullet;

        damage = weapon.damage;

        fireRate = weapon.fireRate;

        bulletSpeed = weapon.bulletSpeed;

        windUpTime = weapon.windUpTime;

        simultaneouslyShot = weapon.simultaneouslyShot;

        rapidShotTime = weapon.rapidShotTime;

        shotsPerBurst = weapon.shotsPerBurst;

        spreadAngle = weapon.spreadAngle;

        knockBack = weapon.knockBack;

        recoil = weapon.recoil;

        energyCost = weapon.energyCost;
    }

    public void UpdateStatBars()
    {
        hitPointBar.SetMaxValue(_hitPoint);
        depleteHitPointBar.SetMaxValue(_hitPoint);
        energyBar.SetMaxValue(_maximumEnergy);
        chargingCooldownBar.SetMaxValue(_chargingTime);

        hitPointBar.SetValue(currentHitPoint);
        depleteHitPointBar.SetValue(depleteHitPoint);
        energyBar.SetValue(playerShoot.currentEnergy);
        chargingCooldownBar.SetValue(playerShoot.currentChargingCooldown);

        Image energyBarFillImage = energyBar.transform.GetChild(1).GetComponent<Image>();
        var e_tempColor = energyBarFillImage.color;
        if (!playerShoot.isAbleToShoot)
        {
            e_tempColor.a = 0.5f;
            energyBarFillImage.color = e_tempColor;
        }
        else
        {
            e_tempColor.a = 1f;
            energyBarFillImage.color = e_tempColor;
        }
    }

    private void SetDepleteHitPoint()
    {
        if (depleteHitPoint < currentHitPoint)
            depleteHitPoint = currentHitPoint;
        else if (depleteHitPoint > currentHitPoint)
            depleteHitPoint -= Time.deltaTime * _hitPoint / 2;
    }
}
