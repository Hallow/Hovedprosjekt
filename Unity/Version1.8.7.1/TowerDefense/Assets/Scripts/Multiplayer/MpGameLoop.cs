using UnityEngine;
using System.Collections;
using Parse;

public class MpGameLoop : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    public GameObject player1Ready;
    public GameObject player2Ready;

    public bool roundActive;

    int turnNumber;

    GameObject persistentStorage;
    string gameId;

    // Use this for initialization
    void Start()
    {
        roundActive = false;
        turnNumber = 0;

        persistentStorage = GameObject.Find("ObjectStorage");
        player1.GetComponent<MpPlayerScript>().Initialize(persistentStorage.GetComponent<PersistentStorage>().hostUsername, true);
        player2.GetComponent<MpPlayerScript>().Initialize(persistentStorage.GetComponent<PersistentStorage>().parseUsername, false);
        player1Ready.GetComponent<MpPlayerReady>().ownerUsername = player1.GetComponent<MpPlayerScript>().username;
        player2Ready.GetComponent<MpPlayerReady>().ownerUsername = player2.GetComponent<MpPlayerScript>().username;
        //SAVE PARSE USERNAMES IN PLAYER OBJECTS
        gameId = persistentStorage.GetComponent<PersistentStorage>().gameId;
    }

    // Update is called once per frame
    void Update()
    {

        //IF CLAUSE TO ACTIVATE ROUND
        if (player1Ready.GetComponent<PlayerReady>().ready && player2Ready.GetComponent<PlayerReady>().ready && !roundActive)
        {
            //TODO:
            //ADD TO IF: && player2Ready.GetComponent<Player2Ready>().ready
            //SORTA DONE, NEEDS TESTING

            roundActive = true;
            player1.GetComponent<MpPlayerScript>().StartCoroutine("spawnUnits");
            player2.GetComponent<MpPlayerScript>().StartCoroutine("spawnUnits");

            //player2.GetComponent<PlayerScript>().StartCoroutine("spawnUnits");
            

        }

        //IF CLAUSE TO DEACTIVATE ROUND
        if (player1.GetComponent<MpPlayerScript>().unitList.Count <= 0 && player1.GetComponent<MpPlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().backlogIsEmpty && player2.GetComponent<MpPlayerScript>().unitList.Count <= 0 && player2.GetComponent<MpPlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().backlogIsEmpty && roundActive)
        {
            //TODO:
            //ADD TO IF: && player2.GetComponent<PlayerScript>().unitList.Count >= 0
            player1Ready.GetComponent<PlayerReady>().ready = false;
            player2Ready.GetComponent<PlayerReady>().ready = false;
            //player2Ready.GetComponent<Player2Ready>().ready = false;
            roundActive = false;
            Debug.Log("Round set to inactive");
            turnNumber++;
            incrementCash(player1);
            incrementCash(player2);

            //Spawns the 5 basic units granted automatically by the Town Hall
            if (player1.GetComponent<MpPlayerScript>().hasTownhall)
            {
                for (int i = 0; i < 5; i++)
                {
                    player1.GetComponent<MpPlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(0);
                }
            }

            if (player2.GetComponent<MpPlayerScript>().hasTownhall)
            {
                for (int i = 0; i < 5; i++)
                {
                    player2.GetComponent<MpPlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(0); 
                }
            }
            //TODO:
            //Economy for Player2 and/or AI
            //SORTA DONE, NEEDS TESTING
        }

    }

    //Method used for incrementing the cash of a player (passed in the method call), the cash is incremented using
    //the players own "income" attribute.
    public void incrementCash(GameObject player)
    {
        player.GetComponent<MpPlayerScript>().cash += player.GetComponent<MpPlayerScript>().income;
    }

    //Method used for DEincrementing a players cash, usually when a tower or building is constructed, this will be called.
    //Returns true and deincrements if the player has enough cash. Does nothing and returns false if the player has too
    //little cash. It also checks whether the player object has a PlayerScript or AiScript attached.
    public bool deIncrementCash(GameObject player, int deincrement)
    {

        if (player.GetComponent<MpPlayerScript>().cash >= deincrement)
        {
            player.GetComponent<MpPlayerScript>().cash -= deincrement;
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
        player.GetComponent<MpPlayerScript>().income += incomeIncrease;
    }
}