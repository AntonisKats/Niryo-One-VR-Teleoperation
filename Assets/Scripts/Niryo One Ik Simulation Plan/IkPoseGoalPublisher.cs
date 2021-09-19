using System.Collections.Generic;
using RosSharp.RosBridgeClient.MessageTypes.Geometry;
using UnityEngine.UI;

namespace RosSharp.RosBridgeClient
{
    public class IkPoseGoalPublisher : UnityPublisher<MessageTypes.Geometry.Pose>
    {
        public Toggle endEffectorControlToggle;
        public List<InputField> endEffectorFieldList;
        private MessageTypes.Geometry.Pose message;    
        private float xRot,yRot,zRot;
        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void FixedUpdate()
        {
            //UpdateMessage();
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Geometry.Pose
            {
                position = new Point{ x=0.0, y=0.0, z=0.0},
                orientation = new Quaternion{x = 0.0 ,y = 0.0, z = 0.0, w = 0.0}
            };
        }

        public void SendPoseGoal(){

            if(endEffectorControlToggle.isOn){
                message.position.x = float.Parse(endEffectorFieldList[0].text);
                message.position.y = float.Parse(endEffectorFieldList[1].text);
                message.position.z = float.Parse(endEffectorFieldList[2].text);
                xRot = float.Parse(endEffectorFieldList[3].text);
                yRot = float.Parse(endEffectorFieldList[4].text);
                zRot = float.Parse(endEffectorFieldList[5].text);
                UnityEngine.Quaternion rotation =  UnityEngine.Quaternion.Euler(xRot,yRot,zRot);
                message.orientation.x  = rotation.x;
                message.orientation.y  = rotation.y;
                message.orientation.z  = rotation.z;
                message.orientation.w  = rotation.w;
                Publish(message);
            }
            
        }


    }
}
