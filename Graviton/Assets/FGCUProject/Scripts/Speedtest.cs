using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedtest : MonoBehaviour {
    public GameObject gb;
    private VehicalMovement veh;
    private bool started = false;

	// Use this for initialization
	void Start () {
        veh = gb.GetComponent<VehicalMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!started)
            {
                veh.speed = 7.0f;
                started = true;
            }
            
        }
        
    }
}
