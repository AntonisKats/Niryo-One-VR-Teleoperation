using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
public class SimulationRobotControl : MonoBehaviour
{
    public GameObject simulationRobot;
    public List<JointStateWriter> JointStateWriters;
    public List<Slider> controlSliders;
    public Toggle jointControlToggle;
    public Toggle viewSimRobotToggle;
    // Start is called before the first frame update
    void Start()
    {
        HideChildren();
    }

    // Update is called once per frame
    void Update()
    {
        if(jointControlToggle.isOn){
            for (int i = 0; i < JointStateWriters.Count; i++){
                JointStateWriters[i].Write(controlSliders[i].value * Mathf.Deg2Rad);
            }
        }

        if(viewSimRobotToggle.isOn)ShowChildren();
        else HideChildren();


        
    }
    

    void Show() {
        GetComponent<Renderer>().enabled = true;
    }
    void Hide() {
        GetComponent<Renderer>().enabled = false;
    }
    void HideChildren()
    {
        Renderer[] lChildRenderers=gameObject.GetComponentsInChildren<Renderer>();
        foreach ( Renderer lRenderer in lChildRenderers)
        {
            lRenderer.enabled=false;
        }
    }
    void ShowChildren()
    {
        Renderer[] lChildRenderers=gameObject.GetComponentsInChildren<Renderer>();
        foreach ( Renderer lRenderer in lChildRenderers)
        {
            lRenderer.enabled=true;
        }
    }

}
