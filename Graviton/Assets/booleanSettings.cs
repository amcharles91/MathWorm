using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booleanSettings : MonoBehaviour {
    bool questions;
    bool controls;
    bool created = false;

	// Use this for initialization
	void Start () {
		
	}

     void Awake() {
        if (!created)
        {
            DontDestroyOnLoad(transform.root.gameObject);
            created = true;
            Debug.Log("Woke: " + this.gameObject);
        }
     }

    // Update is called once per frame
    void Update () {
		
	}
}
