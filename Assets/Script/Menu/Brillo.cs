using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brillo : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelbrillo;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        panelbrillo.color = new Color(panelbrillo.color.r, panelbrillo.color.g, panelbrillo.color.b, slider.value);               
    }
    
    public void ChangeSlider (float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelbrillo.color = new Color(panelbrillo.color.r, panelbrillo.color.g, panelbrillo.color.b, slider.value);
    }

 
}
