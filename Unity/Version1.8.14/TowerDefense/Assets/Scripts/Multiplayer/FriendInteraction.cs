using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using System.Threading.Tasks;

public class FriendInteraction : MonoBehaviour {

    public string parseUsername;
    bool previousQuery;
    public GameObject button;

	// Use this for initialization
	void Start () {
        previousQuery = true;
        button = (GameObject)Resources.Load("friend_interaction_button");

        button.GetComponent<FriendInviteButtonScript>().friendInteraction = gameObject;

        button = (GameObject)Instantiate(button);
        button.transform.position = new Vector3(button.transform.position.x, gameObject.transform.position.y, button.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if(previousQuery)
        {
            previousQuery = false;
            checkInvites();
        }
    }

    //Checks if youve already invited said player to a game.
    public void checkInvites()
    {
        var inviteQuery = ParseObject.GetQuery("TestGame").WhereEqualTo("hostUsername", (string)ParseUser.CurrentUser["username"]).WhereEqualTo("p2username", parseUsername).CountAsync().ContinueWith(t =>
        {
            int count = t.Result;

            if (count != 0)
            {
                Debug.Log("already invited this player to a game.");
                //Open game here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                button.GetComponent<FriendInviteButtonScript>().state = 0;
                previousQuery = true;
            }
            else
            {
                //inviteToGame();

                button.GetComponent<FriendInviteButtonScript>().state = 2;

                previousQuery = true;
            }
        });
    }

    public void startMpGame()
    {
        //Object.DontDestroyOnLoad((Object)parseUsername);
        Application.LoadLevel("Mp_game_scene");

    }

    //Creates a new game with the host and invited player.
    public void inviteToGame()
    {
        ParseObject game = new ParseObject("TestGame");

        game["InviteAccepted"] = false;
        game["P1Ready"] = false;
        game["P2Ready"] = false;
        game["TurnNumber"] = 0;
        game["hostUsername"] = (string)ParseUser.CurrentUser["username"];
        game["p2username"] = parseUsername;

        Task saveTask = game.SaveAsync();

    }

    void OnGUI()
    {
    }
}
