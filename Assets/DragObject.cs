using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 calculatedPosition;

    void Start(){
        Debug.Log("Started");
    }
    void OnMouseDown()
    {
        Debug.Log("Mouse");
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }


    private Vector3 GetMouseAsWorldPoint()
    {
        Debug.Log("Mouse");
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;//z
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


    void OnMouseDrag()
    {
        Debug.Log("Mouse");
        calculatedPosition = GetMouseAsWorldPoint() + mOffset;
        transform.position = new Vector3(calculatedPosition.x,transform.position.y,calculatedPosition.z);
    }
}


