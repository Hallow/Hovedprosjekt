using UnityEngine;
using System.Collections;

public class GameLoop : MonoBehaviour
{

    public GameObject player1;
    //GameObject player2;
    public GameObject player1Ready;
    //GameObject player2Ready;

    public bool roundActive;

    public bool win;

    public GameObject aiPlayer;

    public int turnNumber;
    public bool gameOver;

    public bool decided;
    public bool winloseCalled;

    public int playerPath;

    public GameObject winloseNotification;
    public GameObject winloseLoseMessage;
    public GameObject winloseWinMessage;
    public GameObject continueButton;
    public GameObject quitButton;

    public GameObject tempWinloseNotification;
    public GameObject tempWinloseLoseMessage;
    public GameObject tempWinloseWinMessage;
    public GameObject tempContinueButton;
    public GameObject tempQuitButton;


    // Use this for initialization
    void Start()
    {
        roundActive = false;
        turnNumber = 0;
        gameOver = false;
        decided = false;
        winloseCalled = false;

        //winloseNotification = (GameObject)Resources.Load("Notifications/winlose_notification_bg");
        //winloseLoseMessage = (GameObject)Resources.Load("Notifications/winlose_lose_message");
        //winloseWinMessage = (GameObject)Resources.Load("Notifications/winlose_win_message");
        //continueButton = (GameObject)Resources.Load("Notifications/winlose_continue");
        //quitButton = (GameObject)Resources.Load("Notifications/winlose_quit");

        //tempWinloseNotification = winloseNotification;
        //tempWinloseLoseMessage = winloseLoseMessage;
        //tempWinloseWinMessage = winloseWinMessage;
        //tempContinueButton = continueButton;
        //tempQuitButton = quitButton;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(roundActive);

        // Calls for "game over" if the player's health is 0.
        /*if (player1.GetComponent<PlayerScript>().health <= 0)
        {
            if (!gameOver)
            {
                GameOver();
            }
        }^*/

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
                    aiPlayer.GetComponent<PlayerScript>().StartCoroutine("round2");
                    break;
                case 3:
                    aiPlayer.GetComponent<PlayerScript>().StartCoroutine("round2");
                    break;
            }

            //player2.GetComponent<PlayerScript>().StartCoroutine("spawnUnits");
            roundActive = true;
        }

        if (player1.GetComponent<PlayerScript>().unitList.Count <= 0 && player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().backlogIsEmpty && aiPlayer.GetComponent<PlayerScript>().unitList.Count <= 0 && aiPlayer.GetComponent<PlayerScript>().aiBacklog.Count <= 0 && roundActive || player1.GetComponent<PlayerScript>().health <= 0 || aiPlayer.GetComponent<PlayerScript>().health <= 0)
        {
            if (!winloseCalled)
            {
                if (player1.GetComponent<PlayerScript>().health <= 0)
                {
                    WinLose(1);
                }

                if (aiPlayer.GetComponent<PlayerScript>().health <= 0)
                {
                    WinLose(0);
                }
                winloseCalled = true;
            }

            if (decided)
            {
                Reset();

                //TODO:
                //ADD TO IF: && player2.GetComponent<PlayerScript>().unitList.Count >= 0
                player1Ready.GetComponent<PlayerReady>().ready = false;
                //player2Ready.GetComponent<Player2Ready>().ready = false;
                roundActive = false;
                Debug.Log("Round set to inactive");
                //turnNumber++;
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
    }

    //Method used for incrementing the cash of a player (passed in the method call), the cash is incremented using
    //the players own "income" attribute.
    public void incrementCash(GameObject player)
    {
        player.GetComponent<PlayerScript>().cash += player.GetComponent<PlayerScript>().income;
    }

    //Method used for decrementing a players cash, usually when a tower or building is constructed, this will be called.
    //Returns true and deincrements if the player has enough cash. Does nothing and returns false if the player has too
    //little cash. It also checks whether the player object has a PlayerScript or AiScript attached.
    public bool decrementCash(GameObject player, int decrement)
    {
        if (player.GetComponent<PlayerScript>().cash >= decrement)
        {
            player.GetComponent<PlayerScript>().cash -= decrement;
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

    public void GameOver()
    {
        Debug.Log("game over!!");

        player1Ready.GetComponent<PlayerReady>().ready = false;

        roundActive = false;

        Debug.Log(player1.GetComponent<PlayerScript>().unitList.Count);
        

        player1.GetComponent<PlayerScript>().health = 4;
        aiPlayer.GetComponent<PlayerScript>().health = 4;

        switch (turnNumber)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }

        foreach (GameObject o in aiPlayer.GetComponent<PlayerScript>().unitList)
        {
            GameObject.Destroy(o);
        }

        foreach (GameObject o in player1.GetComponent<PlayerScript>().unitList)
        {
            GameObject.Destroy(o);
        }
        gameOver = false;
    }

    private void WinLose(int id)
    {
        winloseCalled = true;
        Time.timeScale = 0;
        tempWinloseNotification = (GameObject)Instantiate(winloseNotification);
        tempContinueButton = (GameObject)Instantiate(continueButton);
        tempQuitButton = (GameObject)Instantiate(quitButton);


        //tempWinloseWinMessage = (GameObject)Instantiate(winloseWinMessage);

        if (id == 0)
        {
            tempWinloseWinMessage = (GameObject)Instantiate(winloseWinMessage);
        }
        else if (id == 1)
        {
            tempWinloseLoseMessage = (GameObject)Instantiate(winloseLoseMessage);
        }
        //winloseCalled = true;
    }

    public void DestroyAllUnits()
    {
        foreach (GameObject o in aiPlayer.GetComponent<PlayerScript>().unitList)
        {
            GameObject.Destroy(o);
        }

        foreach (GameObject o in player1.GetComponent<PlayerScript>().unitList)
        {
            GameObject.Destroy(o);
        }

        player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Clear();
        aiPlayer.GetComponent<PlayerScript>().aiBacklog.Clear();
    }

    public void Close()
    {
        Destroy(tempWinloseWinMessage);
        GameObject.Destroy(tempWinloseLoseMessage);
        Destroy(tempWinloseNotification);
        Destroy(tempContinueButton);
        Destroy(tempQuitButton);
    }

    public void Reset()
    {
        player1.GetComponent<PlayerScript>().health = 4;
        aiPlayer.GetComponent<PlayerScript>().health = 4;
        decided = false;
    }

    private void PresentWin()
    {

    }

    private void PresentLose()
    {

    }
}
