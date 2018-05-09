using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathManager : MonoBehaviour {

    public int maxNumber, minNumber;
    public GameObject[] answerblocks;
    public GameObject problemBlock;
    private int wrong1, wrong2;
    private int rand1, rand2, answer;
    private int [] pickAnsw;

    // Use this for initialization
    void Start () {
        rand1 = Random.Range(minNumber, maxNumber);
        rand2 = Random.Range(minNumber, maxNumber);

        answer = rand1 * rand2;
        wrong1 = answer + Random.Range(0, 50);
        wrong2 = answer + Random.Range(0, 100);
        pickAnsw = new int [] {answer, wrong1, wrong2 };
        randoMethod();
        problemBlock.GetComponentInChildren<Text>().text = rand1 + " x " + rand2;
        //Debug.Log("rand1 =  " + rand1 + "  rand2 =  " + rand2 + "  the answer is  " + answer);
        //Debug.Log("wrong1 =  " + wrong1 + "  wrong2 =  " + wrong2);
    }

    private void randoMethod()
    {
        int last;
        bool used0 = false, used1=false, used2=false;
        foreach (GameObject ca in answerblocks)
        {

            last = Random.Range(0, 2);


            if (used0)
            {
                last = Random.Range(1, 2);
            }

            if (used1)
            {
                if (Random.Range(0,1) == 1)
                {
                    last = 1;
                }
                else
                {
                    last = 2;
                }
            }

            if (used2)
            {
                last = Random.Range(0, 1);
            }

            if (used0 && used1)
            {
                last = 2;
            }

            if(used1 && used2)
            {
                last = 0;
            }

            if(used0 && used2)
            {
                last = 1;
            }



            if (last == 0 && !used0)
            {
                ca.GetComponentInChildren<Text>().text = pickAnsw[last].ToString();
                ca.gameObject.GetComponent<Collider>().enabled = true;
                //ca.GetComponent<Text>().text = pickAnsw[last].ToString();
                ca.tag = "Wrong";
                used0 = true;
                    
            }
            else if (last == 1 && !used1)
            {
                ca.GetComponentInChildren<Text>().text = pickAnsw[last].ToString();
                ca.gameObject.GetComponent<Collider>().enabled = true;
                //ca.GetComponent<Text>().text = pickAnsw[last].ToString();
                ca.tag = "Wrong";
                used1 = true;
                   
            }
            else if (last == 2 && !used2) {
                ca.GetComponentInChildren<Text>().text = pickAnsw[last].ToString();
                ca.gameObject.GetComponent<Collider>().enabled = false;
                ca.tag = "Correct";
                //ca.GetComponent<Text>().text = pickAnsw[last].ToString();
                used2 = true;
                    
            }
            
            
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
