using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public GameObject weaponPlaceholder;
    public TextMeshProUGUI energyCostDisplay;

    Player player;

    private void Awake()
    {
        weaponPlaceholder = transform.Find("Weapon Placeholder").gameObject;
        energyCostDisplay = transform.Find("Energy Cost Display/Text").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        UpdateWeaponIcon();
    }

    private void UpdateWeaponIcon()
    {
        weaponPlaceholder.GetComponent<Image>().sprite = player.weapons[player.currentWeaponIndex].sprite;

        float energyCost = player._energyCost;
        energyCostDisplay.text = energyCost.ToString();
    }
}
