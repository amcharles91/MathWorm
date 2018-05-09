using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions {

    public string Question { get; set; }
    public string correct { get; set; }
    public string nonCor1 { get; set; }
    public string nonCor2 { get; set; }


    public string A { get; set; }
    public string B { get; set; }
    public string C { get; set; }

    private bool a = false;
    private bool b = false;
    private bool c = false;

    private int maxNumbers = 3;
    private List<int> uniqueNumbers;
    private List<int> finishedNumbers;
    private string[] letters;




    public Questions(string c_Question, string corA, string nonCorr1, string nonCorr2)
    {
        this.Question = c_Question;
        this.correct = corA;
        this.nonCor1 = nonCorr1;
        this.nonCor2 = nonCorr2;

        letters = new string[] {"A", "B", "C"};
        uniqueNumbers = new List<int>();
        finishedNumbers = new List<int>();
        GenerateRandomList();
        randomize();
    }

    public string getAnswerLetter()
    {
        if (a)
        {
            return "A";
        }
        else if (b)
        {
            return "B";
        }
        else
        {
            return "C";
        }
    }


    public void GenerateRandomList()
    {
        for (int i = 0; i < maxNumbers; i++)
        {
            uniqueNumbers.Add(i);
        }
        for (int i = 0; i < maxNumbers; i++)
        {
            int ranNum = uniqueNumbers[Random.Range(0, uniqueNumbers.Count)];
            finishedNumbers.Add(ranNum);
            uniqueNumbers.Remove(ranNum);
        }
    }

    private void randomize()
    {
        int pounter = 0;
        
        foreach (int n in finishedNumbers)//n is what spot corA, nonCorr1, nonCorr2 are going to take for the current letter
        {
            string temp = letters[pounter];
            assignLetter(temp, n);
            pounter++;
        }
    }

    private void assignLetter(string currentLetter, int position)
    {

        switch (position)
        {
            case 0:  //This is correct answer
                if (currentLetter.Equals("A"))
                {
                    this.A = correct;
                    a = true;
                }else if (currentLetter.Equals("B"))
                {
                    this.B = correct;
                    b = true;
                }
                else if(currentLetter.Equals("C"))
                {
                    this.C = correct;
                    c = true;
                }
                break;
            case 1:  //this is noncorrect1
                if (currentLetter.Equals("A"))
                {
                    this.A = nonCor1;
                }
                else if (currentLetter.Equals("B"))
                {
                    this.B = nonCor1;
                }
                else if (currentLetter.Equals("C"))
                {
                    this.C = nonCor1;
                }
                break;
            case 2:  //this is noncorrect2
                if (currentLetter.Equals("A"))
                {
                    this.A = nonCor2;
                }
                else if (currentLetter.Equals("B"))
                {
                    this.B = nonCor2;
                }
                else if (currentLetter.Equals("C"))
                {
                    this.C = nonCor2;
                }
                break;
            default:
                Debug.Log("Error in WordSheets");
                break;
        }
    }



}
