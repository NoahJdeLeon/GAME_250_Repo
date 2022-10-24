using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : MonoBehaviour {

    public Rigidbody box;
    public float height;
    public int extra;
    // Use this for initialization
    void Start () {
        extra = 0;
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            box.transform.Translate(0, height, 0);
            while (extra < 5)
            {
                Instantiate(box, new Vector3(200, 50 + height, 200), Quaternion.identity); 
                extra++;
            }
        }
    }
}
