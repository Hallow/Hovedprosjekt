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

    public List<FacebookFriend> friendList;

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

            friendList = friends.data;
            printFriendsTest();
        });

	}

    
    void printFriendsTest()
    {

        List<String> friendIdList = new List<String>();

        foreach(FacebookFriend friend in friendList)
        {
            friendIdList.Add(friend.id);    
        }

        var friendQuery = ParseUser.Query.WhereContainedIn("fId", friendIdList);
        friendQuery.FindAsync().ContinueWith(t =>
            {
                IEnumerable<ParseUser> results = t.Result;

                List<String> idList = new List<String>();
                List<String> usernameList = new List<String>();

                foreach (var user in results)
                {
                    idList.Add((string)user["fId"]);
                    usernameList.Add((string)user["username"]);
                    Debug.Log((string)user["fId"]);
                }

                LoadFriendPicture(idList, friendPictureIndex, usernameList);
                
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

    void LoadFriendPicture(List<string> fbuserIdList, int index, List<string> parseUserNameList)
    {
        int usernameIndex = 0;
        bool previousQueryDone;

        //Uses the userid to fetch the profile image and renders it onto a gameObject
        foreach (string fbuser in fbuserIdList)
        {
            previousQueryDone = false;
            Debug.Log("Starting foreach for user with fid: " + fbuser);
            Debug.Log("Accompanied by this username: " + parseUserNameList[friendPictureIndex]);
            
            Facebook.instance.fetchProfileImageForUserId(fbuser, (tex) =>
            {
                if (tex != null)
                {
                    //friendInGame.renderer.material.mainTexture = tex;
                    friendPictures.Add(tex);
                    friendPictureObjects.Add((GameObject)Resources.Load("friend_picture"));
                    friendPictureObjects[friendPictureIndex] = (GameObject)Instantiate(friendPictureObjects[friendPictureIndex]);
                    friendPictureObjects[friendPictureIndex].GetComponent<FriendInteraction>().parseUsername = parseUserNameList[friendPictureIndex];

                    if (friendPictureObjects.Count > 1)
                        friendPictureObjects[friendPictureIndex].transform.position = new Vector3(-13.19768f, 20.38656f + (7 * -friendPictureIndex), 24.11262f);
                    else
                        friendPictureObjects[friendPictureIndex].transform.position = new Vector3(-13.19768f, 20.38656f, 24.11262f);

                    friendPictureObjects[friendPictureIndex].renderer.material.mainTexture = friendPictures[friendPictureIndex];
                    Debug.Log("Loaded picture with FiD: " + fbuser + "! ParseUsername: " + parseUserNameList[friendPictureIndex]);
                    
                    usernameIndex++;
                    friendPictureIndex++;

                    previousQueryDone = true;
                }
            });

            while (!previousQueryDone)
            {
                
            }


        }

        foreach (GameObject o in friendPictureObjects)
        {

        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI()
    {
    }
}
