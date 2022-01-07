using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderChanger : MonoBehaviour
{
    public Image image;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(onchange);
    }

    void onchange(float value)
    {
        image.color = new Color(0,0,0,value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
