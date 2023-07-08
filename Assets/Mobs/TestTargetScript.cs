using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTargetScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseXY = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseXY.z = 1;
            transform.position = Vector3.forward + mouseXY ;
        }
    }

}
