using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;

public class RefreshInvitesScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log((string)ParseUser.CurrentUser["username"]);
        var inviteQuery = ParseObject.GetQuery("Game").WhereEqualTo("p2username", (string)ParseUser.CurrentUser["username"]);

        inviteQuery.FindAsync().ContinueWith(t =>
            {
                IEnumerable<ParseObject> results = t.Result;
                foreach (var game in results)
                {
                    Debug.Log("You have been invited to a game by: " + (string)game["hostUsername"]);
                }
                
            });
    }
}
