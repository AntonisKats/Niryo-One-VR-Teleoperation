using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEffectorGoalController : MonoBehaviour
{
    public GameObject cube;
    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
          targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)){
                targetPosition = hit.point;
                cube.transform.position = targetPosition;
            }
        }
    }
}
