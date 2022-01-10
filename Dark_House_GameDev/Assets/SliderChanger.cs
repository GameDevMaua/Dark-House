using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderChanger : MonoBehaviour
{
    public Image image;
    public Slider slider;

    private void Start()
    {
        slider.onValueChanged.AddListener(OnChange);
        slider.SetValueWithoutNotify(image.color.a);
    }

    private void OnChange(float value)
    {
        image.color = new Color(0,0,0,value);
    }
}
