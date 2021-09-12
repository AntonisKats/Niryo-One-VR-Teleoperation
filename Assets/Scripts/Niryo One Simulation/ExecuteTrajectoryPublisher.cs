using System.Collections.Generic;
using RosSharp.RosBridgeClient.MessageTypes.Std;


namespace RosSharp.RosBridgeClient
{
    public class ExecuteTrajectoryPublisher : UnityPublisher<MessageTypes.Std.Bool>
    {
        private MessageTypes.Std.Bool message;    
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
            message = new MessageTypes.Std.Bool();
        
        }

        private void UpdateMessage()
        {
        }

        public void ExecuteTrajectory(){
            Publish(message);
        }

    }
}
