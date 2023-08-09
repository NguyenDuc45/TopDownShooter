using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterController : MonoBehaviour
{
    [SerializeField]
    Booster booster;
    public string boosterName;
    public string boosterTooltip;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = booster.sprite;
        boosterName = booster.name;
        boosterTooltip = booster.toolTip;
    }

    public void AddBonuses(Player player)
    {
        if (booster.fb_hitPoint != 0)
            player.fb_hitPoint += booster.fb_hitPoint;

        if (booster.fb_movementSpeed != 0)
            player.fb_movementSpeed += booster.fb_movementSpeed;

        if (booster.fb_damage != 0)
            player.fb_damage += booster.fb_damage;

        if (booster.fb_fireRate != 0)
            player.fb_fireRate += booster.fb_fireRate;

        if (booster.fb_bulletSpeed != 0)
            player.fb_bulletSpeed += booster.fb_bulletSpeed;

        if (booster.fb_energyCost != 0)
            player.fb_energyCost += booster.fb_energyCost;

        if (booster.fb_knockBack != 0)
            player.fb_knockBack += booster.fb_knockBack;

        if (booster.fb_stability != 0)
            player.fb_stability += booster.fb_stability;

        if (booster.fb_defense != 0)
            player.fb_defense += booster.fb_defense;

        if (booster.fb_damageReduction != 0)
            player.fb_damageReduction += booster.fb_damageReduction;

        if (booster.fb_crit != 0)
            player.fb_crit += booster.fb_crit;

        if (booster.fb_critDamage != 0)
            player.fb_critDamage += booster.fb_critDamage;

        if (booster.fb_windUpTime != 0)
            player.fb_windUpTime += booster.fb_windUpTime;

        if (booster.fb_simultaneouslyShot != 0)
            player.fb_simultaneouslyShot += booster.fb_simultaneouslyShot;

        if (booster.fb_rapidShotTime != 0)
            player.fb_rapidShotTime += booster.fb_rapidShotTime;

        if (booster.fb_shotsPerBurst != 0)
            player.fb_shotsPerBurst += booster.fb_shotsPerBurst;

        if (booster.fb_spreadAngle != 0)
            player.fb_spreadAngle += booster.fb_spreadAngle;

        if (booster.fb_maximumEnergy != 0)
            player.fb_maximumEnergy += booster.fb_maximumEnergy;

        if (booster.fb_chargingTime != 0)
            player.fb_chargingTime += booster.fb_chargingTime;

        if (booster.fb_chargingSpeed != 0)
            player.fb_chargingSpeed += booster.fb_chargingSpeed;

        //-------//

        if (booster.pb_hitPoint != 0)
            player.pb_hitPoint += booster.pb_hitPoint;

        if (booster.pb_movementSpeed != 0)
            player.pb_movementSpeed += booster.pb_movementSpeed;

        if (booster.pb_damage != 0)
            player.pb_damage += booster.pb_damage;

        if (booster.pb_fireRate != 0)
            player.pb_fireRate += booster.pb_fireRate;

        if (booster.pb_bulletSpeed != 0)
            player.pb_bulletSpeed += booster.pb_bulletSpeed;

        if (booster.pb_energyCost != 0)
            player.pb_energyCost += booster.pb_energyCost;

        if (booster.pb_knockBack != 0)
            player.pb_knockBack += booster.pb_knockBack;

        if (booster.pb_stability != 0)
            player.pb_stability += booster.pb_stability;

        if (booster.pb_defense != 0)
            player.pb_defense += booster.pb_defense;

        if (booster.pb_damageReduction != 0)
            player.pb_damageReduction += booster.pb_damageReduction;

        if (booster.pb_crit != 0)
            player.pb_crit += booster.pb_crit;

        if (booster.pb_critDamage != 0)
            player.pb_critDamage += booster.pb_critDamage;

        if (booster.pb_windUpTime != 0)
            player.pb_windUpTime += booster.pb_windUpTime;

        if (booster.pb_simultaneouslyShot != 0)
            player.pb_simultaneouslyShot += booster.pb_simultaneouslyShot;

        if (booster.pb_rapidShotTime != 0)
            player.pb_rapidShotTime += booster.pb_rapidShotTime;

        if (booster.pb_shotsPerBurst != 0)
            player.pb_shotsPerBurst += booster.pb_shotsPerBurst;

        if (booster.pb_spreadAngle != 0)
            player.pb_spreadAngle += booster.pb_spreadAngle;

        if (booster.pb_maximumEnergy != 0)
            player.pb_maximumEnergy += booster.pb_maximumEnergy;

        if (booster.pb_chargingTime != 0)
            player.pb_chargingTime += booster.pb_chargingTime;

        if (booster.pb_chargingSpeed != 0)
            player.pb_chargingSpeed += booster.pb_chargingSpeed;

        Destroy(gameObject);
    }
}