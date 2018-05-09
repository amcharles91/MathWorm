using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PauseMenuTest {

	[Test]
	public void PauseMenuTestSimplePasses() {
		// Use the Assert class to test conditions.
		if (Input.GetKeyDown ("h") == true && UnityEngine.GameObject.Find ("DeathMenu").activeSelf == true) {
			Assert.Pass ();
		} 

		else if (Input.GetKeyDown ("h") == true && UnityEngine.GameObject.Find ("DeathMenu").activeSelf == false) {
			Assert.Pass ();
		}

	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator PauseMenuTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}

}
