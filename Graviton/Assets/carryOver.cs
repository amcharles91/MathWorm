using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carryOver : MonoBehaviour {

    public static bool gameType;
    //[SerializeField] bool gameType;

    private void Awake()
    {
        //gameType = false;
    }

    public void setTrue()
    {
        gameType = true;
    }

    public void setFalse()
    {
        gameType = false;
    }

    public bool status()
    {
        if (gameType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
