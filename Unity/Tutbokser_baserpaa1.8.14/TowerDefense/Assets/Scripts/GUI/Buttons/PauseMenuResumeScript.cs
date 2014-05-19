using UnityEngine;
using System.Collections;

public class PauseMenuResumeScript : MonoBehaviour {

    public bool resumeIsClicked;

	// Use this for initialization
	void Start () {
        resumeIsClicked = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            resumeIsClicked = true;
        }
    }
}
