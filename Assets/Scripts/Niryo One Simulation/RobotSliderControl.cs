using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
public class RobotSliderControl : MonoBehaviour
{
    public GameObject simulationRobot;
    public List<JointStateWriter> JointStateWriters;
    public List<Slider> controlSliders;
    private boolean simCounter = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < JointStateWriters.Count; i++)
        {
            JointStateWriters[i].Write(controlSliders[i].value * Mathf.Deg2Rad);
        }
    }
    
    public void RobotAppearance(){
        if(simCounter){
            
        }
        simulationRobot.gameObject.SetActive(false);
        simulationRobot
    }
    
    public void RobotAppear(){
        simulationRobot.gameObject.SetActive(true);
    }

}
