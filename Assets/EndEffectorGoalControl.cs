using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndEffectorGoalControl : MonoBehaviour
{
    public Toggle endEffectorControlToggle;
    public Transform toolLinkTransform;
    public List<InputField> endEffectorInputs;
    private float eeX,eeY,eeZ,eeRotX,eeRotY,eeRotZ;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = toolLinkTransform.position;
        transform.rotation = toolLinkTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(endEffectorControlToggle.isOn);
        if(endEffectorControlToggle.isOn){
            ShowChildren();
            Debug.Log("Sphere appears");
            // Adjust the coordinate system Unity - ROS
            eeX = float.Parse(endEffectorInputs[1].text);
            eeY = float.Parse(endEffectorInputs[2].text);
            eeZ = -float.Parse(endEffectorInputs[0].text);
            eeRotZ = -float.Parse(endEffectorInputs[3].text);
            eeRotX = -float.Parse(endEffectorInputs[4].text);
            eeRotY = float.Parse(endEffectorInputs[5].text);
            transform.position = new Vector3(eeX,eeY,eeZ);
            transform.rotation= Quaternion.Euler(eeRotX,eeRotY+180,eeRotZ);
        }
        else{
            HideChildren();
            Debug.Log("Sphere disappears");
            transform.position = toolLinkTransform.position;
            transform.rotation = toolLinkTransform.rotation;
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
