using UnityEngine;
using System.Collections;

public class PlayerReady : MonoBehaviour {

    //Ready is used to check whether the player has pressed the "End turn" button
    public bool ready;
    //public GameObject loop;

	// Use this for initialization
	void Start () {

        ready = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        //The player has clicked "End Turn", so he is ready.
        ready = true;
        //loop.GetComponent<GameLoop>().turnNumber++;
    }
}
