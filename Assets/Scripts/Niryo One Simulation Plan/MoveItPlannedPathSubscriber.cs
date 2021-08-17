using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace RosSharp.RosBridgeClient
{
    public class MoveItPlannedPathSubscriber : UnitySubscriber<MessageTypes.Moveit.DisplayTrajectory>
    {
        //public List<string> JointNames;
        //public List<JointStateWriter> JointStateWriters;

        protected override void ReceiveMessage(MessageTypes.Moveit.DisplayTrajectory message)
        {

            Debug.Log("New Planned Trajectory");
            // int index;
            // for (int i = 0; i < message.name.Length; i++)
            // {
            //     index = JointNames.IndexOf(message.name[i]);
            //      Grapher.Log(message.position[0]* Mathf.Deg2Rad, "Joint 1");
            //     if (index != -1)
            //         JointStateWriters[index].Write((float) message.position[i]);

            // }
        }
    }
}

