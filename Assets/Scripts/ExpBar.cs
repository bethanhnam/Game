using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Image fillBar;
    public void UpdateBar(float currentValue, float maxValue)
    {
        fillBar.fillAmount = (float)currentValue / (float)maxValue;
    }
}
