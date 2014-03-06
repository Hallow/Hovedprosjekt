using UnityEngine;
using System.Collections;

// This script deals with interactions like back-button, menu button etc.

public class InteractionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Escape))	// If Esc or Backbutton on android is pressed, return to main menu.
		    Application.LoadLevel("Scene2");
	}
}
