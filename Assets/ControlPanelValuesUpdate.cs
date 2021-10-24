using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelValuesUpdate : MonoBehaviour
{
    public List<float> jointValues;
    public List<float> endEffectorPose;
    public List<Text> jointLabels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<6; i++){
            jointLabels[i].text = "Joint:" + jointValues[i].ToString(); ;
        }
    }
}
