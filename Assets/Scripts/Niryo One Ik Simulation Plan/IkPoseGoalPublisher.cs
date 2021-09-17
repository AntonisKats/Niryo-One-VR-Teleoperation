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

                message.orientation.x = 0;
                message.orientation.y = 0.707;
                message.orientation.z = 0;
                message.orientation.w = 0.707;
                Publish(message);
            }
            
        }

        // private void UpdateJointState(int i)
        // {

        //     JointStateReaders[i].Read(
        //         out message.name[i],
        //         out float position,
        //         out float velocity,
        //         out float effort);

        //     message.position[i] = position;
        //     message.velocity[i] = velocity;
        //     message.effort[i] = effort;
        // }


    }
}
