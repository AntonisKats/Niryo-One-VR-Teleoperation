using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndEffectorControlToggle : MonoBehaviour
{
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
        if(endEffectorControlToggle.isOn)EnablePanel();
        else DisablePanel();

        if(jointControlToggle.isOn)endEffectorControlToggle.interactable = false;
        else endEffectorControlToggle.interactable = true;
    }

    void DisablePanel(){
        for(int i=0; i<3; i++)inputFieldList[i].interactable = false;
    }

    void EnablePanel(){
        for(int i=0; i<3; i++)inputFieldList[i].interactable = true;
    }
}