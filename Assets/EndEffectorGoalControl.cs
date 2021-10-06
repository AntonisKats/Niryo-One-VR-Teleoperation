using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace RosSharp.RosBridgeClient
{
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

                //Get Values
                eeX = float.Parse(endEffectorInputs[0].text);
                eeY = float.Parse(endEffectorInputs[1].text);
                eeZ = float.Parse(endEffectorInputs[2].text);
                eeRotZ = float.Parse(endEffectorInputs[5].text);
                eeRotX = float.Parse(endEffectorInputs[3].text);
                eeRotY = float.Parse(endEffectorInputs[4].text);
                Vector3 translation = new Vector3(eeX,eeY,eeZ);
                Quaternion rot =  Quaternion.Euler(eeRotX, eeRotY, eeRotZ);
                
                //RosSharp.RosBridgeClient.MessageTypes.Geometry.Quaternion rotation = new RosSharp.RosBridgeClient.MessageTypes.Geometry.Quaternion(rot[0],rot[1],rot[2],rot[3]) ;

                transform.position = translation.Ros2Unity();
                transform.rotation= rot.Ros2Unity();
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
}