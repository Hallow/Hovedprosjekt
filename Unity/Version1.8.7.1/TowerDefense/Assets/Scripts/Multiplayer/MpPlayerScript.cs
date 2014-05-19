using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MpPlayerScript : MonoBehaviour
{

    public int id;
    public int cash;
    public int income;

    public List<GameObject> unitList;

    public GameObject recruitmentController;

    public GameObject startPos;

    public GameObject unitFactory;
    public GameObject factoryPrefab; //SET IN INSPECTOR

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

    //MP Specific fields
    public bool isHost;
    public string username;

    public void Initialize(string username, bool host)
    {
        this.username = username;
        isHost = host;

        //Checks if the player is the host. The Host gets 1 as id, the invitee gets 0. Used to avoid friendly fire. *SHOULD BE REPLACED*
        if (isHost)
        {
            id = 1;
        }
        else
        {
            id = 0;
        }
    }

    // Use this for initialization
    void Start()
    {
        //Basic properties of the player, id is used to avoid friendly fire.
        cash = 1337;
        income = 0;

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

}
