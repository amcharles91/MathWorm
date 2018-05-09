using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftTurn : MonoBehaviour {

    private bool isTouched;

    // Use this for initialization
    void Start () {
        isTouched = false;
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
