using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnScript : MonoBehaviour {



	public bool playerReady = false; //bool check
	public bool enemyReady = false;

    public bool allReady = false;

    public int turnNumber;



	// Use this for initialization
	void Start () {

        turnNumber = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(playerReady && enemyReady)
        {
            allReady = true;
        }

        if(!playerReady && !enemyReady && allReady)
        {
            allReady = false;
            turnNumber++;
        }
		
	}

	void OnMouseDown()
	{
        if(!playerReady)
        {
            playerReady = true;
            //turnNumber++;
        }
		
		//TODO: Start tower and unit logic here somehow
	}
}
