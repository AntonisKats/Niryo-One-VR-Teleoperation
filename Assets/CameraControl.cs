using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraControl : MonoBehaviour
{

    public float speedH = 1.00001f;
    
    private float yaw = 0.0f;
    private float mouseClickedDistance = 0.0f;
    private float mouseXPosition;
    private bool alreadyClicked = false;
    private bool controlCamera = false;
    private float mouseFirstClickPos = 0.0f;
    private Vector3 mousePos; 
    private float mouseDistance;
    private float cameraX;
    private float cameraZ;
    private float cameraRadius = 1.0f;
    private float startCameraZ;
    private float startCameraX;
    // Start is called before the first frame update
    void Start()
    {
        startCameraX = transform.position.x;
        startCameraZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        if(Input.GetMouseButtonDown(0))controlCamera = true;

        if(controlCamera == true){
            if(Input.GetMouseButtonDown(1)){
                
                if(alreadyClicked == false){
                    alreadyClicked = true;
                    mouseFirstClickPos = mousePos.x;
                    print("First Click:");
                    print(mouseFirstClickPos);
                }
                
                
            }
            if(Input.GetMouseButtonUp(1)){
                mouseClickedDistance = 0.0f;
                alreadyClicked = false;
                print("Up Button!");
            }
            if(alreadyClicked == true){
                mouseDistance = mousePos.x - mouseFirstClickPos;
                //print(mouseDistance);

                // Set angle
                yaw = mouseDistance - transform.rotation.y ;
                yaw = yaw / 2.0f;
                transform.rotation =  Quaternion.Euler(0.0f,yaw,0.0f);

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
}
