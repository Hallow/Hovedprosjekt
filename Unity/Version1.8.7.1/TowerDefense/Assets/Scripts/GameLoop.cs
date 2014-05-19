using UnityEngine;
using System.Collections;
using Parse;

public class GameLoop : MonoBehaviour
{

    //Bool check for MP or SP
    public bool mp;

    public GameObject player1;
    public GameObject player2;
    public GameObject player1Ready;
    public GameObject player2Ready;

    public bool roundActive;

    public GameObject aiPlayer;

    int turnNumber;

    //MP Variables
    GameObject persistentStorage;
    string gameId;
    public GameObject refreshButton;
    
    //TESTING
    public GameObject readyController;

    // Use this for initialization
    void Start()
    {
        persistentStorage = GameObject.Find("ObjectStorage");
        mp = persistentStorage.GetComponent<PersistentStorage>().mp;


        if (mp)
        {
            roundActive = false;
            turnNumber = 0;

            
            player1.GetComponent<PlayerScript>().Initialize(persistentStorage.GetComponent<PersistentStorage>().hostUsername, true, true);
            player2.GetComponent<PlayerScript>().Initialize(persistentStorage.GetComponent<PersistentStorage>().parseUsername, false, true);

            gameId = persistentStorage.GetComponent<PersistentStorage>().gameId;
            Debug.Log("Game ID from Loop: " + gameId);

            //TODO: REPLACE THESE
            //player1Ready.GetComponent<PlayerReady>().ownerUsername = player1.GetComponent<PlayerScript>().username;
            //player2Ready.GetComponent<PlayerReady>().ownerUsername = player2.GetComponent<PlayerScript>().username;
            //player1Ready.GetComponent<PlayerReady>().mp = true;
            //player2Ready.GetComponent<PlayerReady>().mp = true;
            //player1Ready.GetComponent<PlayerReady>().gameId = gameId;
            //player2Ready.GetComponent<PlayerReady>().gameId = gameId;
            //player1Ready.GetComponent<PlayerReady>().loop = gameObject;
            //player2Ready.GetComponent<PlayerReady>().loop = gameObject;
            //END TODO

            //TODO: WITH THESE
            readyController.GetComponent<ReadyScript>().p1username = player1.GetComponent<PlayerScript>().username;
            readyController.GetComponent<ReadyScript>().p2username = player2.GetComponent<PlayerScript>().username;
            readyController.GetComponent<ReadyScript>().mp = true;
            readyController.GetComponent<ReadyScript>().gameId = gameId;
            readyController.GetComponent<ReadyScript>().loop = gameObject;
            //END TODO

            refreshButton.GetComponent<RefreshGameScript>().loop = gameObject;
            refreshButton.GetComponent<RefreshGameScript>().gameId = gameId;
            refreshButton.GetComponent<RefreshGameScript>().readyButton = readyController;

            
            
            

            //TESTING
            //Debug.Log("Player2ReadyUsername: " + player2Ready.GetComponent<PlayerReady>().ownerUsername);
            //Debug.Log("Logged in user username: " + ParseUser.CurrentUser["username"]);
            //Debug.Log("Player1ReadyUsername: " + player1Ready.GetComponent<PlayerReady>().ownerUsername);
        }
        else
        {
            roundActive = false;
            turnNumber = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //If the game is multiplayer
        if (mp)
        {
            //IF CLAUSE TO ACTIVATE ROUND
            if (readyController.GetComponent<ReadyScript>().p1ready && readyController.GetComponent<ReadyScript>().p2ready && !roundActive)
            {
                //TODO:
                //ADD TO IF: && player2Ready.GetComponent<Player2Ready>().ready
                //SORTA DONE, NEEDS TESTING

                roundActive = true;
                player1.GetComponent<PlayerScript>().StartCoroutine("spawnUnits");
                player2.GetComponent<PlayerScript>().StartCoroutine("spawnUnits");

                //player2.GetComponent<PlayerScript>().StartCoroutine("spawnUnits");


            }

            //IF CLAUSE TO DEACTIVATE ROUND
            if (player1.GetComponent<PlayerScript>().unitList.Count <= 0 && player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().backlogIsEmpty && player2.GetComponent<PlayerScript>().unitList.Count <= 0 && player2.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().backlogIsEmpty && roundActive)
            {
                //TODO:
                //ADD TO IF: && player2.GetComponent<PlayerScript>().unitList.Count >= 0
                readyController.GetComponent<ReadyScript>().p1ready = false;
                readyController.GetComponent<ReadyScript>().p2ready = false;
                //player2Ready.GetComponent<Player2Ready>().ready = false;
                roundActive = false;
                Debug.Log("Round set to inactive");
                turnNumber++;
                incrementCash(player1);
                incrementCash(player2);

                //Spawns the 5 basic units granted automatically by the Town Hall
                if (player1.GetComponent<PlayerScript>().hasTownhall)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(0);
                    }
                }

                if (player2.GetComponent<PlayerScript>().hasTownhall)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        player2.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(0);
                    }
                }
                //TODO:
                //Economy for Player2 and/or AI
                //SORTA DONE, NEEDS TESTING
            }
        }
        //If the game is single player
        else
        {
            if (readyController.GetComponent<ReadyScript>().ready && !roundActive)
            {
                //TODO:
                //ADD TO IF: && player2Ready.GetComponent<Player2Ready>().ready
                player1.GetComponent<PlayerScript>().StartCoroutine("spawnUnits");

                //Switches on the turn number and starts the appropriate AI behaviour, as defined in the AI Script
                switch (turnNumber)
                {
                    case 0:
                        aiPlayer.GetComponent<PlayerScript>().StartCoroutine("round1");
                        break;
                    case 1:
                        aiPlayer.GetComponent<PlayerScript>().StartCoroutine("round2");
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }

                //player2.GetComponent<PlayerScript>().StartCoroutine("spawnUnits");
                roundActive = true;

            }

            if (player1.GetComponent<PlayerScript>().unitList.Count <= 0 && player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().backlogIsEmpty && roundActive)
            {
                //TODO:
                //ADD TO IF: && player2.GetComponent<PlayerScript>().unitList.Count >= 0
                readyController.GetComponent<ReadyScript>().ready = false;
                //player2Ready.GetComponent<Player2Ready>().ready = false;
                roundActive = false;
                Debug.Log("Round set to inactive");
                turnNumber++;
                incrementCash(player1);

                //Spawns the 5 basic units granted automatically by the TOwn Hall
                if (player1.GetComponent<PlayerScript>().hasTownhall)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(0);
                    }
                }
                //TODO:
                //Economy for Player2 and/or AI
            }
        }


    }

    //Method used for incrementing the cash of a player (passed in the method call), the cash is incremented using
    //the players own "income" attribute.
    public void incrementCash(GameObject player)
    {
        player.GetComponent<PlayerScript>().cash += player.GetComponent<PlayerScript>().income;
    }

    //Method used for DEincrementing a players cash, usually when a tower or building is constructed, this will be called.
    //Returns true and deincrements if the player has enough cash. Does nothing and returns false if the player has too
    //little cash. It also checks whether the player object has a PlayerScript or AiScript attached.
    public bool deIncrementCash(GameObject player, int deincrement)
    {

        if (player.GetComponent<PlayerScript>().cash >= deincrement)
        {
            player.GetComponent<PlayerScript>().cash -= deincrement;
            return true;
        }
        else
        {
            //TODO: Give the player some sort of warning that he/she has insufficient cash for the operation
            return false;
        }

        //Debug.Log("Something went wrong with deincrementing cash.");
        //return false;


    }

    //Method used for incrementing the income of a player (passed in the method call). The income is then used in the
    //above method to increment the cash.
    public void incrementIncome(GameObject player, int incomeIncrease)
    {
        player.GetComponent<PlayerScript>().income += incomeIncrease;
    }
}
