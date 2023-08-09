using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundsSlider : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    public float value;

    private void Update()
    {
        value = GetComponent<Slider>().value;
        displayText.text = value + "%";
    }
}
