using UnityEngine;
using System.Collections.Generic;

public class AiScript : MonoBehaviour {

    int id;
    int cash;
    int income;

    public GameObject turnController;

    public GameObject unitFactory;
    public GameObject factoryPrefab; //SET IN INSPECTOR

    public List<GameObject> queuedUnits;
    public List<GameObject> ownedTowers;

    public GameObject aiStart;

    public GameObject towerFactoryPrefab;
    public GameObject towerFactory;

	// Use this for initialization
	void Start () {
        cash = 150;
        income = 150;
        id = 1;

        towerFactory = (GameObject)Instantiate(towerFactoryPrefab);

        queuedUnits = new List<GameObject>();
	
	}
	
	// Update is called once per frame
	void Update () {

        foreach(GameObject u in queuedUnits)
        {
            if(!u)
            {
                queuedUnits.Remove(u);
            }
        }
	
	}

    //STATIC AI BEHAVIOUR FOLLOWS

    /*
    void round1()
    {
        unitFactory = (GameObject)Instantiate(factoryPrefab);
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        //ownedTowers[0].SendMessage("OnMouseDown");

        Vector3 slotCo = ownedTowers[0].GetComponent<TowerScript>().transform.position;
        slotCo.y += 0.15f;
        slotCo.z -= 0.2f;

        //Debug.Log("Testetsteteststestetstetstet");

        towerFactory.GetComponent<TowerFactory>().spawnTower(slotCo, ownedTowers[0].GetComponent<TowerScript>().towerType, ownedTowers[0].GetComponent<TowerScript>().towerLevel + 1, ownedTowers[0], false, 1);

        turnController.GetComponent<TurnScript>().enemyReady = true;

    }

    void round2()
    {
        unitFactory = (GameObject)Instantiate(factoryPrefab);
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        turnController.GetComponent<TurnScript>().enemyReady = true;

    }

    void round3()
    {
        unitFactory = (GameObject)Instantiate(factoryPrefab);
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        queuedUnits.Add(unitFactory.GetComponent<UnitFactory>().spawnUnit(0, turnController, id, aiStart));
        turnController.GetComponent<TurnScript>().enemyReady = true;

    }*/
}
