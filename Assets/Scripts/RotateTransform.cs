using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTransform : MonoBehaviour
{
    //public Transform transform;
    private Transform transformPlane;
    // Start is called before the first frame update
    void Start()
    {
        transformPlane = GetComponent<Transform>();
        transformPlane.transform.Rotate(0,180,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
