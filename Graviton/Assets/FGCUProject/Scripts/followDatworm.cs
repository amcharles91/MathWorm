using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDatworm : MonoBehaviour {

    public GameObject gb;

	// Use this for initialization
	void Start () {
        transform.parent = gb.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
