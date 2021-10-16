using System.Collections.Generic;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.NiryoOne;
namespace RosSharp.RosBridgeClient
{
    public class GripperCommandPublisher : UnityPublisher<ToolCommand>
    {
        private ToolCommand message;    
        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void FixedUpdate()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            message = new ToolCommand();
        
        }

        private void UpdateMessage()
        {
        }

        public void OpenGripper(){
            message.tool_id = 11;
            message.cmd_type = 1;
            message.gripper_close_speed = 300;
            message.gripper_open_speed = 300;
            message.activate = false;
            message.gpio = 0;
        }

        public void CloseGripper(){
            message.tool_id = 11;
            message.cmd_type = 2;
            message.gripper_close_speed = 300;
            message.gripper_open_speed = 300;
            message.activate = false;
            message.gpio = 0;
        }

    
    }
}
