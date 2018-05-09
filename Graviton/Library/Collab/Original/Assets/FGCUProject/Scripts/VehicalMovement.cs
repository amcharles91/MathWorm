using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicalMovement : MonoBehaviour {

    public float speed;
    public float edge;
    public float MaxTurn;
    public float turnSpeed;
    public leftTurn left;
    public rightTurn right;
    private Rigidbody rb;

    private Vector3 horizontalMovement;
    private Vector3 forwardMove;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        movement(Time.deltaTime);      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ColObject")
        {
            Destroy(collision.gameObject, 2);
            Debug.Log("Crashed into something! called a" + collision.gameObject.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.tag == "Wrong")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    private void movement(float delta)
    {
        forwardMove = transform.forward * delta * speed;
        horizontalMovement = transform.right * delta * turnSpeed;
        if (right.getTouched() && rb.position.x <= MaxTurn)
        {
            rb.MovePosition(rb.position + forwardMove + horizontalMovement);
        }
        else if (left.getTouched() && rb.position.x >= -MaxTurn)
        {
            rb.MovePosition(rb.position + forwardMove - horizontalMovement);
        }
        else
        {
            rb.MovePosition(rb.position + forwardMove);
        }
        

       
    }

}
