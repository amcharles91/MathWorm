using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class playButton : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject deathmenu;
    private bool selected;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Stop lookking at me");
        selected = true;
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("You stopped yay");
        selected = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    private void Start()
    {
        
        selected = false;
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            if (selected)
            {
                deathmenu.SetActive(false);
                Debug.Log("we made it");
            }
        }
    }

}
