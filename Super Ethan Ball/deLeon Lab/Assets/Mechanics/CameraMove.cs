using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {


    public GameObject Sphere;

    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - Sphere.transform.position;
    }

    // Update is called once per frame
    void Update () {
         transform.position = Sphere.transform.position + offset;
    }
    
     
    

}


