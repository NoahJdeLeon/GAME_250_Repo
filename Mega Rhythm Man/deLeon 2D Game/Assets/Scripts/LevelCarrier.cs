using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCarrier : MonoBehaviour {

    public int level;


    //this should have carried what the current level was to the menu but it was never implimented
    public void getLevel(int current)
    {
        level = current;
    }
}
