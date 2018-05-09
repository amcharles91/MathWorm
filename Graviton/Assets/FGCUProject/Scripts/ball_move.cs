using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_move : MonoBehaviour {
    public float speed;
    private GameObject lHand;
    private GameObject rHand;
    private Vector3 leftHand;
    private Vector3 rightHand;
    private Vector3 moveVec;
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lHand = GameObject.Find("LHand");
        rHand = GameObject.Find("RHand");
    }

    private void FixedUpdate()
    {
        leftHand = lHand.transform.position - transform.position;
        rightHand = rHand.transform.position - transform.position;
        float moveHor = Vector3.Magnitude(rightHand) - Vector3.Magnitude(leftHand);
        Vector3 move = new Vector3(0.0f, 0.0f, -moveHor);

        rb.AddForce(move * speed);
    }
}
