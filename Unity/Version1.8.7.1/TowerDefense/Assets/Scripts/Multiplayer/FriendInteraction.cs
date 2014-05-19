using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using System.Threading.Tasks;

public class FriendInteraction : MonoBehaviour {

    public string parseUsername;
    public string gameId;
    bool previousQuery;

    //GUI ELEMENT PREFABS
    public GameObject inviteBtnPrefab;
    public GameObject pendingBtnPrefab;
    public GameObject playBtnPrefab;

    public GameObject inviteBtn;
    public GameObject pendingBtn;
    public GameObject playBtn;

    public GameObject persistentStorage;

    public bool hasClicked = false;

    //TEST
    public ParseObject result;
    

	// Use this for initialization
	void Start () {
        previousQuery = true;
        gameObject.name = parseUsername;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown()
    {
        if(!hasClicked)
        {
            if (previousQuery)
            {
                previousQuery = false;
                checkInvites();
            }
            hasClicked = true;
        }
        else
        {
            GameObject.Destroy(inviteBtn);
            hasClicked = false;
        }
        
    }

    //Checks if youve already invited said player to a game.
    void checkInvites()
    {
        //Query 1 checks if the current user has invited the clicked user to a game already
        //Query 2 checks if the clicked user has invited the current user to a game already
        var query1 = ParseObject.GetQuery("Game").WhereEqualTo("hostUsername", (string)ParseUser.CurrentUser["username"]).WhereEqualTo("p2username", parseUsername);
        var query2 = ParseObject.GetQuery("Game").WhereEqualTo("hostUsername", parseUsername).WhereEqualTo("p2username", (string)ParseUser.CurrentUser["username"]);
                
        //Runs both query 1 and query 2, and counts the combined results.
        query1.Or(query2).CountAsync().ContinueWith(t =>
        {
            int count = t.Result;

            if (count != 0) //If clause fires if theres already a game in progress or an invite has been sent in either direction.
            {
                Debug.Log("already invited this player to a game.");
                query1.Or(query2).FirstAsync().ContinueWith(y =>
                {
                    result = y.Result;
                    
                    //Next 2 lines are for testing purposes.
                    gameId = result.ObjectId;
                    Debug.Log("Game: " + gameId);

                    
                    previousQuery = true;
                    //TODO: Check if invite has been accepted.
                    if((bool)result["InviteAccepted"])
                    {
                        Debug.Log("Invite has been accepted, game starting");
                        inviteBtn = (GameObject)GameObject.Instantiate(inviteBtnPrefab);
                        inviteBtn.GetComponent<InviteScript>().parentFriend = gameObject;
                        inviteBtn.renderer.material = inviteBtn.GetComponent<InviteScript>().playMaterial;
                        inviteBtn.GetComponent<InviteScript>().state = 3;

                        //Button Positioning:
                        Vector3 pos = new Vector3();
                        pos.x = transform.position.x + 9f;
                        pos.y = transform.position.y;
                        pos.z = transform.position.z - 5f;
                        inviteBtn.transform.position = pos;

                        //startMpGame(result);
                    }
                    else
                    {
                        Debug.Log("Player has not accepted the invite yet. Pending.");
                        inviteBtn = (GameObject)GameObject.Instantiate(inviteBtnPrefab);
                        inviteBtn.GetComponent<InviteScript>().parentFriend = gameObject;

                        if(result["hostUsername"].ToString().Equals((string)ParseUser.CurrentUser["username"]))
                        {
                            inviteBtn.renderer.material = inviteBtn.GetComponent<InviteScript>().pendingMaterial;
                            inviteBtn.GetComponent<InviteScript>().state = 1;
                        }
                        else
                        {
                            inviteBtn.renderer.material = inviteBtn.GetComponent<InviteScript>().acceptMaterial;
                            inviteBtn.GetComponent<InviteScript>().state = 2;
                        }

                        //Button Positioning:
                        Vector3 pos = new Vector3();
                        pos.x = transform.position.x + 9f;
                        pos.y = transform.position.y;
                        pos.z = transform.position.z - 5f;
                        inviteBtn.transform.position = pos;
                    }
                    

                });
                //List<ParseObject> list = await getData.FindAsync().Result;
                //Open game here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                //t.Result.
            }
            else
            {
                Debug.Log("HAIIAIAIAIASØFOASF");
                inviteBtn = (GameObject)GameObject.Instantiate(inviteBtnPrefab);
                inviteBtn.GetComponent<InviteScript>().parentFriend = gameObject;
                inviteBtn.renderer.material = inviteBtn.GetComponent<InviteScript>().inviteMaterial;
                inviteBtn.GetComponent<InviteScript>().state = 0;

                //Button Positioning:
                Vector3 pos = new Vector3();
                pos.x = transform.position.x + 9f;
                pos.y = transform.position.y;
                pos.z = transform.position.z-5f;
                inviteBtn.transform.position = pos;

                //inviteToGame();
                previousQuery = true;
            }
        });
    }

    //Collects data on a game already in progress, stores them in a persistent gameObject, and goes to the gameplay scene for MP
    public void startMpGame(ParseObject Result)
    {
        Debug.Log("startMpGame has been called nigga");
        //Object.DontDestroyOnLoad((Object)parseUsername);
        persistentStorage = GameObject.Find("ObjectStorage");
        persistentStorage.GetComponent<PersistentStorage>().mp = true;
        persistentStorage.GetComponent<PersistentStorage>().gameId = (string)Result.ObjectId;
        persistentStorage.GetComponent<PersistentStorage>().parseUsername = (string)Result["p2username"];
        persistentStorage.GetComponent<PersistentStorage>().hostUsername = (string)Result["hostUsername"];
        //persistentStorage.GetComponent<PersistentStorage>().gameId 
        Object.DontDestroyOnLoad(persistentStorage);
        Application.LoadLevel("Mp_game_scene");

    }

    public void acceptInvite()
    {
        result["InviteAccepted"] = true;
        Task saveTask = result.SaveAsync();
    }

    //Creates a new game with the host and invited player.
    public void inviteToGame()
    {
        ParseObject game = new ParseObject("Game");

        game["InviteAccepted"] = false;
        game["P1Ready"] = false;
        game["P2Ready"] = false;
        game["TurnNumber"] = 0;
        game["hostUsername"] = (string)ParseUser.CurrentUser["username"];
        game["p2username"] = parseUsername;

        Task saveTask = game.SaveAsync();

    }
}