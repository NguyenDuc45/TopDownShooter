using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatBarUI : MonoBehaviour
{
    StatBar hitPointBar;
    StatBar depleteHitPointBar;
    StatBar energyBar;
    StatBar chargingCooldownBar;

    TextMeshProUGUI hitPointText;
    TextMeshProUGUI energyText;

    Player player;
    PlayerShoot playerShoot;

    private float depleteHitPoint;

    private void Awake()
    {
        hitPointBar = transform.Find("Hit Point Bar").GetComponent<StatBar>();
        depleteHitPointBar = transform.Find("Deplete Hit Point Bar").GetComponent<StatBar>();
        energyBar = transform.Find("Energy Bar").GetComponent<StatBar>();
        chargingCooldownBar = transform.Find("Charging Cooldown Bar").GetComponent<StatBar>();

        hitPointText = transform.Find("Hit Point Bar").transform.Find("Display Text").GetComponent<TextMeshProUGUI>();
        energyText = transform.Find("Energy Bar").transform.Find("Display Text").GetComponent<TextMeshProUGUI>();

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerShoot = GameObject.FindWithTag("Player").GetComponent<PlayerShoot>();
    }

    private void Update()
    {
        UpdateStatBars();
        SetDepleteHitPoint();
    }

    private void UpdateStatBars()
    {
        hitPointBar.SetMaxValue(player._hitPoint);
        depleteHitPointBar.SetMaxValue(player._hitPoint);
        energyBar.SetMaxValue(player._maximumEnergy);
        chargingCooldownBar.SetMaxValue(player._chargingTime);

        hitPointBar.SetValue(player.currentHitPoint);
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

        hitPointText.text = (int)player.currentHitPoint + "/" + player._hitPoint;
        energyText.text = (int)playerShoot.currentEnergy + "/" + player._maximumEnergy;
    }

    private void SetDepleteHitPoint()
    {
        if (depleteHitPoint < player.currentHitPoint)
            depleteHitPoint = player.currentHitPoint;
        else if (depleteHitPoint > player.currentHitPoint)
            depleteHitPoint -= Time.deltaTime * player._hitPoint / 2;
    }
}
