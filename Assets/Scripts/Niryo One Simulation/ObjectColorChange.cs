using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColorChange : MonoBehaviour
{
    public GameObject paintedObject;
    // Start is called before the first frame update
    void Start()
    {
       paintedObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
