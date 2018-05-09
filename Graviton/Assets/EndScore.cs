using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour {

    [SerializeField]ManageScore gameScore;
    private int score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void getScore()
    {
        GetComponentInChildren<Text>().text = "Score: " + gameScore.getScore();
    }
}
