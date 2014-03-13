using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {

		if (GUI.Button (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 150, 250, 60), "Start")) {
			Application.LoadLevel ("demo_level");
		}

		if (GUI.Button(new Rect ((Screen.width / 2) -100, (Screen.height / 2) + 150, 250, 60), "Exit")) {
			Application.Quit();
		}
	}
}
