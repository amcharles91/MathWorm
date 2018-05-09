using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VehicalMovement : MonoBehaviour {

    public float speed;
    public float edge;
    public float MaxTurn;
    public float turnSpeed;
    public int life, LifeCounter;
    public leftTurn left;
    public rightTurn right;
    public GameObject floatMath;
    public GameObject Score;
    private GameObject lHand;
    private GameObject rHand;
    private Vector3 leftHand;
    private Vector3 rightHand;
    public List<GameObject> AppleLives;
    public List<GameObject> LifeLost;
    public DeathMenu deathMenu;
    public AppleUpdate appleUpdate;

    [SerializeField] private AudioSource m_Audio;
    [SerializeField] private AudioClip[] test;

    private int corretNumber;
    private string correctLetter;
    private int scoreCount;
    private int bigCount;
    private Rigidbody rb;
    private WordSheet currentWurd;

    private Vector3 horizontalMovement;
    private Vector3 forwardMove;

    private AudioSource[] sounds;
    private bool ended;
    

    // Use this for initialization
    void Start () {
        speed = 6f;
        LifeCounter = 0;
        life = 3;
        scoreCount = 0;
        bigCount = 0;
        lHand = GameObject.Find("OVRCameraRig/TrackingSpace/LocalAvatar/LeftHandAnchor/LeftHand");
        rHand = GameObject.Find("OVRCameraRig/TrackingSpace/LocalAvatar/RightHandAnchor/RightHand");
        rb = GetComponent<Rigidbody>();
        sounds = gameObject.GetComponents<AudioSource>();
        //Debug.Log("The size of this array is " + sounds.Length);
	}
	
	// Update is called once per frame
	void Update () {
        if (!ended)
        {
            if (OVRInput.GetUp(OVRInput.Button.Start) || Input.GetKeyDown(KeyCode.H))
            {
                deathMenu.menu();
            }
        }

    }

    private void FixedUpdate()
    {
        //movement(Time.deltaTime);
        controllerMovement(Time.deltaTime);
    }

    private void experimentalControls(float delta)
    {
        Vector3 forwardMove;
        forwardMove = transform.forward * delta * speed;

        leftHand = lHand.transform.position - GameObject.Find("Cube").transform.position;
        rightHand = rHand.transform.position - GameObject.Find("Cube").transform.position;
        float moveHor = (Vector3.Magnitude(leftHand) - Vector3.Magnitude(rightHand)) * .5f;

        rb.MovePosition(rb.position + new Vector3(moveHor, 0.0f, 0.0f) + forwardMove);
    }

    private void controllerMovement(float delta)
    {
        Vector3 forwardMove;
        forwardMove = transform.forward * delta * speed;

        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        float hori = Input.GetAxis("Horizontal") * delta * speed;
        float verti = Input.GetAxis("Vertical") * delta * speed;
        Vector3 movement = new Vector3(hori * delta, 0.0f, verti);


        if (primaryAxis.y > 0.0f)
        {

        }

        if (primaryAxis.y < 0.0f)
        {

        }


        if (primaryAxis.x < 0.0f)
        {
            rb.MovePosition(rb.position + new Vector3(primaryAxis.x * Time.deltaTime * speed, 0, 0) + forwardMove);
        }
        else if(primaryAxis.x > 0.0f)
        {
            rb.MovePosition(rb.position + new Vector3(primaryAxis.x * Time.deltaTime * speed, 0, 0) + forwardMove);
        }else if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log(" You pressed A");
            rb.MovePosition(rb.position + new Vector3(hori, 0, 0) + forwardMove);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log(" You pressed D");
            rb.MovePosition(rb.position + new Vector3(hori, 0, 0) + forwardMove);
        }
        else
        {
            rb.MovePosition(rb.position + forwardMove);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            speed += 7;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            speed -= 7;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ColObject")
        {
            endGame();
            collision.gameObject.SetActive(false);
            Debug.Log("Crashed into something! called a" + collision.gameObject.name);  
        }

        if (collision.gameObject.tag == "greenapple")
        {
            Score.GetComponent<ManageScore>().score += 2;
            scoreCheck(2);
            collision.gameObject.SetActive(false);
            m_Audio.clip = test[1];
            m_Audio.Play();
            //sounds[1].Play();
            //Debug.Log("Crashed into something! called a" + collision.gameObject.name);
        }

        if (collision.gameObject.tag == "yellowapple")
        {
            Score.GetComponent<ManageScore>().score += 1;
            scoreCheck(1);
            collision.gameObject.SetActive(false);
            m_Audio.clip = test[1];
            m_Audio.Play();
            //sounds[1].Play();
            //Debug.Log("Crashed into something! called a" + collision.gameObject.name);
        }



        //Debug.Log("Crashed into something! called a " + collision.gameObject.tag);

        if (collision.gameObject.tag == "Wrong")
        {
            collision.gameObject.SetActive(false);

            m_Audio.clip = test[3];
            m_Audio.Play();
            m_Audio.clip = test[0];
            m_Audio.Play();
            //sounds[0].Play();
            //sounds[3].Play();
            Debug.Log("Crashed into something! called a" + collision.gameObject.name);
            speed = 7.0f;
            endGame();
        }

        if (collision.gameObject.tag == "Correct")
        {
            collision.gameObject.SetActive(false);
            m_Audio.clip = test[2];
            m_Audio.Play();
            m_Audio.clip = test[0];
            m_Audio.Play();
            //sounds[0].Play();
            //sounds[2].Play();
            floatMath.GetComponent<FloatMath>().hit = true;
            if (speed > 14)
            {
                speed = 14;
            }
            else
            {
                speed += 1.0f;
            }
            
            Score.GetComponent<ManageScore>().score += 10;
            scoreCheck(10);
        }

        if(collision.gameObject.tag == "Apple")
        {
            
            if (appleUpdate.wordProblem)
            {
                correctLetter = floatMath.GetComponent<FloatMath>().currentQuestion.getAnswerLetter();
                //Debug.Log(" The correct Letter turns out to be " + correctLetter);
                if (collision.gameObject.GetComponentInChildren<Text>().text.Equals(correctLetter))
                {
                   // Debug.Log("Correct Answer for now is " + correctLetter);
                    floatMath.GetComponent<FloatMath>().hit = true;
                    m_Audio.clip = test[2];
                    m_Audio.Play();
                    scoreCheck(10);
                    Score.GetComponent<ManageScore>().score += 10;
                    if (speed > 14)
                    {
                        speed = 14;
                    }
                    else
                    {
                        speed += 1.0f;
                    }
                }
                else
                {
                    //Debug.Log("Correct Answer for now is " + correctLetter);
                    m_Audio.clip = test[3];
                    m_Audio.Play();
                    endGame();
                }
                collision.gameObject.SetActive(false);
                
            }
            else
            {
                //Debug.Log(" is it really running this instead " + correctLetter);
                corretNumber = floatMath.GetComponent<FloatMath>().getAnswer();
                if (collision.gameObject.GetComponentInChildren<Text>().text.Equals(corretNumber.ToString()))
                {
                    floatMath.GetComponent<FloatMath>().hit = true;
                    Score.GetComponent<ManageScore>().score += 10;
                    m_Audio.clip = test[2];
                    m_Audio.Play();
                    scoreCheck(10);
                    if (speed > 14)
                    {
                        speed = 14;
                    }
                    else
                    {
                        speed += 1.0f;
                    }
                }
                else
                {
                    m_Audio.clip = test[3];
                    m_Audio.Play();
                    endGame();
                }
                collision.gameObject.SetActive(false);
            }


        }
    }

    private void endGame()
    {

        GameObject.FindGameObjectWithTag("Life" + life).SetActive(false);
        LifeLost[LifeCounter].SetActive(true);
        //GameObject.FindGameObjectWithTag("LifeLost" + life).SetActive(true);
        LifeCounter++;
        life -= 1;
        if (life == 0)
        {
            ended = true;
            speed = 0;
            deathMenu.ToggleEndMenu(Score.GetComponent<ManageScore>().score);
        }
    }


    private void movement(float delta)
    {
        forwardMove = transform.forward * delta * speed;
        horizontalMovement = transform.right * delta * speed;
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

    private void scoreCheck(int add)
    {
        scoreCount += add;
        //Debug.Log("current score is " + scoreCount);
        if (scoreCount >= 100 && bigCount < 9)
        {
            Debug.Log("100 points!");
            //m_Audio.clip = test[4];
            //m_Audio.Play();
            //Debug.Log("Did you play");
            sounds[4].Play();
            bigCount++;
            scoreCount = 0;
        }
        else if (scoreCount >= 100 && bigCount >= 9)
        {
            //m_Audio.clip = test[5];
            //m_Audio.Play();
            Debug.Log("1000 points!");
            sounds[5].Play();
            bigCount = 0;
            scoreCount = 0;
        }
    }

}
