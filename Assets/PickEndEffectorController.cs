using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickEndEffectorController : MonoBehaviour
{
    public Toggle pickAndPlacelToggle;
    private bool buttonPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pickAndPlacelToggle.isOn){
            if(buttonPressed ==false){
                transform.position = new Vector3(-0.2f,0.1f,0f);
                Quaternion rot =  Quaternion.Euler(90, 0, 0);
                transform.rotation = rot;
                ShowChildren();
                //Debug.Log("Pick appears");

                buttonPressed = true;
            }
            
        }
        else{
            HideChildren();
            //Debug.Log("Pick disappears");
            buttonPressed = false; 
        }
    }

    public void Show() {
        GetComponent<Renderer>().enabled = true;
    }
    public void Hide() {
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
