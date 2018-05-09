using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleUpdate : MonoBehaviour {


    public bool wordProblem;
    [SerializeField] carryOver carrie;

    public void Awake()
    {
        if (carrie.status())
        {
            wordProblem = true;
            Debug.Log(" carrie is currently true");
        }
        else
        {
            wordProblem = false;
            Debug.Log(" carrie is currently false");
        }
        
        //wordProblem = true;

    }

}
