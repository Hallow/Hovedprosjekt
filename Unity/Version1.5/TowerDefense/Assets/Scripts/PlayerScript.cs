using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public int id;
    int cash;
    int income;

    public List<GameObject> unitList;

    public GameObject basicButton;
    public GameObject scoutButton;
    public GameObject heavyButton;
    public GameObject jumperButton;
    public GameObject spyButton;

    public GameObject startPos;

    public GameObject unitFactory;
    public GameObject factoryPrefab; //SET IN INSPECTOR



	// Use this for initialization
	void Start () {
        cash = 150;
        income = 150;
        id = 0;

        unitList = new List<GameObject>();
        unitFactory = (GameObject)Instantiate(factoryPrefab);
	
	}
	
	// Update is called once per frame
	void Update () {

        foreach (GameObject u in unitList)
        {
            if (!u)
            {
                unitList.Remove(u);
            }
        }
	
	}


    public IEnumerator spawnUnits()
    {
        for (int i = 0; i < basicButton.GetComponent<RecruitBasicScript>().index; i++)
        {
            unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, id, startPos));
            //Spawn intended unit here, add it to the UnitList
            yield return new WaitForSeconds(1);            
        }

        for (int i = 0; i < heavyButton.GetComponent<RecruitHeavyScript>().index; i++)
        {
            unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(2, id, startPos));
            //Spawn intended unit here, add it to the UnitList
            yield return new WaitForSeconds(1);
        }

        for (int i = 0; i < scoutButton.GetComponent<RecruitScoutScript>().index; i++)
        {
            unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(1, id, startPos));
            //Spawn intended unit here, add it to the UnitList
            yield return new WaitForSeconds(1);
        }

        

        for (int i = 0; i < jumperButton.GetComponent<RecruitJumperScript>().index; i++)
        {
            unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(3, id, startPos));
            //Spawn intended unit here, add it to the UnitList
            yield return new WaitForSeconds(1);

        }

        for (int i = 0; i < spyButton.GetComponent<RecruitSpyScript>().index; i++)
        {
            unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(4, id, startPos));
            //Spawn intended unit here, add it to the UnitList
            yield return new WaitForSeconds(1);
        }

        StopCoroutine("spawnUnits");
    }

}
