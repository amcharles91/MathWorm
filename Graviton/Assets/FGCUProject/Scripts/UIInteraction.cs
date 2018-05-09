using System.Collections;
using System.Collections.Generic;
using VRStandardAssets.Common;
using VRStandardAssets.Utils;
using UnityEngine.UI;
using UnityEngine;

public class UIInteraction : MonoBehaviour {

    [SerializeField] private UIFader m_IntroUI;     // This controls fading the UI shown during the intro.
    [SerializeField] private UIFader m_OutroUI;     // This controls fading the UI shown during the outro.
    //[SerializeField] private UIFader m_PlayerUI;    // This controls fading the UI that shows around the gun that moves with the player.
    //[SerializeField] private Text m_TotalScore;     // Reference to the Text component that displays the player's score at the end.
    //[SerializeField] private Text m_HighScore;      // Reference to the Text component that displays the high score at the end.


    public IEnumerator ShowIntroUI()
    {
        yield return StartCoroutine(m_IntroUI.InteruptAndFadeIn());
    }


    public IEnumerator HideIntroUI()
    {
        yield return StartCoroutine(m_IntroUI.InteruptAndFadeOut());
    }


    public IEnumerator ShowOutroUI()
    {
        //m_TotalScore.text = SessionData.Score.ToString();
        //m_HighScore.text = SessionData.HighScore.ToString();

        yield return StartCoroutine(m_OutroUI.InteruptAndFadeIn());
    }


    public IEnumerator HideOutroUI()
    {
        yield return StartCoroutine(m_OutroUI.InteruptAndFadeOut());
    }


}
