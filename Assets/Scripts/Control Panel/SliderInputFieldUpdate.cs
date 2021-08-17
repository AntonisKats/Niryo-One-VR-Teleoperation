using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderInputFieldUpdate : MonoBehaviour
{
    public InputField inputField;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        inputField.text = slider.value.ToString();  
        Grapher.Log(slider.value, "myName");
    }

    // Update is called once per frame
    void Update()
    {
        //inputField.text = slider.value.ToString(); 
        //slider.value = float.Parse(inputField.text);  
    }

    public void InputFieldUpdate(){
        inputField.text = slider.value.ToString("0.00"); 
        
    }

    public void SliderdUpdate(){
        slider.value = float.Parse(inputField.text);  
    }

   
}
