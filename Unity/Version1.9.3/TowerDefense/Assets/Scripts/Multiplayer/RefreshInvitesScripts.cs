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
        var acceptQuery = ParseObject.GetQuery("Game").WhereEqualTo("hostUsername", (string)ParseUser.CurrentUser["username"]);

        inviteQuery.Or(acceptQuery).FindAsync().ContinueWith(t =>
            {
                IEnumerable<ParseObject> results = t.Result;

                foreach (ParseObject po in results)
                {
                    if ((string)po["hostUsername"] == (string)ParseUser.CurrentUser["username"] && (bool)po["InviteAccepted"])
                    {
                        GameObject friend = GameObject.Find((string)po["p2username"]);
                        if(friend.GetComponent<FriendInteraction>().hasClicked)
                        {
                            friend.GetComponent<FriendInteraction>().result = po;
                            friend.GetComponent<FriendInteraction>().inviteBtn.GetComponent<InviteScript>().state = 3;
                            friend.GetComponent<FriendInteraction>().inviteBtn.GetComponent<InviteScript>().transformCheck = true;
                        }
                    }

                    else if ((string)po["p2username"] == (string)ParseUser.CurrentUser["username"] && !(bool)po["InviteAccepted"])
                    {
                        GameObject friend = GameObject.Find((string)po["hostUsername"]);
                        if (friend.GetComponent<FriendInteraction>().hasClicked)
                        {
                            friend.GetComponent<FriendInteraction>().result = po;
                            friend.GetComponent<FriendInteraction>().inviteBtn.GetComponent<InviteScript>().state = 2;
                            friend.GetComponent<FriendInteraction>().inviteBtn.GetComponent<InviteScript>().transformCheck = true;
                        }
                    }
                }
            });
    }
}
