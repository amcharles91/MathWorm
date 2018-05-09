using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {
    Rigidbody rb;
    public float speed;
    public float turnSpeed;
    public float MaxTurn;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 10;
        turnSpeed = 10;
        MaxTurn = 9;
	}
	
	// Update is called once per frame
	void Update () {


	}

    private void FixedUpdate()
    {
       // translaterr(Time.deltaTime);
        //notKinematic(Time.deltaTime);

    }

    private void translaterr(float delta)
    {
        Vector3 forwardMove;
        forwardMove = transform.forward * delta * speed;
        rb.MovePosition(rb.position +forwardMove);
        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        if (primaryAxis.y > 0.0f)
        {
          
        }        

        if (primaryAxis.y < 0.0f)
        {

        }
            
        if (primaryAxis.x < 0.0f)
        {
            rb.MovePosition(rb.position + new Vector3(primaryAxis.x * Time.deltaTime * turnSpeed, 0 ,0)+forwardMove);
        }
           
        if (primaryAxis.x > 0.0f)
        {
            rb.MovePosition(rb.position + new Vector3(primaryAxis.x * Time.deltaTime * turnSpeed, 0, 0) + forwardMove);         
        }

    }

    private void notKinematic(float delta)
    {
        //OVRInput.Update();
        //Primary is left controller
        //Secondary is right controller
        Vector2 PrimaryThumb = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector2 SecondaryThumb = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);


        // Set some local float variables equal to the value of our Horizontal and Vertical Inputs
        float moveHorizontal = PrimaryThumb.x;//Input.GetAxis("Horizontal");
        float moveVertical = PrimaryThumb.y;//Input.GetAxis("Vertical");

        // Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
        // multiplying it by 'speed' - our public player speed that appears in the inspector
        rb.AddForce(movement * speed);
    }
}
