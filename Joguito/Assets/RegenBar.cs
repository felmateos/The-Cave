using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class RegenBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxRegen(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetRegen(float health)
    {
        slider.value = health;
    }
    public float GetRegen()
    {
        return slider.value;
    }
}
