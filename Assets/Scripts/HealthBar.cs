using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public void UpdateBar(float currentValue,float maxValue)
    {
        fillBar.fillAmount =(float)currentValue /(float) maxValue;
    }
}
