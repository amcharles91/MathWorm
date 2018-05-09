using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightTurn : MonoBehaviour {

    private bool isTouched;

    // Use this for initialization
    void Start () {
        isTouched = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouched = true;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouched = false;
        }
    }

    public bool getTouched()
    {
        return isTouched;
    }
}
