using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour {
    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(speed, 0, 0);
    }
}
