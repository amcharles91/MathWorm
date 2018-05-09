using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.SceneManagement;

public class QuestionManger : MonoBehaviour {

    [SerializeField] InputField i_QuestionBox;
    [SerializeField] InputField i_AnswerA;
    [SerializeField] InputField i_AnswerB;
    [SerializeField] InputField i_AnswerC;

    [SerializeField] Animator cameraAni;
    [SerializeField] Toggle tog;
    [SerializeField] carryOver passOver;

    private string i_question;
    private string i_answA;
    private string i_answB;
    private string i_answC;

    private string conn;
    private DataBase data;

    public void OnSubmit()
    {
        i_question = i_QuestionBox.text;
        i_answA = i_AnswerA.text;
        i_answB = i_AnswerB.text;
        i_answC = i_AnswerC.text;

        conn = "URI=file:" + Application.dataPath + "/StreamingAssets/HighScores.db";
        data = new DataBase(conn);
        data.insertQuestion(i_question, i_answA, i_answB, i_answC);
        i_QuestionBox.text = "";
        i_AnswerA.text = "";
        i_AnswerB.text = "";
        i_AnswerC.text = "";
    }

    public void startGame()
    {
        SceneManager.LoadScene("UnEditedMenu", LoadSceneMode.Single);
    }

    public void createQuestion()
    {
        //cameraAni.SetBool("ani", false);
        cameraAni.Play("Animation2");
        Debug.Log("createQuestion pushed");
    }

    public void gameType()
    {
        if (tog.isOn)
        {
            passOver.setTrue();
            Debug.Log("check");
        }
        else
        {
            passOver.setFalse();
            Debug.Log("UnCheck");
        }
    }

    public void goToList()
    {
        //cameraAni.SetBool("ani", true);
        cameraAni.Play("Animation1");
        Debug.Log("goToList pushed");
    }
}
