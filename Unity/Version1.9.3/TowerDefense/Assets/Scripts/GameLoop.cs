using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;

public class GameLoop : MonoBehaviour
{

    public bool mp;

    public GameObject player1;
    public GameObject player2;
    public GameObject player1Ready;
    public GameObject player2Ready;

    public bool roundActive;

    public bool win;

    public GameObject aiPlayer;

    public int turnNumber;
    public bool gameOver;

    //MP Variables
    GameObject persistentStorage;
    string gameId;
    public GameObject refreshButton;
    //END


    //TESTING
    public GameObject readyController;

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

        persistentStorage = GameObject.Find("ObjectStorage");

        if (persistentStorage != null)
        {
            mp = persistentStorage.GetComponent<PersistentStorage>().mp;
        }


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
            Debug.Log("NOT MP");
            readyController.GetComponent<ReadyScript>().loop = gameObject;
            roundActive = false;
            turnNumber = 0;
        }

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
            if (player1.GetComponent<PlayerScript>().unitList.Count <= 0 && player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().backlogIsEmpty && player2.GetComponent<PlayerScript>().unitList.Count <= 0 && player2.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().backlogIsEmpty && roundActive || player1.GetComponent<PlayerScript>().health <= 0 || player2.GetComponent<PlayerScript>().health <= 0)
            {

                //TODO:
                //ADD TO IF: && player2.GetComponent<PlayerScript>().unitList.Count >= 0
                readyController.GetComponent<ReadyScript>().p1ready = false;
                readyController.GetComponent<ReadyScript>().p2ready = false;
                //player2Ready.GetComponent<Player2Ready>().ready = false;
                roundActive = false;

                ParseQuery<ParseObject> currentQuery = ParseObject.GetQuery("Game");
                currentQuery.GetAsync(gameId).ContinueWith(t =>
                    {
                        ParseObject result = t.Result;
                        result["P1Ready"] = false;
                        result["P2Ready"] = false;
                        result["TurnNumber"] = turnNumber;
                        result["Player1Units"] = null;
                        result["Player2Units"] = null;

                        Task savetask = result.SaveAsync();
                    });


                if (!winloseCalled)
                {
                    if (player1.GetComponent<PlayerScript>().health <= 0)
                    {
                        WinLose(1);
                        winloseCalled = true;
                    }

                    if (player2.GetComponent<PlayerScript>().health <= 0)
                    {
                        WinLose(0);
                        winloseCalled = true;
                    }
                    
                }

                if (decided)
                {
                    Reset();

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
                }

                //TODO:
                //Economy for Player2 and/or AI
                //SORTA DONE, NEEDS TESTING
            }
        }
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

                //TODO:
                //ADD TO IF: && player2.GetComponent<PlayerScript>().unitList.Count >= 0
                readyController.GetComponent<ReadyScript>().ready = false;
                //player2Ready.GetComponent<Player2Ready>().ready = false;
                roundActive = false;

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
        Debug.Log("ID= " + id);

        winloseCalled = true;
        Time.timeScale = 0;
        tempWinloseNotification = (GameObject)Instantiate(winloseNotification);
        tempQuitButton = (GameObject)Instantiate(quitButton);

        Debug.Log("logging some stuff 1");

        if (!mp)
        {
            Debug.Log("lololololol666");
            tempContinueButton = (GameObject)Instantiate(continueButton);
        }
        else
        {
            Debug.Log("logging some stuff 2");
            tempQuitButton.transform.position = new Vector3(0.261778f, quitButton.transform.position.y, quitButton.transform.position.z);

        }

        Debug.Log("logging some stuff 3");

        if (id == 0)
        {
            Debug.Log("printin win message");
            tempWinloseWinMessage = (GameObject)Instantiate(winloseWinMessage);
        }
        else if (id == 1)
        {
            Debug.Log("printin lose message");
            tempWinloseLoseMessage = (GameObject)Instantiate(winloseLoseMessage);
        }
    }

    public void DestroyAllUnits()
    {
        if (mp)
        {
            Debug.Log("Destroying mp units!");
            foreach (GameObject o in player1.GetComponent<PlayerScript>().unitList)
            {
                GameObject.Destroy(o);
            }

            foreach (GameObject o in player2.GetComponent<PlayerScript>().unitList)
            {
                GameObject.Destroy(o);
            }

            player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Clear();
            player2.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Clear();
        }
        else
        {
            Debug.Log("Destroying sp units!");
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
        if (mp)
        {
            player1.GetComponent<PlayerScript>().health = 4;
            player2.GetComponent<PlayerScript>().health = 4;
        }
        else
        {
            player1.GetComponent<PlayerScript>().health = 4;
            aiPlayer.GetComponent<PlayerScript>().health = 4;
        }
        decided = false;
    }

    private void PresentWin()
    {

    }

    private void PresentLose()
    {

    }
}