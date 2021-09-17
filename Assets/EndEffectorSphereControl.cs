using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndEffectorSphereControl : MonoBehaviour
{
    public Toggle endEffectorControlToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(endEffectorControlToggle.isOn){
            
        }
        else{
            
        }
    }

    void Show() {
        GetComponent<Renderer>().enabled = true;
    }
    void Hide() {
        GetComponent<Renderer>().enabled = false;
    }
    void HideChildren()
    {
        Renderer[] lChildRenderers=gameObject.GetComponentsInChildren<Renderer>();
        foreach ( Renderer lRenderer in lChildRenderers)
        {
            lRenderer.enabled=false;
        }
    }
    void ShowChildren()
    {
        Renderer[] lChildRenderers=gameObject.GetComponentsInChildren<Renderer>();
        foreach ( Renderer lRenderer in lChildRenderers)
        {
            lRenderer.enabled=true;
        }
    }
}
