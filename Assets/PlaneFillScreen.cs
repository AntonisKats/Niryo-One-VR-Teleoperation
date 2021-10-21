using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaneFillScreen : MonoBehaviour
{
    public RawImage image;
    public Texture2D m_Texture;
    void Start()
    {
        //Fetch the RawImage component from the GameObject
        //m_RawImage = GetComponent<RawImage>();
        //Change the Texture to be the one you define in the Inspector
        image.texture = m_Texture;
    }
 
}
