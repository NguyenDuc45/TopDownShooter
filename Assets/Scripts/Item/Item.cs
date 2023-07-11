using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    /*Player player;

    #region Stats
    public float fb_hitPoints;
    public float fb_movementSpeed;

    [Space]
    public float fb_damage;
    public float fb_fireRate;
    public float fb_bulletSpeed;

    [Space]
    public float fb_windUpTime;
    public float fb_simultaneouslyShot;
    public float fb_rapidShotTime;
    public float fb_shotsPerBurst;
    public float fb_spreadAngle;

    [Space]
    public float fb_knockBack;
    public float fb_recoil;

    [Space]
    public float fb_maximumEnergy;
    public float fb_energyCost;
    public float fb_chargingTime;
    public float fb_chargingSpeed;

    [Space]
    [Space]
    public float pb_hitPoints;
    public float pb_movementSpeed;

    [Space]
    public float pb_damage;
    public float pb_fireRate;
    public float pb_bulletSpeed;

    [Space]
    public float pb_windUpTime;
    public float pb_simultaneouslyShot;
    public float pb_rapidShotTime;
    public float pb_shotsPerBurst;
    public float pb_spreadAngle;

    [Space]
    public float pb_knockBack;
    public float pb_recoil;

    [Space]
    public float pb_maximumEnergy;
    public float pb_energyCost;
    public float pb_chargingTime;
    public float pb_chargingSpeed;
    #endregion

    void AddBonuses(Player player)
    {
        if (fb_hitPoints != 0)
            player.fb_hitPoints += fb_hitPoints;

        if (fb_movementSpeed != 0)
            player.fb_movementSpeed += fb_movementSpeed;

        if (fb_damage != 0)
            player.fb_damage += fb_damage;

        if (fb_fireRate != 0)
            player.fb_fireRate += fb_fireRate;

        if (fb_bulletSpeed != 0)
            player.fb_bulletSpeed += fb_bulletSpeed;

        if (fb_windUpTime != 0)
            player.fb_windUpTime += fb_windUpTime;

        if (fb_simultaneouslyShot != 0)
            player.fb_simultaneouslyShot += fb_simultaneouslyShot;

        if (fb_rapidShotTime != 0)
            player.fb_rapidShotTime += fb_rapidShotTime;

        if (fb_shotsPerBurst != 0)
            player.fb_shotsPerBurst += fb_shotsPerBurst;

        if (fb_spreadAngle != 0)
            player.fb_spreadAngle += fb_spreadAngle;

        if (fb_knockBack != 0)
            player.fb_knockBack += fb_knockBack;

        if (fb_recoil != 0)
            player.fb_recoil += fb_recoil;

        if (fb_maximumEnergy != 0)
            player.fb_maximumEnergy += fb_maximumEnergy;

        if (fb_energyCost != 0)
            player.fb_energyCost += fb_energyCost;

        if (fb_chargingTime != 0)
            player.fb_chargingTime += fb_chargingTime;

        if (fb_chargingSpeed != 0)
            player.fb_chargingSpeed += fb_chargingSpeed;

        //-------//

        if (pb_hitPoints != 0)
            player.pb_hitPoints += pb_hitPoints;

        if (pb_movementSpeed != 0)
            player.pb_movementSpeed += pb_movementSpeed;

        if (pb_damage != 0)
            player.pb_damage += pb_damage;

        if (pb_fireRate != 0)
            player.pb_fireRate += pb_fireRate;

        if (pb_bulletSpeed != 0)
            player.pb_bulletSpeed += pb_bulletSpeed;

        if (pb_windUpTime != 0)
            player.pb_windUpTime += pb_windUpTime;

        if (pb_simultaneouslyShot != 0)
            player.pb_simultaneouslyShot += pb_simultaneouslyShot;

        if (pb_rapidShotTime != 0)
            player.pb_rapidShotTime += pb_rapidShotTime;

        if (pb_shotsPerBurst != 0)
            player.pb_shotsPerBurst += pb_shotsPerBurst;

        if (pb_spreadAngle != 0)
            player.pb_spreadAngle += pb_spreadAngle;

        if (pb_knockBack != 0)
            player.pb_knockBack += pb_knockBack;

        if (pb_recoil != 0)
            player.pb_recoil += pb_recoil;

        if (pb_maximumEnergy != 0)
            player.pb_maximumEnergy += pb_maximumEnergy;

        if (pb_energyCost != 0)
            player.pb_energyCost += pb_energyCost;

        if (pb_chargingTime != 0)
            player.pb_chargingTime += pb_chargingTime;

        if (pb_chargingSpeed != 0)
            player.pb_chargingSpeed += pb_chargingSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player>();
            AddBonuses(player);

            Destroy(gameObject);
        }
    }*/

    public new string name;
    public Sprite sprite;
}
