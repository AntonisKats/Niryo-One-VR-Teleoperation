using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient.MessageTypes.Trajectory;
using RosSharp.RosBridgeClient.MessageTypes.Sensor;
using RosSharp.RosBridgeClient.MessageTypes.Moveit;
using System.Threading;
namespace RosSharp.RosBridgeClient
{
    public class MoveItPlannedPathSubscriber : UnitySubscriber<MessageTypes.Moveit.DisplayTrajectory>
    {
        private int jointNum = 6;
        private IEnumerator coroutine;
        private float displayTimeStep = 0.1f;
        private bool isMessageReceived;
        public JointTrajectoryPoint[] planPoints;
        public List<JointStateWriter> JointWriters;

        //public JointTrajectoryPoint[] planPoints;

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(MessageTypes.Moveit.DisplayTrajectory message)
        {

            Debug.Log("New Planned Trajectory");
            planPoints = message.trajectory[0].joint_trajectory.points;
            isMessageReceived = true;

            
            //DisplayTrajectory();
        }

        private void ProcessMessage()
        {
            coroutine = DisplayTrajectory(planPoints);
            StartCoroutine(coroutine);
            isMessageReceived = false;
        }

        private IEnumerator DisplayTrajectory(JointTrajectoryPoint[] points)
        {
             for (int i = 0; i < points.Length - 1; i++){
                for(int j = 0; j < jointNum; j++ ){
                    JointWriters[j].Write((float)points[i].positions[j]);
                }
                yield return new WaitForSeconds(displayTimeStep);
            }
            print("Coroutine ended.");
        }
    } 
}

