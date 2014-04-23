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
    public GameObject friendInGame;
    public int friendPictureIndex;

    public Vector3 objectPosition;

    public List<GameObject> friendPictureObjects;
    public List<Texture2D> friendPictures;

	// Use this for initialization
	void Start () {

        friendPictureIndex = 0;

        //Contains all Users who are Facebook friends with the "Current User"
        friendsInGame = new List<ParseUser>();

        friendPictureObjects = new List<GameObject>();

        friendPictures = new List<Texture2D>();

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

                            LoadFriendPicture((string)user["fId"], friendPictureIndex); // Maby make this as a coroutine.
                            friendPictureIndex++;
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

    void LoadFriendPicture(string userFacebookId, int index)
    {
        //Uses the userid to fetch the profile image and renders it onto a gameObject
        Facebook.instance.fetchProfileImageForUserId(userFacebookId, (tex) =>
        {

            Debug.Log("Loading friend picture..");
            //Debug.Log(playerName);
            if (tex != null)
            {
                //friendInGame.renderer.material.mainTexture = tex;
                friendPictures.Add(tex);
                friendPictureObjects.Add((GameObject)Resources.Load("friend_picture"));
                friendPictureObjects[index] = (GameObject)Instantiate(friendPictureObjects[index]);

                if (friendPictureObjects.Count > 1)
                    friendPictureObjects[index].transform.position = new Vector3(-13.19768f, 20.38656f + (7 * -index), 24.11262f);
                else
                    friendPictureObjects[index].transform.position = new Vector3(-13.19768f, 20.38656f, 24.11262f);

                friendPictureObjects[index].renderer.material.mainTexture = friendPictures[index];
                Debug.Log("Friend picture loaded!!!!!!!!!!!");
            }
        });
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 120, 120), friendsInGame[0]);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
