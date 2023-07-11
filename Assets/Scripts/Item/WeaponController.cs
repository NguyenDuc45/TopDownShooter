using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    Player player;
    [SerializeField]
    Weapon weapon;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = weapon.sprite;
    }

    public void GetWeapon()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player>();

        if (player.weapons.Count < player.weaponLimit)
        {
            //Immediatelly apply the new weapon
            player.weapons.Add(weapon);
            player.currentWeaponIndex++;
            player.ApplyWeapon(player.weapons[player.currentWeaponIndex]);

            Destroy(gameObject);
        }
        else
        {
            //Swap weapon currently held and weapon on the ground
            Weapon tWeapon = ScriptableObject.CreateInstance<Weapon>();
            tWeapon = weapon;
            weapon = player.weapons[player.currentWeaponIndex];
            player.weapons[player.currentWeaponIndex] = tWeapon;

            player.ApplyWeapon(player.weapons[player.currentWeaponIndex]);
            GetComponent<SpriteRenderer>().sprite = weapon.sprite;
        }
    }
}
