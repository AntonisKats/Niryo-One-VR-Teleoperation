using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Trajectory;
using RosSharp.RosBridgeClient.MessageTypes.Sensor;
using RosSharp.RosBridgeClient.MessageTypes.Moveit;
public class SimulationPlanRobotControl : MonoBehaviour
{
    public GameObject simulationRobot;
    public MoveItPlannedPathSubscriber pathSubscriber;
    public List<JointStateWriter> JointWriters;
    public List<JointStateReader> JointReaders;
    private int jointNum = 6;
    private float displayTimeStep = 0.1f;
    private int planExecutedNum = 0;
    private IEnumerator coroutine;
    Renderer test;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void FixedUpdate()
    {
        //Debug.Log("Fixed");
        if(pathSubscriber.planNumber != planExecutedNum){
            coroutine = DisplayTrajectory(pathSubscriber.planPoints);
            StartCoroutine(coroutine);
            planExecutedNum++;
        }
    }
    
    
        

    private IEnumerator DisplayTrajectory(JointTrajectoryPoint[] points)
    {
        ShowChildren();
        for (int i = 0; i < points.Length - 1; i++){
            for(int j = 0; j < jointNum; j++ ){
                JointWriters[j].Write((float)points[i].positions[j]);
                
            }
            yield return new WaitForSeconds(displayTimeStep);
        }
            
        for(int j = 0; j < jointNum; j++ ){
            JointReaders[j].Read(
            out string name,
            out float position,
            out float velocity,
            out float effort);
            JointWriters[j].Write((float)position);   
        }
        HideChildren();
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
