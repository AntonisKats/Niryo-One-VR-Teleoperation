using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateSystemPositionUpdate : MonoBehaviour
{
    private Vector3 transformPosition;
    // Start is called before the first frame update
    void Start()
    {
        transformPosition = gameObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("l")){
            Debug.Log("Test");
            transformPosition[0] = 0.4f;
            transform.position = transformPosition;
        }
        if(Input.GetKeyDown("v")){
            transformPosition[0] =  -0.4f;
            transform.position = transformPosition;
        }
        if(Input.GetKeyDown("r")){
            transformPosition[0] = 0.4f;
            transform.position = transformPosition;
        }
    }
}
