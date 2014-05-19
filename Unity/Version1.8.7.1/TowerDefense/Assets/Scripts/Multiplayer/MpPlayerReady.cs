using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;

public class MpPlayerReady : MonoBehaviour {

    public GameObject loop;
    public string ownerUsername;
    public bool ready;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (ParseUser.CurrentUser["username"].ToString().Equals(ownerUsername))
        {
            ready = true;
        }

    }

    void uploadRoundData(List<GameObject> unitList, List<GameObject> towerList, string gameId) //TODO: Missing list of "upgrades"
    {
        ParseObject Game = new ParseObject("Game");
        Game["objectId"] = gameId;
        
    }
}
