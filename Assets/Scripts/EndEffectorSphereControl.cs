using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndEffectorSphereControl : MonoBehaviour
{
    public Toggle endEffectorControlToggle;
    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
       objectRenderer = gameObject.GetComponent<Renderer>();
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
