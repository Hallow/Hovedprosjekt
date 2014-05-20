using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour
{
    public int id;
    public int cash;
    public int income;
    public int health { get; set; }

    public List<GameObject> unitList;

    public GameObject recruitmentController;

    public GameObject startPos;

    public GameObject unitFactory;
    public GameObject factoryPrefab; //SET IN INSPECTOR

    public bool gameHasBeenReset;

    //Building checks
    public bool hasBarracks;
    public bool hasTownhall;
    public bool hasMasonry;
    public bool hasTavern;
    public bool hasNsa;

    //Combining AI into Player
    public bool isAi;
    public List<GameObject> towerList;
    public List<GameObject> buildingList;
    public GameObject towerFactoryPrefab;
    public GameObject towerFactory;
    public List<int> aiBacklog;

    //MP stuff
    public bool mp;
    public bool isHost;
    public string username;

    public void Initialize(string username, bool host, bool mp)
    {
        this.username = username;
        isHost = host;
        this.mp = mp;

        //Checks if the player is the host. The Host gets 1 as id, the invitee gets 0. Used to avoid friendly fire. *SHOULD BE REPLACED*
        if (isHost)
        {
            id = 0;
        }
        else
        {
            id = 1;
        }
    }

    // Use this for initialization
    void Start()
    {
        //startPos.transform.position = new Vector3(2.50896f, -7.349373f, -0.1f);
        //startPos.transform.position = new Vector3(2.50896f, -2.50896f, 0f);

        //Basic properties of the player, id is used to avoid friendly fire.
        cash = 1337;
        income = 0;
        health = 4;
        id = 0;

        //Checks if the Player is an AI, somewhat redundant, can be trimmed but requires changes to other classes.
        if (isAi)
        {
            Debug.Log("is ai!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            id = 1;
            towerFactory = (GameObject)Instantiate(towerFactoryPrefab);
            aiBacklog = new List<int>();
        }
        else
        {
            id = 0;
        }


        //UnitList contains the units that are currently active on the board.
        unitList = new List<GameObject>();
        unitFactory = (GameObject)Instantiate(factoryPrefab);

    }

    // Update is called once per frame
    void Update()
    {
        //Constantly check if a unit has been destroyed, and subsequently removes it from the list.
        foreach (GameObject u in unitList)
        {
            if (!u)
            {
                unitList.Remove(u);
            }
        }
    }


    //spawnUnits loops through the recruitmentBacklog (a list) in the RecruitmentController. It checks the numbers and spawns the
    //appropriate unit by adding it to the unitlist, and then waits 1 second. When all units are spawned, the coroutine stops.
    public IEnumerator spawnUnits()
    {
        foreach (int i in recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog)
        {
            switch (i)
            {
                case 0:
                    unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, id, startPos));
                    yield return new WaitForSeconds(1);
                    break;
                case 1:
                    unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(1, id, startPos));
                    yield return new WaitForSeconds(1);
                    break;
                case 2:
                    unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(2, id, startPos));
                    yield return new WaitForSeconds(1);
                    break;
                case 3:
                    unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(3, id, startPos));
                    yield return new WaitForSeconds(1);
                    break;
                case 4:
                    unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(4, id, startPos));
                    yield return new WaitForSeconds(1);
                    break;
            }
        }

        recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Clear();

        StopCoroutine("spawnUnits");
    }

    //The following coRoutines are AI behaviour, 1 per round of the game.
    public IEnumerator round1()
    {
        Vector3 slotCo = towerList[0].GetComponent<TowerScript>().transform.position;

        buildingList.Add(towerFactory.GetComponent<TowerFactory>().spawnTower(buildingList[0].transform.position, buildingList[0].GetComponent<BuildingScript>().structureType, buildingList[0].GetComponent<BuildingScript>().structureLevel + 1, buildingList[0], true, id));
        towerList.Add(towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, towerList[0].GetComponent<TowerScript>().towerType, towerList[0].GetComponent<TowerScript>().towerLevel + 1, towerList[0], false, id));
        towerList.Add(towerFactory.GetComponent<TowerFactory>().spawnTower(towerList[1].transform.position, towerList[1].GetComponent<TowerScript>().towerType, towerList[1].GetComponent<TowerScript>().towerLevel + 1, towerList[1], false, id));

        aiBacklog.Add(2);
        aiBacklog.Add(2);
        aiBacklog.Add(1);
        aiBacklog.Add(1);
        aiBacklog.Add(1);
        aiBacklog.Add(1);
        aiBacklog.Add(0);
        aiBacklog.Add(0);
        aiBacklog.Add(0);

        foreach (int i in aiBacklog)
        {
            unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(i, id, startPos));
            yield return new WaitForSeconds(1);
        }

        aiBacklog.Clear();

        StopCoroutine("round1");
    }

    public IEnumerator round2()
    {
        towerList.Add(towerFactory.GetComponent<TowerFactory>().spawnTower(towerList[3].transform.position, towerList[3].GetComponent<TowerScript>().towerType, towerList[3].GetComponent<TowerScript>().towerLevel + 1, towerList[3], false, id));
        towerList.Add(towerFactory.GetComponent<TowerFactory>().spawnTower(towerList[1].transform.position, towerList[1].GetComponent<TowerScript>().towerType, towerList[1].GetComponent<TowerScript>().towerLevel + 1, towerList[1], false, id));

        aiBacklog.Add(2);
        aiBacklog.Add(2);
        aiBacklog.Add(2);
        aiBacklog.Add(1);
        aiBacklog.Add(1);
        aiBacklog.Add(1);
        aiBacklog.Add(1);
        aiBacklog.Add(0);
        aiBacklog.Add(0);

        foreach (int i in aiBacklog)
        {
            unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(i, id, startPos));
            yield return new WaitForSeconds(1);
        }

        StopCoroutine("round2");
    }

    public IEnumerator round3()
    {
        towerList.Add(towerFactory.GetComponent<TowerFactory>().spawnTower(towerList[3].transform.position, towerList[3].GetComponent<TowerScript>().towerType, towerList[3].GetComponent<TowerScript>().towerLevel + 1, towerList[3], false, id));
        towerList.Add(towerFactory.GetComponent<TowerFactory>().spawnTower(towerList[1].transform.position, towerList[1].GetComponent<TowerScript>().towerType, towerList[1].GetComponent<TowerScript>().towerLevel + 1, towerList[1], false, id));

        aiBacklog.Add(2);
        aiBacklog.Add(2);
        aiBacklog.Add(2);
        aiBacklog.Add(1);
        aiBacklog.Add(1);
        aiBacklog.Add(1);
        aiBacklog.Add(1);
        aiBacklog.Add(0);
        aiBacklog.Add(0);

        foreach (int i in aiBacklog)
        {
            unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(i, id, startPos));
            yield return new WaitForSeconds(1);
        }

        StopCoroutine("round3");
    }

    public void Reset()
    {
        if (!gameHasBeenReset)
        {
            health = 4;
            gameHasBeenReset = true;
        }
    }

}
