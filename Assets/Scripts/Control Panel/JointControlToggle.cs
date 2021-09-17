using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JointControlToggle : MonoBehaviour
{
    public List<Slider> sliderList;
    public List<InputField> inputFieldList;
    public Toggle jointControlToggle; 
    public Toggle endEffectorControlToggle; 
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(jointControlToggle.isOn)EnablePanel();
        else DisablePanel();

        if(endEffectorControlToggle.isOn)jointControlToggle.interactable = false;
        else jointControlToggle.interactable = true;
    }

    void DisablePanel(){
        for(int i=0; i<6; i++)sliderList[i].interactable = false;
        for(int i=0; i<6; i++)inputFieldList[i].interactable = false;
    }

    void EnablePanel(){
        for(int i=0; i<6; i++)sliderList[i].interactable = true;
        for(int i=0; i<6; i++)inputFieldList[i].interactable = true;
    }
}
