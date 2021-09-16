using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.Trajectory;
using RosSharp.RosBridgeClient.MessageTypes.Sensor;
using RosSharp.RosBridgeClient.MessageTypes.Moveit;

namespace RosSharp.RosBridgeClient
{
    public class MoveItPlanPathExecuter : MonoBehaviour
    {
        public JointTrajectoryPoint[] planPoints;
        private Thread goalHandler;
        public List<JointStateWriter> JointWriters;

        // Start is called before the first frame update
        void Start()
        {
            goalHandler = new Thread(DisplayTrajectory);
            goalHandler.Start();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void DisplayTrajectory(){ //JointTrajectoryPoint[] points
            //StartCoroutine(ExecuteTrajectory(planPoints));
        }

        IEnumerator ExecuteTrajectory(JointTrajectoryPoint[] points)
        {
            Debug.Log("Started Coroutine at timestamp : " + Time.time);

                //yield on a new YieldInstruction that waits for 5 seconds.
                yield return new WaitForSeconds(5);

                //After we have waited 5 seconds print the time again.
                Debug.Log("Finished Coroutine at timestamp : " + Time.time);

                Debug.Log(points.Length);
                for (int i = 0; i < points.Length - 1; i++){
                    //ExecuteSubtrajectory(points[i], points[i+1]);
                    Debug.Log(i);
                    for(int j = 0; j < 6; j++ ){
                        JointWriters[j].Write((float)points[i].positions[j]);
                    }
                    yield return new WaitForSeconds(1);
                }
        }     
    }
}