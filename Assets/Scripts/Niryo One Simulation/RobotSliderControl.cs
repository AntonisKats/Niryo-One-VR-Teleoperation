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
    private bool simCounter = false;
    // Start is called before the first frame update
    void Start()
    {
        simulationRobot.gameObject.SetActive(false);
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
            simulationRobot.gameObject.SetActive(false);
            simCounter = false;

        }
        else{
            simulationRobot.gameObject.SetActive(true);
            simCounter = true;
        }
        
    }

}
