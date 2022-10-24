using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour {

    public GameObject CurrentLevel;

    public void StartLevel(int levelLoad) {
        Debug.Log(levelLoad);
        // Loads the level
        DontDestroyOnLoad(CurrentLevel);
        SceneManager.LoadScene(levelLoad);
        
    }
    
}
