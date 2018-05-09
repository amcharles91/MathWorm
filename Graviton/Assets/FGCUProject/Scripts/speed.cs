using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class speed : MonoBehaviour {
    public GameObject op;
    Text txt;
    VehicalMovement mo;
    
    // Use this for initialization
    void Start()
    {
        mo = op.GetComponent<VehicalMovement>();
        txt = GetComponent<Text>();
        txt.text = "Current Speed: ";
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Current Speed: " + mo.speed;
    }

    
}
