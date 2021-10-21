using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelection : MonoBehaviour
{
    public GameObject unityCamera;
    public GameObject leftCamera;
    public GameObject rightCamera;
    // Start is called before the first frame update
    void Start()
    {
        unityCamera.SetActive(true);
        leftCamera.SetActive(false);
        rightCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("l")){
            unityCamera.SetActive(false);
            leftCamera.SetActive(true);
            rightCamera.SetActive(false);
        }
        if(Input.GetKeyDown("v")){
            unityCamera.SetActive(true);
            leftCamera.SetActive(false);
            rightCamera.SetActive(false);
        }
        if(Input.GetKeyDown("r")){
            unityCamera.SetActive(false);
            leftCamera.SetActive(false);
            rightCamera.SetActive(true);
        }
    }
}
