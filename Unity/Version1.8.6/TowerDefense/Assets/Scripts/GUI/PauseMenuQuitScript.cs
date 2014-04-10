using UnityEngine;
using System.Collections;

public class PauseMenuQuitScript : MonoBehaviour {

    public bool quitIsClicked;

	// Use this for initialization
	void Start () {
        quitIsClicked = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            quitIsClicked = true;
        }
    } 
}
