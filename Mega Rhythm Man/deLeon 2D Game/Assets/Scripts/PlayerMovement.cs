using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    public float jumpHeight;
    public float crouchHeight;
    public int level;
    public int Difficulty;
    public Camera MainCamera;
    public Rigidbody2D Player;       
    public SpriteRenderer Sprite;
    public GameObject CurrentLevel;

    private Animator Movement;
    private float speed;
    private float bpm;
   

    void Start()
    {
        
        Player = GetComponent<Rigidbody2D>();
        Movement = GetComponent<Animator>();
        
    }

    void Update()
    {
        // This is to determine the speed at which the main character's run animation syncs to.
        if (Difficulty == 1)
        {
            speed = 6;
            bpm = 110;
        }
        else if (Difficulty == 2)
        {
            speed = 7;
            bpm = 130;
        }
        else if (Difficulty == 3)
        {
            speed = 8;
            bpm = 140;
        }
        else if (Difficulty == 4)
        {
            speed = 9;
            bpm = 150;
        }
        else if (Difficulty == 5)
        {
            speed = 10;
            bpm = 172;
        }
        else
        {
            Difficulty = 1;
        }
        
        // This is the constant running speed/animation, since the game is focused on only evasion actions, this is automatic.
        MainCamera.transform.position += Vector3.right * speed * Time.deltaTime;
        transform.position += Vector3.right * speed * Time.deltaTime;
        Movement.SetBool("RunRight", true);
        Movement.speed = bpm / 130;

        // Controls
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log(Input.GetKey(KeyCode.LeftControl));
            Movement.SetBool("CrouchDash", true);
            Movement.SetBool("RunRight", false);
            transform.position += crouchHeight * Vector3.down;
        }
        else
        {
            Movement.SetBool("CrouchDash", false);
        }
        if (Input.GetKey("space"))
        {
            Debug.Log(Input.GetKey("space"));
            Movement.SetBool("SpacePressed", true);
            Movement.SetBool("RunRight", false);
            
            transform.position += jumpHeight * Vector3.up * Time.deltaTime;
        }
        else
        {
            Movement.SetBool("SpacePressed", false);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // This is collision detection for losing the game.
        if (collision.gameObject.tag == "Deadly")
        {
            Debug.Log(collision);
            Destroy(this);
            DontDestroyOnLoad(CurrentLevel);
            SceneManager.LoadScene(0);
        }
        // This is collision detection for fishing the game.
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log(collision);
            Destroy(this);
            DontDestroyOnLoad(CurrentLevel);
            SceneManager.LoadScene(2);
        }
    }
}