using UnityEngine;
using System.Collections;

public class PlayerReady : MonoBehaviour {

    public bool ready;

	// Use this for initialization
	void Start () {

        ready = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        ready = true; 
    }
}
