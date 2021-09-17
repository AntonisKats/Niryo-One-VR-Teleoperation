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
        private bool isMessageReceived;
        public JointTrajectoryPoint[] planPoints;
        //private IEnumerator coroutine;

        //public JointTrajectoryPoint[] planPoints;
        public int planNumber = 0;

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(MessageTypes.Moveit.DisplayTrajectory message)
        {
            planPoints = message.trajectory[0].joint_trajectory.points;
            planNumber++;
            isMessageReceived = true;
        }

        private void ProcessMessage()
        {
            isMessageReceived = false;
        }

    } 
}

