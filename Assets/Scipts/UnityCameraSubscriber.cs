using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using CompressedImage = RosMessageTypes.Sensor.CompressedImageMsg;

public class UnityCameraSubscriber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ROSConnection.instance.Subscribe<CompressedImage>("niryo_one_vision/compressed_video_stream", NewFrame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewFrame(CompressedImage image){
        Debug.Log("New Frame!!");

    }
}
