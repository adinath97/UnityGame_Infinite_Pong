using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public Slider slider2;
    public float sliderValue;
    public float sliderValue2;
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("save",sliderValue);
        slider2.value = PlayerPrefs.GetFloat("save2",sliderValue2);
    }

    public void ChangeSlider(float value) {
        sliderValue = value;
        PlayerPrefs.SetFloat("save",sliderValue);
    }

    public void ChangeSlider2(float value2) {
        sliderValue2 = value2;
        PlayerPrefs.SetFloat("save2",sliderValue2);
    }
}
