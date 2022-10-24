using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour {

    public void StartLevel(int levelLoad) {
        Debug.Log(levelLoad);
        SceneManager.LoadScene(levelLoad);
    }
}
