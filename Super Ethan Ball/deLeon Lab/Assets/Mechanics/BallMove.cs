using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour {

    
    public Rigidbody Sphere;
    public float speed;
    public Slider collected;
    public Text collided;
    public Text Cleared;
    public int numCoins;
    

    private Vector3 offset;
    private int level;
    private AsyncOperation Async;
    private bool endOfLevel = false;
    // Use this for initialization
    void Start () {
        //DontDestroyOnLoad(this.gameObject);
        Sphere = GetComponent<Rigidbody>();
        offset = transform.position - Sphere.transform.position;
        collected.maxValue = numCoins;
        collected.value = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float Vertical = Input.GetAxis("Vertical") * speed;
        float Horizontal = Input.GetAxis("Horizontal") * speed;
        Sphere.AddForce(Horizontal, 0, Vertical, ForceMode.Acceleration);
        //transform.Rotate(0, Horizontal * speed * Time.deltaTime, 0);
        if (collected.value == collected.maxValue && !endOfLevel)
        {
            if (level > 2)
            {
                level = 0;
            }
            StartCoroutine(LevelClear());
            Cleared.text = "Level Clear!";

        }
        endOfLevel = false;
    }
    private IEnumerator LevelClear() {
        endOfLevel = true;
        // process pre-yield
        yield return new WaitForSeconds(2);
        // process post-yield
        level += 1;
        if (level > 2)
        {
            level = 0;
        }
        Async = SceneManager.LoadSceneAsync(level);
    }
}


