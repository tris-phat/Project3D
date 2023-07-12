using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetValueBar : MonoBehaviour
{
    public Slider Slider;

    public void SetMaxValue(int MaxValue, int Value)
    {
        Slider.maxValue = MaxValue;
        Slider.minValue = Value;
    }
    public void SetValue(int Value)
    {
        Slider.value = Value;
    }
}
