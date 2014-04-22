using UnityEngine;
using System.Collections;
using Prime31;
using Parse;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

public class FacebookTestScript : MonoBehaviour {

    private string _userId;
    public List<ParseUser> friendsInGame;

	// Use this for initialization
	void Start () {

        //Contains all Users who are Facebook friends with the "Current User"
        friendsInGame = new List<ParseUser>();

        //This lambda method gets the current users Facebook information.
        Facebook.instance.getMe((error, result) =>
        {
            // if we have an error we dont proceed any further
            if (error != null)
                return;

            if (result == null)
                return;

            // grab the userId and persist it for later use
            _userId = result.id;

            ParseLogIn(_userId, FacebookCombo.getAccessToken());

            //Debug.Log("me Graph Request finished: ");
            //Debug.Log(result);

            //Checks if the surrounding method has found the user from Facebook
            if (_userId != null)
            {
                //Uses the userid to fetch the profile image and renders it onto a gameObject
                Facebook.instance.fetchProfileImageForUserId(_userId, (tex) =>
                {
                    if (tex != null)
                    {
                        gameObject.renderer.material.mainTexture = tex;
                    }
                });
            }
            else
            {
                //Debug.Log("USER ID IS NULL!!!!!!!!!!!!!!!!!!!!!");
            }
        });

        //Gets all the logged in users (Facebook) friends
        Facebook.instance.getFriends((error, friends) =>
        {
            if (error != null)
            {
                Debug.LogError("error fetching friends: " + error);
                return;
            }

            //Loops through the array of Facebook friends
            foreach (var friend in friends.data)
            {
                //For each Facebook Friend, Parse is checked for a user with the corresponding Facebook ID (fID), and if found, adds
                //said user to the "friendsInGame" list of ParseUsers.
                var userQuery = ParseUser.Query.WhereEqualTo("fId", friend.id);

                ParseUser.Query.WhereEqualTo("fId", friend.id).FindAsync().ContinueWith(t =>
                    {
                        IEnumerable<ParseUser> friendsPlaying = t.Result;

                        foreach (var user in friendsPlaying)
                        {
                            friendsInGame.Add(user);
                            Debug.Log("Found friend with Facebook Id: " + user["fId"]);
                        }
                    });
            }
        });
	}


    //Logs the user in to Parse, accepts Facebook userId and a Facebook accessToken
    void ParseLogIn(string userId, string accessToken)
    {
        //Logs the user in via Facebook
        Task<ParseUser> logInTask = ParseFacebookUtils.LogInAsync(userId, accessToken, DateTime.Now);

        //Gets the current User and saves the Facebook ID to the Parse "User" table.
        ParseUser cUser = ParseUser.CurrentUser;
        cUser["fId"] = userId;
        Task saveTask = cUser.SaveAsync();


    }

    void OnGUI()
    {
        //GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 120, 120), friendsInGame[0]);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
