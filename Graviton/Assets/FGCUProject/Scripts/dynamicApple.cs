using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicApple : MonoBehaviour {

    public float speed;
    public float boundary;
    public float vertBoundaryTop;
    public float vertBoundaryLow;
    public bool vertical;
    private bool move;
    private bool vertMove;

	// Use this for initialization
	void Start () {
        move = true;
        vertMove = true;
	}
	
	// Update is called once per frame
	void Update () {
        moveApple(Time.deltaTime);
	}

    public void moveApple(float delta)
    {
        if (vertical)
        {
            if (vertMove)
            {
                transform.Translate(0, speed * delta, 0);
                if (transform.position.y >= vertBoundaryTop)
                {
                    vertMove = false;
                }
            }
            else
            {
                transform.Translate(0, -speed * delta, 0);
                if (transform.position.y <= vertBoundaryLow)
                {
                    vertMove = true;
                }
            }
        }
        else
        {
            if (move)
            {
                transform.Translate(speed * delta, 0, 0);
                if (transform.position.x >= boundary)
                {
                    move = false;
                }
            }
            else
            {
                transform.Translate(-speed * delta, 0, 0);
                if (transform.position.x <= -boundary)
                {
                    move = true;
                }
            }
        }

        
    }


}
