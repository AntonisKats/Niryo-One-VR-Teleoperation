using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndEffectorCubeControl : MonoBehaviour
{
    public Toggle endEffectorControlToggle;
    public Transform toolLinkTransform;
    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = gameObject.GetComponent<Renderer>();
        transform.position = toolLinkTransform.position;
        transform.rotation = toolLinkTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

}
