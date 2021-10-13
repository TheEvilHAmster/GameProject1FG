using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BatteryLevel : MonoBehaviour
{
    public Slider slider;
    public void SetMaxBatteryLevel(float batteryLevel)
    {
        slider.maxValue = batteryLevel;
        slider.value = batteryLevel;
    }

    public void SetBatteryLevel(float batteryLevel)
    {
        slider.value = batteryLevel;
    }
}
