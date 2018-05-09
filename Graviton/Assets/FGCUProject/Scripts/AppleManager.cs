using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleManager : MonoBehaviour {

    private GameObject floaty;
  
    public GameObject[] apples;

    public System.Random a = new System.Random();

    public List<int> randomList = new List<int>();
    public int MyNumber = 0;

    private void NewNumber()
    {
        MyNumber = a.Next(0, 3);
        if (!randomList.Contains(MyNumber))
            this.randomList.Add(MyNumber);
    }


    // Use this for initialization
    void Start () {
        floaty = GameObject.FindGameObjectWithTag("MathManager");
        if (floaty.GetComponent<FloatMath>().wordProblem)
        {
            assignAnswer();
        }
        else
        {
            randomOrder();
        }
    }


    private void Update()
    {     

    }

    private void assignAnswer()
    {
        while(randomList.Count < 3)
        {
            NewNumber();
        }
        int randolistcounter = 0;

        //WordSheet temp = floaty.GetComponent<FloatMath>().currentWordSheet;
        Questions temp = floaty.GetComponent<FloatMath>().currentQuestion;

        foreach (GameObject gb in apples)
        {
            //NewNumber();
            Debug.Log(randomList[randolistcounter]);

            int caseSwitch = randomList[randolistcounter];
            switch (caseSwitch)
            {
                case 0:
                    gb.GetComponentInChildren<Text>().text = "A";
                    if (temp.getAnswerLetter().Equals("A"))
                    {
                        Debug.Log("Current answer is A");
                        gb.tag = "Apple";
                    }
                    else
                    {
                        gb.tag = "Apple";
                    }
                    break;
                case 1:
                    gb.GetComponentInChildren<Text>().text = "B";
                    if (temp.getAnswerLetter().Equals("B"))
                    {
                        Debug.Log("Current answer is B");
                        gb.tag = "Apple";
                    }
                    else
                    {
                        gb.tag = "Apple";
                    }
                    break;
                case 2:
                    gb.GetComponentInChildren<Text>().text = "C";
                    if (temp.getAnswerLetter().Equals("C"))
                    {
                        Debug.Log("Current answer is C");
                        gb.tag = "Apple";
                    }
                    else
                    {
                        gb.tag = "Apple";
                    }
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            randolistcounter++;
        }
    }

    private void randomOrder()
    {
        foreach (GameObject gb in apples)
        {
            int value = floaty.GetComponent<FloatMath>().randomAnswer();
            gb.GetComponentInChildren<Text>().text = value.ToString();
                
            if (floaty.GetComponent<FloatMath>().getAnswer() == value)
            {
                gb.tag = "Apple";
            }
            else
            {
                gb.tag = "Apple";
            }
           
        }
    }

    


}
