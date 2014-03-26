using UnityEngine;
using System.Collections;
using System.Threading;

public class SingleplayerButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Thread.Sleep(1000);
        Application.LoadLevel("game_scene");
    }
}
