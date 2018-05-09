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

    private IEnumerator Start()
    {
        yield return StartCoroutine(StartPhase());
    }

    private IEnumerator StartPhase()
    {
        // Wait for the intro UI to fade in.
        yield return StartCoroutine(UIInteraction.ShowIntroUI());

        // Show the reticle (since there is now a selection slider) and hide the radial.
        m_Reticle.Show();
        m_SelectionRadial.Hide();

        yield return StartCoroutine(m_SelectionSlider.WaitForBarToFill());


        // Wait for the selection slider to finish filling.
        //yield return StartCoroutine(m_SelectionSlider.WaitForBarToFill());

        // Wait for the intro UI to fade out.
        yield return StartCoroutine(UIInteraction.HideIntroUI());
        SceneManager.LoadScene("MathWorm", LoadSceneMode.Single);
        
    }


}
