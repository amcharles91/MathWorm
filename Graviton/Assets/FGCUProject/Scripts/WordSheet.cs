using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSheet {
    private string Question;
    private string answerA, answerB, answerC;
    private bool ansA, ansB, ansC;


    public WordSheet(string question)
    {
        this.Question = question;
        this.ansA = false;
        this.ansB = false;
        this.ansC = false;
    }

    public string getQuestion()
    {
        return this.Question;
    }

    public string getAnswer()
    {
        if (ansA)
        {
            return answerA;
        }
        else if (ansB)
        {
            return answerB;
        }
        else
        {
            return answerC;
        }        
    }

    public string getAnswerLetter()
    {
        if (ansA)
        {
            return "A";
        }
        else if (ansB)
        {
            return "B";
        }
        else
        {
            return "C";
        }
    }

    public void putAnswA(string ansA, bool type) {
        this.answerA = ansA;
        if (type)
        {
            this.ansA = true;
        }
    }

    public void putAnswB(string ansB, bool type)
    {
        this.answerB = ansB;
        if (type)
        {
            this.ansB = true;
        }
    }

    public void putAnswC(string ansC, bool type)
    {
        this.answerC = ansC;
        if (type)
        {
            this.ansC = true;
        }
    }

    public string getAnswA()
    {
        return answerA;
    }

    public string getAnswB()
    {
        return answerB;
    }

    public string getAnswC()
    {
        return answerC;
    }

    public string currentLetter()
    {
        if (ansA)
        {
            return "A";
        }
        else if (ansB)
        {
            return "B";
        }
        else
        {
            return "C";
        }
    }

}
