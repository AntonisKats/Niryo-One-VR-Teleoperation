using System.Collections.Generic;
using RosSharp.RosBridgeClient.MessageTypes.Geometry;


namespace RosSharp.RosBridgeClient
{
    public class IkPoseGoalPublisher : UnityPublisher<MessageTypes.Geometry.Pose>
    {
        public UnityEngine.Transform poseTransform;
        private MessageTypes.Geometry.Pose message;    
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
            message = new MessageTypes.Geometry.Pose
            {
                position = new Point{ x=0.0, y=0.0, z=0.0},
                orientation = new Quaternion{x = 0.0 ,y = 0.0, z = 0.0, w = 0.0}
            };
        }

        private void UpdateMessage()
        {
            message.position.x = poseTransform.position.Unity2Ros().x;
            message.position.y = poseTransform.position.Unity2Ros().y;
            message.position.z = poseTransform.position.Unity2Ros().z;

            message.orientation.x = 0;
            message.orientation.y = 0;
            message.orientation.z = 0;
            message.orientation.w = 1;
            //UnityEngine.Debug.Log(message.position.x);
            //UnityEngine.Debug.Log(message.position.y);
            //UnityEngine.Debug.Log(message.position.z);
            Publish(message);
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
