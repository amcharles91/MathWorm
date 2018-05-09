using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MainMenuTest {

	[Test]
	public void MainMenuTestSimplePasses() {
		// Use the Assert class to test conditions.

		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene () == UnityEngine.SceneManagement.SceneManager.GetSceneByName ("MathWorm")) {
			
			if (UnityEngine.GameObject.Find ("Canvas").activeSelf == true) {

				Assert.Pass();
			
			}

			//Assert.AreEqual (UnityEngine.GameObject.Find ("Canvas").activeSelf == true, true);

		//Assert.Fail ();
		}

	
			

		/*
		// Create a temporary reference to the current scene.
		UnityEngine.SceneManagement.Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene ();

		// Retrieve the name of this scene.
		string sceneName = currentScene.name;

		if (sceneName == "MathWorm") 
		{
			if (UnityEngine.GameObject.Find ("Canvas").activeSelf == true) {

				Assert.Pass ();

			}
		}

		*/

	}
	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator MainMenuTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}


}
