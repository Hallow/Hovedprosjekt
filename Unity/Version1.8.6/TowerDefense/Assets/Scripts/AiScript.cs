using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AiScript : MonoBehaviour {

    int id;
    int cash;
    int income;

    public GameObject unitFactory;
    public GameObject factoryPrefab; //SET IN INSPECTOR

    public List<GameObject> unitList;
    public List<GameObject> towerList;

    public GameObject aiStart;

    public GameObject towerFactoryPrefab;
    public GameObject towerFactory;

	// Use this for initialization
	void Start () {
        cash = 150;
        income = 150;
        id = 1;

        towerFactory = (GameObject)Instantiate(towerFactoryPrefab);
        unitFactory = (GameObject)Instantiate(factoryPrefab);

        unitList = new List<GameObject>();

	
	}
	
	// Update is called once per frame
	void Update () {

        //Removes units if theyre destroyed
        foreach(GameObject u in unitList)
        {
            if(!u)
            {
                unitList.Remove(u);
            }
        }
	
	}

    //Each CoRoutine below represents 1 round of AI behaviour. These coRoutines are called from the Game Loop.
    public IEnumerator round1()
    {

        Vector3 slotCo = towerList[0].GetComponent<TowerScript>().transform.position;
        //slotCo.y += 0.15f;
        //slotCo.z -= 0.2f;

        towerList.Add(towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, towerList[0].GetComponent<TowerScript>().towerType, towerList[0].GetComponent<TowerScript>().towerLevel + 1, towerList[0], false, 1));
        towerList.Add(towerFactory.GetComponent<TowerFactory>().spawnTower(towerList[1].transform.position, towerList[1].GetComponent<TowerScript>().towerType, towerList[1].GetComponent<TowerScript>().towerLevel + 1, towerList[1], false, 1));


        unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, id, aiStart));
        yield return new WaitForSeconds(1);
        unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, id, aiStart));
        yield return new WaitForSeconds(1);
        unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, id, aiStart));
        yield return new WaitForSeconds(1);
        unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, id, aiStart));
        yield return new WaitForSeconds(1);
        unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, id, aiStart));
        yield return new WaitForSeconds(1);

        StopCoroutine("round1");
    }

    public IEnumerator round2()
    {
        towerList.Add(towerFactory.GetComponent<TowerFactory>().spawnTower(towerList[3].transform.position, towerList[3].GetComponent<TowerScript>().towerType, towerList[3].GetComponent<TowerScript>().towerLevel + 1, towerList[3], false, 1));
        towerList.Add(towerFactory.GetComponent<TowerFactory>().spawnTower(towerList[1].transform.position, towerList[1].GetComponent<TowerScript>().towerType, towerList[1].GetComponent<TowerScript>().towerLevel + 1, towerList[1], false, 1));

        unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(2, id, aiStart));
        yield return new WaitForSeconds(1);
        unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(2, id, aiStart));
        yield return new WaitForSeconds(1);
        unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, id, aiStart));
        yield return new WaitForSeconds(1);
        unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, id, aiStart));
        yield return new WaitForSeconds(1);
        unitList.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, id, aiStart));
        yield return new WaitForSeconds(1);

        StopCoroutine("round2");
    }
}
