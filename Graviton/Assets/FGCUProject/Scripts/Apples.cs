using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Apples {

    List<int> appleList;
    private GameObject[] appleh;

    public Apples(GameObject [] apples)
    {
        this.appleh = apples;
        this.appleList = new List<int>();
    }

    public void addApple(int app)
    {
       this.appleList.Add(app);
    }

    public void setCorrect(int ans)
    {
        int randi = UnityEngine.Random.Range(0, 2);
        appleh[randi].GetComponentInChildren<Text>().text = ans.ToString();
        Debug.Log("this is apple instance " + appleh[randi].name);
        appleh[randi].tag = "Correct";
    }

    public void randomAnswer()
    {
        foreach (GameObject gb in appleh)
        {
            int rand = UnityEngine.Random.Range(0, 81);
            gb.GetComponentInChildren<Text>().text = rand.ToString();
            gb.tag = "Wrong";
        }
    }

}
