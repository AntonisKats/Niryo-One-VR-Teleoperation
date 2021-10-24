using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPositionControl : MonoBehaviour
{
    private Vector3 originalLocation;
    // Start is called before the first frame update
    void Start()
    {
        originalLocation = gameObject.GetComponent<RectTransform>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(originalLocation);
        if(Input.GetKeyDown("l")){
            originalLocation[0] = 140;
            transform.position = originalLocation;
        }
        if(Input.GetKeyDown("v")){
            originalLocation[0] = 140;
            transform.position = originalLocation;
        }
        if(Input.GetKeyDown("r")){
            originalLocation[0] = 500;
            transform.position = originalLocation;
        }
    }
}
