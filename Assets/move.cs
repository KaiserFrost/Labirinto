using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    float yAxis;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
       
        

        if (Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(xAxisValue, zAxisValue, 0));
        }

    }
}
