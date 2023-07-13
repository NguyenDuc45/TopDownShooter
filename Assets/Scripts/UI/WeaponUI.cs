using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public GameObject weaponPlaceholder;
    public GameObject changeWeaponIcon;

    Player player;

    private void Awake()
    {
        weaponPlaceholder = transform.Find("Weapon Placeholder").gameObject;
        changeWeaponIcon = transform.Find("Change Weapon Icon").gameObject;

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        UpdateWeaponIcon();
    }

    private void UpdateWeaponIcon()
    {
        weaponPlaceholder.GetComponent<Image>().sprite = player.weapons[player.currentWeaponIndex].sprite;

        if (player.weapons.Count >= 2)
            changeWeaponIcon.SetActive(true);
        else changeWeaponIcon.SetActive(false);
    }
}
