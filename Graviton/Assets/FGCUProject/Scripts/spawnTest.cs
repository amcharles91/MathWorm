using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject instance = Instantiate(Resources.Load("appleTest", typeof(GameObject))) as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
