using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Common;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [SerializeField] private UIInteraction UIInteraction;
    [SerializeField] private Reticle m_Reticle;
    [SerializeField] private SelectionRadial m_SelectionRadial;
    [SerializeField] private SelectionSlider m_SelectionSlider;
    [SerializeField] private SelectionSlider m_SelectionSlider2;
    private bool idle = true;

    private IEnumerator Start()
    {

        // Continue looping through all the phases.
      //  while (true)
       // {
            yield return StartCoroutine(StartPhase());
       // }
    }

    private IEnumerator StartPhase()
    {
        // Wait for the intro UI to fade in.
        yield return StartCoroutine(UIInteraction.ShowIntroUI());

        // Show the reticle (since there is now a selection slider) and hide the radial.
        m_Reticle.Show();
        m_SelectionRadial.Hide();


        // Wait for the selection slider to finish filling.
        // StartCoroutine(m_SelectionSlider2.WaitForBarToFill());


        //Debug.Log("the setting bar finished");



        yield return idlePhase();

        Debug.Log("Idle Phase Ended");

        // Wait for the selection slider to finish filling.
        //yield return StartCoroutine(m_SelectionSlider.WaitForBarToFill());

        // Wait for the intro UI to fade out.
        //yield return StartCoroutine(UIInteraction.HideIntroUI());

        //ToGame();
    }

    private IEnumerator idlePhase()
    {

        Debug.Log("Idle Phase Started");
        while (idle)
        {
           yield return StartCoroutine(Settings());
            Debug.Log("Did it come here?");
        }

        //yield return StartCoroutine(Settings());
        //yield return StartCoroutine(GameStart());
        yield return null;
        

        Debug.Log("Did it come here?");

        // Wait for the intro UI to fade out.
        yield return StartCoroutine(UIInteraction.HideIntroUI());


        //ToGame();
    }

    private IEnumerator Settings()
    {
        //Debug.Log("Did it come Settings?");
        // Wait for the selection slider to finish filling.
        while (idle)
        {


            yield return StartCoroutine(m_SelectionSlider2.WaitForBarToFill());

            Debug.Log("Settings Window Popped Up");

            yield return null;
        }
    }

    private IEnumerator GameStart()
    {
        //Debug.Log("Did it come GameStart?");
        // Wait for the selection slider to finish filling.
        yield return StartCoroutine(m_SelectionSlider.WaitForBarToFill());
        ToGame();

    }


		
	public void ToGame()
	{
		SceneManager.LoadScene("MathWorm", LoadSceneMode.Single);
	}

}
