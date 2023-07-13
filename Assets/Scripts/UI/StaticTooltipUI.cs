using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StaticTooltipUI : MonoBehaviour
{
    private GameObject itemTooltip;
    private RectTransform itemTooltipRectTransform;
    private TextMeshProUGUI itemTooltipText;

    Player player;

    private void Awake()
    {
        itemTooltip = transform.Find("Item Tooltip").gameObject;
        itemTooltipRectTransform = itemTooltip.GetComponent<RectTransform>();
        itemTooltipText = itemTooltip.transform.Find("Text").GetComponent<TextMeshProUGUI>();

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        UpdateTooltip();
    }

    private void UpdateTooltip()
    {
        if (player.isCollidingWithWeapon)
        {
            itemTooltip.SetActive(true);
            SetText(player.weaponController.weaponName + "\n\n" + player.weaponController.weaponTooltip);
        }

        else if (player.isCollidingWithBooster)
        {
            itemTooltip.SetActive(true);
            SetText(player.boosterController.boosterName + "\n\n" + player.boosterController.boosterTooltip);
        }


        else itemTooltip.SetActive(false);
    }

    private void SetText(string tooltip)
    {
        itemTooltipText.SetText(tooltip);
        itemTooltipText.ForceMeshUpdate();

        Vector2 textSize = itemTooltipText.GetRenderedValues(false);
        Vector2 paddingSize = new Vector2(40, 40);

        itemTooltipRectTransform.sizeDelta = textSize + paddingSize;
    }
}
