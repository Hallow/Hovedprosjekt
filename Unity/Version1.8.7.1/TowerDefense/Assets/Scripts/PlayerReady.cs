using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PlayerReady : MonoBehaviour {

    //Ready is used to check whether the player has pressed the "End turn" button
    public bool ready;

    //MP stuff
    public bool mp;
    public string ownerUsername;
    public string gameId;

    public GameObject loop;

    public List<int> uploadList;

    public GameObject towerFactoryPrefab;
    public GameObject towerFactory;

	// Use this for initialization
	void Start () {

        uploadList = new List<int>();

        ready = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (mp)
        {
            if (ParseUser.CurrentUser["username"].ToString().Equals(ownerUsername))
            {

                if (loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().username.ToString().Equals(ownerUsername))
                {
                    uploadList = loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog;
                }
                else if (loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().username.ToString().Equals(ownerUsername))
                {
                    uploadList = loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog;
                }

                ready = true;

                ParseQuery<ParseObject> readyQuery = ParseObject.GetQuery("Game");
                readyQuery.GetAsync(gameId).ContinueWith(t =>
                {
                    ParseObject result = t.Result;
                    if (result["hostUsername"].ToString().Equals(ownerUsername))
                    {
                        result["P1Ready"] = true;
                        List<int> tempParseIdList = new List<int>();
                        foreach (GameObject tower in loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().towerList)
                        {
                            tempParseIdList.Add(tower.GetComponent<TowerScript>().parseId);
                            Debug.Log("Id: " + tower.GetComponent<TowerScript>().parseId);

                        }
                        //SAVE TOWERS, UNITS, AND UPGRADES HERE
                        result["Player1Towers"] = tempParseIdList.ToArray();
                        result["Player1Units"] = uploadList.ToArray();
                        Task saveTask = result.SaveAsync();
                    }
                    else if (result["p2username"].ToString().Equals(ownerUsername))
                    {
                        result["P2Ready"] = true;
                        List<int> tempParseIdList = new List<int>();
                        foreach (GameObject tower in loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().towerList)
                        {
                            tempParseIdList.Add(tower.GetComponent<TowerScript>().parseId);

                        }
                        //SAVE TOWERS, UNITS, AND UPGRADES HERE
                        result["Player2Towers"] = tempParseIdList.ToArray();
                        result["Player2Units"] = uploadList.ToArray();
                        Task saveTask = result.SaveAsync();
                        
                    }
                });
            }
            else
            {
                ParseQuery<ParseObject> readyQuery = ParseObject.GetQuery("Game");
                readyQuery.GetAsync(gameId).ContinueWith(t =>
                    {
                        ParseObject result = t.Result;
                        if(result["hostUsername"].ToString().Equals(ownerUsername))
                        {
                            if((bool)result["P1Ready"] == true)
                            {
                                //COLLECT TOWERS, UNITS AND UPGRADES FOR ENEMY HERE
                                IList<int> tempList = result.Get<IList<int>>("Player1Units");
                                foreach (int i in tempList)
                                {
                                    loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(i);
                                }

                                IList<int> tempTowerList = result.Get<IList<int>>("Player1Towers");

                                towerFactory = (GameObject)GameObject.Instantiate(towerFactoryPrefab);
                                List<GameObject> currentTowers = loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().towerList;

                                for (int i = 0; i < tempTowerList.Count; i++)
                                {
                                    Debug.Log(tempTowerList[i]);
                                    Vector3 slotCo = currentTowers[i].transform.position;
                                    slotCo.y += 0.15f;
                                    slotCo.z -= 0.2f;

                                    switch (tempTowerList[i])
                                    {
                                        case 0:
                                            Debug.Log("Player constructed nuthin 'ere"); 
                                            break;
                                        case 1:
                                            towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 1, currentTowers[i], false, 0);
                                            break;
                                        case 2:
                                            towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 2, currentTowers[i], false, 0);
                                            break;
                                        case 3:
                                            towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 3, currentTowers[i], false, 0);
                                            break;
                                        case 4:
                                            towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 4, currentTowers[i], false, 0);
                                            break;
                                        case 5:
                                            towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 5, currentTowers[i], false, 0);
                                            break;
                                            //ADD THE REST OF THE TOWERS HERE.
                                    }
                                }

                                ready = true;
                            }
                        }
                        else if (result["p2username"].ToString().Equals(ownerUsername))
                        {
                            if ((bool)result["P2Ready"] == true)
                            {
                                Debug.Log("Player2 is ready");
                                //COLLECT TOWERS, UNITS AND UPGRADES FOR ENEMY HERE
                                IList<int> tempList = result.Get<IList<int>>("Player2Units");
                                foreach (int i in tempList)
                                {
                                    loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(i);
                                }

                                IList<int> tempTowerList = result.Get<IList<int>>("Player2Towers");

                                towerFactory = (GameObject)GameObject.Instantiate(towerFactoryPrefab);
                                List<GameObject> currentTowers = loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().towerList;

                                for (int i = 0; i < tempTowerList.Count; i++)
                                {
                                    Debug.Log(tempTowerList[i]);
                                    Vector3 slotCo = currentTowers[i].transform.position;
                                    slotCo.y += 0.15f;
                                    slotCo.z -= 0.2f;

                                    switch (tempTowerList[i])
                                    {
                                        case 0:
                                            Debug.Log("Player constructed nuthin 'ere");      
                                            break;
                                        case 1:
                                            towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 1, currentTowers[i], false, 1);
                                            break;
                                        case 2:
                                            towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 2, currentTowers[i], false, 1);
                                            break;
                                        case 3:
                                            towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 3, currentTowers[i], false, 1);
                                            break;
                                        case 4:
                                            towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 4, currentTowers[i], false, 1);
                                            break;
                                        case 5:
                                            towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 5, currentTowers[i], false, 1);
                                            break;
                                            //ADD THE REST OF THE TOWERS HERE.
                                    }
                                    
                                }
                                
                                ready = true;
                            }
                        }
                    });

            }
        }
        else
        {
            ready = true;
        }
        //The player has clicked "End Turn", so he is ready.
        
    }

    void uploadRoundData(List<GameObject> unitList, List<GameObject> towerList, string gameId) //TODO: Missing list of "upgrades"
    {
        ParseObject Game = new ParseObject("Game");
        Game["objectId"] = gameId;

    }

}
