using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RosSharp.RosBridgeClient
{
    public class ForwardKinematicsPublisher : UnityPublisher<MessageTypes.Sensor.JointState>
    {
        private MessageTypes.Sensor.JointState message;
        public List<Slider> slider;
        public Toggle jointControlToggle;
        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Sensor.JointState();
            message.position = new double[6];

        }
        public void SendJoints()
        {
            if(jointControlToggle.isOn){
                for(int i=0; i < slider.Count; i++){
                message.position[i] = slider[i].value * Mathf.Deg2Rad;
                }
                Publish(message);
            }
            
        }

    }
}
