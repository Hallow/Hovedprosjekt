using UnityEngine;
using System.Collections;

public class WinloseContinueButtonScript : MonoBehaviour {

    public bool continueIsClicked;
    public GameObject loop;

	// Use this for initialization
	void Start () {
        continueIsClicked = false;
        loop = GameObject.Find("GameLoop");
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            continueIsClicked = true;
            loop.GetComponent<GameLoop>().Close();
            loop.GetComponent<GameLoop>().Reset();
            loop.GetComponent<GameLoop>().roundActive = false;
            loop.GetComponent<GameLoop>().winloseCalled = false;
            loop.GetComponent<GameLoop>().player1Ready.GetComponent<PlayerReady>().ready = false;
            loop.GetComponent<GameLoop>().decided = false;
            loop.GetComponent<GameLoop>().DestroyAllUnits();

            Time.timeScale = 1;
        }
    }
}
