using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using RosMessageTypes.Geometry;

public class UnityImageSubscriber : MonoBehaviour
{
    // ROS Connector
    private ROSConnection ros;

    // Variables required for ROS communication
    public string topicName = "";

    void Start()
    {
        // Get ROS connection static instance
        ros = ROSConnection.instance;
    }

}