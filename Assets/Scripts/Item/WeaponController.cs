using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    Player player;
    [SerializeField]
    Weapon weapon;
    public string weaponName;
    public string weaponTooltip;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = weapon.sprite;
    }

    private void Update()
    {
        weaponName = weapon.name;
        weaponTooltip = "Damage: " + weapon.damage + "\n" + "Fire Rate: " + weapon.fireRate + "\n" + "Energy Cost: " + weapon.energyCost;
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
            //Swap currently held weapon and weapon on the ground
            Weapon tWeapon = ScriptableObject.CreateInstance<Weapon>();
            tWeapon = weapon;
            weapon = player.weapons[player.currentWeaponIndex];
            player.weapons[player.currentWeaponIndex] = tWeapon;

            player.ApplyWeapon(player.weapons[player.currentWeaponIndex]);
            GetComponent<SpriteRenderer>().sprite = weapon.sprite;
        }
    }
}
