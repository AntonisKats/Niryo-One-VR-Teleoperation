using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient.MessageTypes.Trajectory;
using RosSharp.RosBridgeClient.MessageTypes.Sensor;
using RosSharp.RosBridgeClient.MessageTypes.Moveit;
namespace RosSharp.RosBridgeClient
{
    public class MoveItPlannedPathSubscriber : UnitySubscriber<MessageTypes.Moveit.DisplayTrajectory>
    {
        public List<JointStateWriter> JointWriters;
        //private List<JointStateReader> JointReaders;
        private int jointNum = 6;
        private float trajStep = 0.01f;
        private uint startTimeMsecs;
        private uint endTimeMsecs;
        private double startTime;
        private double endTime;
        private float q;
        //private float timeSTP = 0.01f ; // default value
        private double[] a;
        private double[] b;

        protected override void ReceiveMessage(MessageTypes.Moveit.DisplayTrajectory message)
        {

            Debug.Log("New Planned Trajectory");
            Debug.Log(message.trajectory[0].joint_trajectory.points.Length);
            ExecuteTrajectory(message.trajectory[0].joint_trajectory.points);
        }


        void ExecuteTrajectory(JointTrajectoryPoint[] points)
        {
            Debug.Log(points.Length);
            for (int i = 0; i < points.Length - 1; i++){
                //ExecuteSubtrajectory(points[i], points[i+1]);
                Debug.Log(i);
                for(int j = 0; j < jointNum; j++ ){
                    JointWriters[j].Write((float)points[i].positions[j]);
                }
            }
        }
        void ExecuteSubtrajectory(JointTrajectoryPoint start, JointTrajectoryPoint end){
            startTimeMsecs = start.time_from_start.nsecs / 1000000 + start.time_from_start.secs*1000;
            endTimeMsecs = end.time_from_start.nsecs / 1000000 + end.time_from_start.secs*1000;
            startTime = (double)startTimeMsecs / 1000;
            endTime = (double)endTimeMsecs / 1000;

            for(int i = 0; i < jointNum; i++ ){
                a[i] = (end.positions[i] - start.positions[i]) / (endTime - startTime);
                b[i] = end.positions[i] - a[i]*endTime;
                //Debug.Log(a[i]);
                //Debug.Log(b[i]);
            }
            
            //Debug.Log(startTime);
            for(double t=startTime+trajStep; t< endTime; t=t+trajStep){
                for(int i = 0; i < jointNum; i++ ){
                    q = (float)(a[i]*t+b[i]);
                    //Debug.Log(q);
                    //Debug.Log(a[i]);
                    //Debug.Log(b[i]);
                    Debug.Log("Test");
                    JointWriters[i].Write(q);
                }
            } 
            for(int i = 0; i < jointNum; i++ ){
                    q = (float)end.positions[i];
                    //Debug.Log(q);
                    //Debug.Log(a[i]);
                    //Debug.Log(b[i]);
                    JointWriters[i].Write(q);
            }
            //Sleep((int)trajStep*1000);
        }
    }
}

