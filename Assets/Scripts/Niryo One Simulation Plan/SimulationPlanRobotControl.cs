using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
public class SimulationPlanRobotControl : MonoBehaviour
{
    public GameObject simulationRobot;
    private bool simCounter = false;
    // Start is called before the first frame update
    void Start()
    {
        simulationRobot.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    
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
