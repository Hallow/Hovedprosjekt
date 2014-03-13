using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public int id;
    int cash;
    int income;

    public List<GameObject> unitList;

    public GameObject recruitmentController;

    public GameObject startPos;

    public GameObject unitFactory;
    public GameObject factoryPrefab; //SET IN INSPECTOR



	// Use this for initialization
	void Start () {
        //Basic properties of the player, id is used to avoid friendly fire.
        cash = 150;
        income = 150;
        id = 0;

        //UnitList contains the units that are currently active on the board.
        unitList = new List<GameObject>();
        unitFactory = (GameObject)Instantiate(factoryPrefab);
	
	}
	
	// Update is called once per frame
	void Update () {

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
        foreach(int i in recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog)
        {
            switch(i)
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
