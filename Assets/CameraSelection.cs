using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelection : MonoBehaviour
{
    public GameObject unityCamera;
    public GameObject leftCamera;
    // Start is called before the first frame update
    void Start()
    {
        unityCamera.SetActive(true);
        leftCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("l")){
            unityCamera.SetActive(false);
            leftCamera.SetActive(true);
        }
        if(Input.GetKeyDown("v")){
            unityCamera.SetActive(true);
            leftCamera.SetActive(false);
        }
    }
}
