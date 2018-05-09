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

        while (idle)
        {
            yield return null;
        }
        // Wait for the intro UI to fade out.
        yield return StartCoroutine(UIInteraction.HideIntroUI());

    }




    public void ToGame()
	{
		SceneManager.LoadScene("MathWorm", LoadSceneMode.Single);
	}

}
