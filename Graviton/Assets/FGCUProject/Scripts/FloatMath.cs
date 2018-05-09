using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatMath : MonoBehaviour {
    public int maxNumber, minNumber;
    public List<GameObject> answerblocks;
    public GameObject problemBlock;
    public GameObject wordProblemBlock;
    public bool hit;
    public bool setAnswer;
    public bool wordProblem = false;
    public AppleUpdate appleUpdater;
    public int correctAnswerSpeed;
    private bool isCoroutineExecuting = false;
    private int wrong1, wrong2, counter=0;
    private int rand1, rand2, answer;
    private int[] pickAnsw;
    private string conn;
    public int numberOfQuestions;
    //public String[,]questions;
    public String wordAnswer;
    private List<WordSheet> wordSheet;
    public WordSheet currentWordSheet;
    public Questions currentQuestion;
    private DataBase getQuestions;
    private List<Questions> QuestionData;

    private void Awake()
    {
        wordProblem = appleUpdater.wordProblem;
    }

    // Use this for initialization
    void Start()
    {

        if (wordProblem)
        {
            conn = "URI=file:" + Application.dataPath + "/StreamingAssets/HighScores.db"; //Path to database.;
            getQuestions = new DataBase(conn);
            QuestionData = getQuestions.readAllQuestion();//Sets up all the questions from database
            numberOfQuestions = QuestionData.Count;
            getQuestions.close();
            //setupRandomQuestions();
            problemBlock.SetActive(false);
            wordProblemBlock.SetActive(true);
            if(numberOfQuestions == 0)
            {
                Debug.Log("Number of Questions is 0");
                //numberOfQuestions = 1;
            }
            //questions = new String[numberOfQuestions,3];
            newWord();
            hit = false;
        }
        else
        {
            problemBlock.SetActive(true);
            wordProblemBlock.SetActive(false);
            newProblem();
            hit = false;
            setAnswer = false;
        }


        if(correctAnswerSpeed == 0)
        {
            correctAnswerSpeed = 1;
        }
    }

    private void setupRandomQuestions()
    {

        
        
        wordSheet = new List<WordSheet>();
        //int questCounter = 0;
        foreach (Questions q in QuestionData ){
            //wordSheet.Add(new WordSheet(q.Question));
            //wordSheet[questCounter].putAnswA(q.AnswerA, true);
           // wordSheet[questCounter].putAnswB(q.AnswerB, false);
            //wordSheet[questCounter].putAnswC(q.AnswerC, false);
        }

        
    }

    public int getAnswer()
    {
        return answer;
    }

    public String getWordAnswer()
    {
        return wordAnswer;
    }

    private void newWord()
    {
        int caseSwitch = UnityEngine.Random.Range(1, numberOfQuestions);
        Debug.Log("Number of questions in current game is "+ QuestionData.Count);

        assignNewQuestion(QuestionData[caseSwitch]);

    }

    private void assignNewQuestion(Questions qu)
    {
        currentQuestion = qu;
        String question = qu.Question;

        Debug.Log("Why is this now showing up correctly? " + qu.A +" "+ qu.B+ " " + qu.C);
        wordProblemBlock.GetComponentInChildren<Text>().text = question + "\n"
            + "A: " + qu.A + "\n"
            + "B: " + qu.B + "\n"
            + "C: " + qu.C + "\n";

        wordAnswer = qu.correct;
    }

    private void assignWord(WordSheet wordy)
    {
        currentWordSheet = wordy;
        String question = wordy.getQuestion();
        wordProblemBlock.GetComponentInChildren<Text>().text = question + "\n"
            + "A: "+ wordy.getAnswA() + "\n"
            + "B: "+ wordy.getAnswB() + "\n"
            + "C: "+ wordy.getAnswC() + "\n";

        wordAnswer = wordy.getAnswer();
    }

    private void newProblem()
    {
        rand1 = UnityEngine.Random.Range(minNumber, maxNumber);//chooses first random number
        rand2 = UnityEngine.Random.Range(minNumber, maxNumber);//chooses second random number

        answer = rand1 * rand2;//gets an answer
        //wrong1 = answer + Random.Range(0, 50);//first wrong answer
        //wrong2 = answer + Random.Range(0, 100);//second wrong answer
        //pickAnsw = new int[] { answer, wrong1, wrong2 };
        problemBlock.GetComponentInChildren<Text>().text = rand1 + " x " + rand2;
    }

    public WordSheet randoQuestionAnsw()
    {
        return currentWordSheet;
    }

    public int randomAnswer()
    {
        int number = 0;
        if (counter < correctAnswerSpeed) {
            number = UnityEngine.Random.Range(0, 81);
            counter++;
            return number;
        }
        else
        {
            correctAnswerSpeed = UnityEngine.Random.Range(1, 8);
            counter = 0;
            return answer;
        }

    }

 
    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(ExecuteAfterTime(5));

        if (hit)
        {
            if (wordProblem)
            {
                newWord();
                hit = false;
            }
            else
            {
                newProblem();
                hit = false;
            }
           
        }

    }



    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        setAnswer = true;

        yield return new WaitForSeconds(1);

        isCoroutineExecuting = false;
    }

}
