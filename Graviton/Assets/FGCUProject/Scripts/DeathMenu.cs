using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public VehicalMovement collision;
    public static bool GameIsPaused = false;
    private static bool ended;
    public DataBase db;
    private string conn;
    [SerializeField] EndScore currentScore;
    [SerializeField] ManageScore last;
    [SerializeField] Text resText;


	// Use this for initialization
	void Start () {
        //gameObject.SetActive (false);
        //conn = "URI=file:" + Application.dataPath + "/HighScores.db"; //Path to database.;
        Debug.Log("Is this working");
        //db = new DataBase(conn);
        
    }
	
	// Update is called once per frame
	void Update () {
        if(ended)
        if (OVRInput.GetUp(OVRInput.Button.Start) || Input.GetKeyDown(KeyCode.H))
        {
                restart();
        }

    }

    public void menu()
    {
        if (gameObject.activeSelf)
        {
            resume();
        }
        else
        {
            pause();
        }
        
    }

    private void pause()
    {
        gameObject.SetActive(true);
        currentScore.getScore();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

	public void ToggleEndMenu(float score){
		gameObject.SetActive (true);
        ended = true;
        conn = "URI=file:" + Application.dataPath + "/StreamingAssets/HighScores.db"; //Path to database.;
        db = new DataBase(conn);
        Debug.Log("What is the current score damant " + score);
        int scoregoodie = (int)score;
        db.updateRecord("user", scoregoodie);
        currentScore.getScore();
        //restart();
    }

	public void restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}	

	public void ToMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
