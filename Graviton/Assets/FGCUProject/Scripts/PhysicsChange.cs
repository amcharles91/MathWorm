using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PhysicsChange : MonoBehaviour {
    public Collider RightHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.Equals(RightHand))
        {
            SceneManager.LoadScene("PhysicsScene", LoadSceneMode.Single);
        }
        
    }

    
}
