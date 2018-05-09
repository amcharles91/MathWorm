using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageScore : MonoBehaviour {

    public int score;
    public GameObject scoreBoard;

	// Use this for initialization
	void Start () {
        score = 0;

	}
	
	// Update is called once per frame
	void Update () {
        scoreBoard.GetComponentInChildren<Text>().text = "score: " + score;

    }

    public int getScore()
    {
        return score;
    }
}
