using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float hitPoint;
    private float tempHitPoint;
    public float currentHitPoint;
    public float movementSpeed;

    [SerializeField]
    private Weapon defaultWeapon;
    public SkillType skillType;

    [Space]
    public string weaponName;
    public Sprite weaponSprite;
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

    [Space]
    public float maximumEnergy;
    private float tempEnergy;
    public float chargingTime;          //Amount of time (second) required to start charging energy after stopping shooting
    public float chargingSpeed;         //Amount of energy gained when charging per second

    #region FinalStats
    [NonSerialized] public float _hitPoint;
    [NonSerialized] public float _movementSpeed;

    [NonSerialized] public float _damage;
    [NonSerialized] public float _fireRate;              
    [NonSerialized] public float _bulletSpeed;
    [NonSerialized] public float _energyCost;
    [NonSerialized] public float _knockBack;

    [NonSerialized] public float _windUpTime;            
    [NonSerialized] public float _simultaneouslyShot;    
    [NonSerialized] public float _rapidShotTime;         
    [NonSerialized] public float _shotsPerBurst;         
    [NonSerialized] public float _spreadAngle;

    [NonSerialized] public float _maximumEnergy;        
    [NonSerialized] public float _chargingTime;          
    [NonSerialized] public float _chargingSpeed;
    #endregion

    #region StatBonuses
    //fb: Flat Bonus
    [NonSerialized] public float fb_hitPoint;
    [NonSerialized] public float fb_movementSpeed;

    [NonSerialized] public float fb_damage;
    [NonSerialized] public float fb_fireRate;
    [NonSerialized] public float fb_bulletSpeed;
    [NonSerialized] public float fb_energyCost;
    [NonSerialized] public float fb_knockBack;

    [NonSerialized] public float fb_windUpTime;
    [NonSerialized] public float fb_simultaneouslyShot;
    [NonSerialized] public float fb_rapidShotTime;
    [NonSerialized] public float fb_shotsPerBurst;
    [NonSerialized] public float fb_spreadAngle;

    [NonSerialized] public float fb_maximumEnergy;
    [NonSerialized] public float fb_chargingTime;
    [NonSerialized] public float fb_chargingSpeed;

    //pb: Percentage Bonus
    [NonSerialized] public float pb_hitPoint;
    [NonSerialized] public float pb_movementSpeed;

    [NonSerialized] public float pb_damage;
    [NonSerialized] public float pb_fireRate;
    [NonSerialized] public float pb_bulletSpeed;
    [NonSerialized] public float pb_energyCost;
    [NonSerialized] public float pb_knockBack;

    [NonSerialized] public float pb_windUpTime;
    [NonSerialized] public float pb_simultaneouslyShot;
    [NonSerialized] public float pb_rapidShotTime;
    [NonSerialized] public float pb_shotsPerBurst;
    [NonSerialized] public float pb_spreadAngle;

    [NonSerialized] public float pb_maximumEnergy;
    [NonSerialized] public float pb_chargingTime;
    [NonSerialized] public float pb_chargingSpeed;
    #endregion

    [Space]
    public List<Weapon> weapons = new List<Weapon>();
    public int weaponLimit = 2;
    public int currentWeaponIndex = 0;

    [NonSerialized] public WeaponController weaponController;
    [NonSerialized] public BoosterController boosterController;
    PlayerShoot playerShoot;
    PlayerSkill playerSkill;

    [Space]
    public bool isCollidingWithWeapon = false;
    public bool isCollidingWithBooster = false;

    private void Awake()
    {
        //Add the default weapon
        weapons.Add(defaultWeapon);
        ApplyWeapon(weapons[0]);
    }

    void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
        playerSkill = GetComponent<PlayerSkill>();

        //Set the player's HP/Energy to player's max HP/Energy
        currentHitPoint = CalculateStats(hitPoint, _hitPoint, fb_hitPoint, pb_hitPoint, true);
        tempHitPoint = currentHitPoint;
        playerShoot.currentEnergy = CalculateStats(hitPoint, _hitPoint, fb_hitPoint, pb_hitPoint, true);
        tempHitPoint = playerShoot.currentEnergy;
    }

    void Update()
    {
        ApplyStatBonuses();
        HPAndEnergyScaling();
    }

    private void OnInteract(InputValue inputValue)
    {
        if (isCollidingWithWeapon)
            weaponController.GetWeapon();

        else if (isCollidingWithBooster)
            boosterController.AddBonuses(this);
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

    private void OnSkill(InputValue inputValue)
    {
        playerSkill.UseSkill(skillType);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Weapon"))
        {
            isCollidingWithWeapon = true;
            weaponController = collision.GetComponent<WeaponController>();
        }

        if (collision.tag.Equals("Booster"))
        {
            isCollidingWithBooster = true;
            boosterController = collision.GetComponent<BoosterController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Weapon"))
            isCollidingWithWeapon = false;

        if (collision.tag.Equals("Booster"))
        {
            isCollidingWithBooster = false;
        }
    }

    public void ApplyStatBonuses()
    {
        _hitPoint = CalculateStats(hitPoint, _hitPoint, fb_hitPoint, pb_hitPoint, true);
        _movementSpeed = CalculateStats(movementSpeed, _movementSpeed, fb_movementSpeed, pb_movementSpeed, false);

        _damage = CalculateStats(damage, _damage, fb_damage, pb_damage, false);
        _fireRate = CalculateStats(fireRate, _fireRate, fb_fireRate, pb_fireRate, false);
        _bulletSpeed = CalculateStats(bulletSpeed, _bulletSpeed, fb_bulletSpeed, pb_bulletSpeed, false);
        _energyCost = CalculateStats(energyCost, _energyCost, fb_energyCost, pb_energyCost, true);
        _knockBack = CalculateStats(knockBack, _knockBack, fb_knockBack, pb_knockBack, false);

        _windUpTime = CalculateStats(windUpTime, _windUpTime, fb_windUpTime, pb_windUpTime, false);
        _simultaneouslyShot = CalculateStats(simultaneouslyShot, _simultaneouslyShot, fb_simultaneouslyShot, pb_simultaneouslyShot, true);
        _rapidShotTime = CalculateStats(rapidShotTime, _rapidShotTime, fb_rapidShotTime, pb_rapidShotTime, false);
        _shotsPerBurst = CalculateStats(shotsPerBurst, _shotsPerBurst, fb_shotsPerBurst, pb_shotsPerBurst, true);
        _spreadAngle = CalculateStats(spreadAngle, _spreadAngle, fb_spreadAngle, pb_spreadAngle, false);

        _maximumEnergy = CalculateStats(maximumEnergy, _maximumEnergy, fb_maximumEnergy, pb_maximumEnergy, true);
        _chargingTime = CalculateStats(chargingTime, _chargingTime, fb_chargingTime, pb_chargingTime, false);
        _chargingSpeed = CalculateStats(chargingSpeed, _chargingSpeed, fb_chargingSpeed, pb_chargingSpeed, false);
    }

    private float CalculateStats(float bStat, float stat, float fbStat, float pbStat, bool isNeedToRound)
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

    public void ApplyWeapon(Weapon weapon)
    {
        weaponName = weapon.name;

        weaponSprite = weapon.sprite;

        bullet = weapon.bullet;

        damage = weapon.damage;

        fireRate = weapon.fireRate;

        bulletSpeed = weapon.bulletSpeed;

        energyCost = weapon.energyCost;

        knockBack = weapon.knockBack;

        windUpTime = weapon.windUpTime;

        simultaneouslyShot = weapon.simultaneouslyShot;

        rapidShotTime = weapon.rapidShotTime;

        shotsPerBurst = weapon.shotsPerBurst;

        spreadAngle = weapon.spreadAngle;
    }

    private void HPAndEnergyScaling()
    {
        //HP
        if (tempHitPoint != _hitPoint)
        {
            float t = _hitPoint - tempHitPoint;

            if (t > 0)
                currentHitPoint += t;

            tempHitPoint = _hitPoint;
        }

        if (currentHitPoint > _hitPoint)
            currentHitPoint = _hitPoint;

        //Energy
        if (tempEnergy != _maximumEnergy)
        {
            float t = _maximumEnergy - tempEnergy;

            if (t > 0)
                playerShoot.currentEnergy += t;

            tempEnergy = _maximumEnergy;
        }

        if (playerShoot.currentEnergy > _maximumEnergy)
            playerShoot.currentEnergy = _maximumEnergy;
    }
}
