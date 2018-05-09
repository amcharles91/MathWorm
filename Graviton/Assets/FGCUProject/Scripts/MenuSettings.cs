using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;


namespace VRStandardAssets.MenuSettings
{
    public class MenuSettings : MonoBehaviour
    {


        [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
        [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
        [SerializeField] private GameObject m_OutroCanvas;       
        [SerializeField] private GameObject m_IntroCanvas;       




        private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.
        private bool m_SettingActive;


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            //m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            //m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
        }


        private void HandleOver()
        {
            // When the user looks at the rendering of the scene, show the radial.
            m_SelectionRadial.Show();

            m_GazeOver = true;
        }


        private void HandleOut()
        {
            // When the user looks away from the rendering of the scene, hide the radial.
            m_SelectionRadial.Hide();

            m_GazeOver = false;
        }

        private void HandleClick()
        {
            if (m_GazeOver)
            {
                if (m_SettingActive)
                {
                    m_OutroCanvas.SetActive(false);
                    m_IntroCanvas.SetActive(true);
                    //this.gameObject.SetActive(true);
                }
                else
                {
                    m_OutroCanvas.SetActive(true);
                    m_IntroCanvas.SetActive(false);
                    //this.gameObject.SetActive(false);
                }
                
            }

        }


        private void HandleSelectionComplete()
        {
            // If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
            if (m_GazeOver)
                Debug.Log("Gaze is over");
                //StartCoroutine();
        }


    }
}
