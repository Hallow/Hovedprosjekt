using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using System.Threading.Tasks;

public class ReadyScript : MonoBehaviour {

    public string p1username;
    public string p2username;

    public bool p1ready;
    public bool p2ready;

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
            ParseQuery<ParseObject> readyQuery = ParseObject.GetQuery("Game");
            readyQuery.GetAsync(gameId).ContinueWith(t =>
            {
                ParseObject result = t.Result;

                if (ParseUser.CurrentUser["username"].ToString().Equals(p1username) && (bool)result["P1Ready"] != true)
                {
                    uploadList = loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog;
                    p1ready = true;

                    result["P1Ready"] = true;
                    List<int> tempParseIdList = new List<int>();
                    List<int> tempBParseIdList = new List<int>();
                    foreach (GameObject tower in loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().towerList)
                    {
                        tempParseIdList.Add(tower.GetComponent<TowerScript>().parseId);

                    }

                    foreach (GameObject b in loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().buildingList)
                    {
                        tempBParseIdList.Add(b.GetComponent<BuildingScript>().parseId); 
                    }
                    //SAVE TOWERS, UNITS, AND UPGRADES HERE
                    result["Player1Towers"] = tempParseIdList.ToArray();
                    result["Player1Units"] = uploadList.ToArray();
                    result["Player1Buildings"] = tempBParseIdList.ToArray();
                    Task saveTask = result.SaveAsync();

                    if ((bool)result["P2Ready"] == true)
                    {
                        //COLLECT TOWERS, UNITS AND UPGRADES FOR ENEMY HERE
                        IList<int> tempList = result.Get<IList<int>>("Player2Units");
                        foreach (int i in tempList)
                        {
                            loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(i);
                        }

                        IList<int> tempTowerList = result.Get<IList<int>>("Player2Towers");
                        IList<int> tempBuildingList = result.Get<IList<int>>("Player2Buildings");

                        towerFactory = (GameObject)GameObject.Instantiate(towerFactoryPrefab);
                        List<GameObject> currentTowers = loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().towerList;
                        List<GameObject> currentBuildings = loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().buildingList;

                        for (int i = 0; i < tempBuildingList.Count; i++)
                        {
                            Vector3 slotCo = currentBuildings[i].transform.position;
                            slotCo.y += 0.15f;
                            slotCo.z -= 0.2f;

                            switch(tempBuildingList[i])
                            {
                                case 0:
                                    //EMPTY SLOT
                                    break;
                                case 1:
                                    //TOWN HALL
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 3, 1, currentBuildings[i], true, 1);
                                    break;
                                case 2:
                                    //BARRACKS
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 3, 2, currentBuildings[i], true, 1);
                                    break;
                                case 3:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 3, 3, currentBuildings[i], true, 1);
                                    //BLACKSMITH
                                    break;
                                case 4:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 3, 4, currentBuildings[i], true, 1);
                                    //MARKET
                                    break;
                                case 5:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 3, 5, currentBuildings[i], true, 1);
                                    //TAVERN
                                    break;

                            }
                        }

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
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 3, currentTowers[i], true, 1);
                                    break;
                                case 4:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 4, currentTowers[i], true, 1);
                                    break;
                                case 5:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 5, currentTowers[i], true, 1);
                                    break;
                                case 6:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 1, 1, currentTowers[i], false, 1);
                                    break;
                                case 7:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 1, 2, currentTowers[i], false, 1);
                                    break;
                                case 8:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 1, 3, currentTowers[i], true, 1);
                                    break;
                                case 9:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 1, 4, currentTowers[i], true, 1);
                                    break;
                                case 10:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 1, 5, currentTowers[i], true, 1);
                                    break;
                                case 11:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 2, 1, currentTowers[i], false, 1);
                                    break;
                                case 12:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 2, 2, currentTowers[i], false, 1);
                                    break;
                                case 13:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 2, 3, currentTowers[i], true, 1);
                                    break;
                                case 14:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 2, 4, currentTowers[i], true, 1);
                                    break;
                                case 15:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 2, 5, currentTowers[i], true, 1);
                                    break;
                                  
                                //MAKE NECESARY CHANGES IN BUILDING SCRIPT AND TOWERFACTORY FOR MP BUILDINGS
                            }

                        }

                        p2ready = true;
                    }



                }
                else if (ParseUser.CurrentUser["username"].ToString().Equals(p2username) && (bool)result["P2Ready"] != true)
                {
                    uploadList = loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog;
                    p2ready = true;

                    result["P2Ready"] = true;
                    List<int> tempParseIdList = new List<int>();
                    List<int> tempBParseIdList = new List<int>();
                    foreach (GameObject tower in loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().towerList)
                    {
                        tempParseIdList.Add(tower.GetComponent<TowerScript>().parseId);

                    }
                    foreach (GameObject b in loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().buildingList)
                    {
                        tempBParseIdList.Add(b.GetComponent<BuildingScript>().parseId);
                    }
                    //SAVE TOWERS, UNITS, AND UPGRADES HERE
                    result["Player2Towers"] = tempParseIdList.ToArray();
                    result["Player2Units"] = uploadList.ToArray();
                    result["Player2Buildings"] = tempBParseIdList.ToArray();
                    Task saveTask = result.SaveAsync();

                    if ((bool)result["P1Ready"] == true)
                    {
                        //COLLECT TOWERS, UNITS AND UPGRADES FOR ENEMY HERE
                        IList<int> tempList = result.Get<IList<int>>("Player1Units");
                        foreach (int i in tempList)
                        {
                            loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(i);
                        }

                        towerFactory = (GameObject)GameObject.Instantiate(towerFactoryPrefab);

                        IList<int> tempTowerList = result.Get<IList<int>>("Player1Towers");
                        IList<int> tempBuildingList = result.Get<IList<int>>("Player1Buildings");

                        List<GameObject> currentBuildings = loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().buildingList;

                        for (int i = 0; i < tempBuildingList.Count; i++)
                        {
                            Vector3 slotCo = currentBuildings[i].transform.position;
                            slotCo.y += 0.15f;
                            slotCo.z -= 0.2f;

                            switch (tempBuildingList[i])
                            {
                                case 0:
                                    //EMPTY SLOT
                                    break;
                                case 1:
                                    //TOWN HALL
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 3, 1, currentBuildings[i], true, 0);
                                    break;
                                case 2:
                                    //BARRACKS
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 3, 2, currentBuildings[i], true, 0);
                                    break;
                                case 3:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 3, 3, currentBuildings[i], true, 0);
                                    //BLACKSMITH
                                    break;
                                case 4:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 3, 4, currentBuildings[i], true, 0);
                                    //MARKET
                                    break;
                                case 5:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 3, 5, currentBuildings[i], true, 0);
                                    //TAVERN
                                    break;

                            }
                        }

                        
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
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 3, currentTowers[i], true, 0);
                                    break;
                                case 4:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 4, currentTowers[i], true, 0);
                                    break;
                                case 5:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 0, 5, currentTowers[i], true, 0);
                                    break;
                                case 6:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 1, 1, currentTowers[i], false, 0);
                                    break;
                                case 7:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 1, 2, currentTowers[i], false, 0);
                                    break;
                                case 8:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 1, 3, currentTowers[i], true, 0);
                                    break;
                                case 9:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 1, 4, currentTowers[i], true, 0);
                                    break;
                                case 10:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 1, 5, currentTowers[i], true, 0);
                                    break;
                                case 11:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 2, 1, currentTowers[i], false, 0);
                                    break;
                                case 12:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 2, 2, currentTowers[i], false, 0);
                                    break;
                                case 13:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 2, 3, currentTowers[i], true, 0);
                                    break;
                                case 14:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 2, 4, currentTowers[i], true, 0);
                                    break;
                                case 15:
                                    towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, 2, 5, currentTowers[i], true, 0);
                                    break;

                                //MAKE NECESARY CHANGES IN BUILDING SCRIPT AND TOWERFACTORY FOR MP BUILDINGS
                            }
                        }

                        p1ready = true;
                    }
                }

            });           
        }
        else
        {
            ready = true;

            loop.GetComponent<GameLoop>().turnNumber++;
        }
    }
}
