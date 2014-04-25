using UnityEngine;
using System.Collections;

public class GameLoop : MonoBehaviour
{

    public GameObject player1;
    //GameObject player2;
    public GameObject player1Ready;
    //GameObject player2Ready;

    public bool roundActive;

    public GameObject aiPlayer;

    public int turnNumber;

    // Use this for initialization
    void Start()
    {
        roundActive = false;
        turnNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < aiPlayer.GetComponent<PlayerScript>().unitList.Count; i++)
        {
            if (aiPlayer.GetComponent<PlayerScript>().unitList[i].transform.position.y < -7.548335)
            {
                player1.GetComponent<PlayerScript>().health--;
                GameObject.Destroy(aiPlayer.GetComponent<PlayerScript>().unitList[i]);
            }
        }

        for (int i = 0; i < player1.GetComponent<PlayerScript>().unitList.Count; i++)
        {
            if (player1.GetComponent<PlayerScript>().unitList[i].transform.position.y > 11f)
            {
                aiPlayer.GetComponent<PlayerScript>().health--;
                GameObject.Destroy(player1.GetComponent<PlayerScript>().unitList[i]);
            }
        }

        if (player1.GetComponent<PlayerScript>().health <= 0)
        {

        }
        if (player1Ready.GetComponent<PlayerReady>().ready && !roundActive)
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
            player1Ready.GetComponent<PlayerReady>().ready = false;
            //player2Ready.GetComponent<Player2Ready>().ready = false;
            roundActive = false;
            Debug.Log("Round set to inactive");
            turnNumber++;
            incrementCash(player1);

            //Spawns the 5 basic units granted automatically by the Town Hall
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
