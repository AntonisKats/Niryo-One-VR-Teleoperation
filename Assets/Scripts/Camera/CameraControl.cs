using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CameraControl : MonoBehaviour
{

    public float speedH = 1.00001f;
    
    private float yaw = 0.0f;
    //private float mouseClickedDistance = 0.0f;
    private float mouseXPosition;
    private bool alreadyClicked = false;
    private bool controlCamera = false;
    private float mouseFirstClickPos = 0.0f;
    private Vector3 mousePos; 
    private float mouseDistance;
    private float cameraX;
    private float cameraZ;
    private float cameraRadius;
    private float startCameraZ;
    private float startCameraX;
    private float startXAngle;

    private float minFov = 15f;
    private float maxFov = 90f;
    private float fov ;
    private float sensitivity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        startCameraX = transform.position.x;
        startCameraZ = transform.position.z;
        cameraRadius = Math.Abs(transform.position.z);
        startXAngle = transform.eulerAngles.x;
        Debug.Log(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        ZoomManager();
        mousePos = Input.mousePosition;
        if(Input.GetMouseButtonDown(0))controlCamera = true;

        if(controlCamera == true){
            if(Input.GetMouseButtonDown(1)){
                
                if(alreadyClicked == false){
                    alreadyClicked = true;
                    mouseFirstClickPos = mousePos.x;
                    //print("First Click:");
                    //print(mouseFirstClickPos);
                }
                
                
            }
            if(Input.GetMouseButtonUp(1)){
                //mouseClickedDistance = 0.0f;
                alreadyClicked = false;
                //print("Up Button!");
            }
            if(alreadyClicked == true){
                mouseDistance = mousePos.x - mouseFirstClickPos;
                //print(mouseDistance);


                
                // Set angle
                yaw = mouseDistance - transform.rotation.y ;
                yaw = yaw / 2.0f;
                
                transform.rotation =  Quaternion.Euler(startXAngle,yaw,0.0f);

                //Set position
                cameraZ = - cameraRadius * Mathf.Cos(-yaw*Mathf.Deg2Rad);
                cameraX = cameraRadius * Mathf.Sin(-yaw*Mathf.Deg2Rad);
                transform.position = new Vector3(cameraX,transform.position.y,cameraZ);

                
                
            }

        }
        
        
    }
    void FixedUpdate()
    {
    }

    void ZoomManager(){
        fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
