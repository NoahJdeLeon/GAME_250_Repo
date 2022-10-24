using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollider : MonoBehaviour {

    public GameObject coin;
    public Text collided;
    public Slider collected;
    public AudioSource sound;
    public AudioClip blip;
    // Use this for initialization
    void Start () {

    }
	

    IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            collected.value += 1;
            collided.text = "*blip*";
            sound.PlayOneShot(blip, 1);
            yield return new WaitForSeconds(0.1F);
            Destroy(coin);
            collided.text = "";
        }
    }
}
