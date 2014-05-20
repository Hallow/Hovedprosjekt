﻿using UnityEngine;
using System.Collections;

public class UnitFactory : MonoBehaviour
{

    //Derived from the turnScript
    public GameObject turnController;

    public GameObject[] prefabs;

    public float elapsedTime;

    public GameObject loop;

    public GameObject startPos;

    // Use this for initialization
    void Start()
    {
        //spawnUnit ();	
    }

    // Update is called once per frame
    void Update()
    {
        //elapsedTime += Time.deltaTime;
        //Debug.Log (elapsedTime);
        /*
        if (elapsedTime >= 2) 
        {
            elapsedTime = 0;
            spawnUnit ();
        }
        */
        //spawnUnit ();
        //Instantiate (UnitPrefab);
        //UnitPrefab.transform.position = UnitPrefab.
    }

    //Method is called in order to spawn a unit, type must be specified.
    public GameObject spawnUnit(int type, int owner, GameObject spawnPoint)
    {
        GameObject go;

        //go.GetComponent<UnitScript> ().Initialize (3, 1.0f, 1.0f, type);
        //go.transform.position = startPos.transform.position;

        switch (type)
        {
            case 0: //BASIC UNIT
                go = (GameObject)Instantiate(prefabs[type]);
                go.GetComponent<UnitScript>().Initialize(3, 1.0f, 1.0f, type, owner, 1f); //CHANGE VALUES FOR BALANCING

                /*
                if (owner == 1)
                {
                    go.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 20, spawnPoint.transform.position.z - 5);
                }
                else
                {
                    go.transform.position = spawnPoint.transform.position;
                }*/

                go.transform.position = spawnPoint.transform.position;

                return go;
            case 1: //SCOUT UNIT
                go = (GameObject)Instantiate(prefabs[type]);
                go.GetComponent<UnitScript>().Initialize(3, 1.5f, 1.0f, type, owner, 1f); //CHANGE VALUES FOR BALANCING

                /*
                if (owner == 1)
                {
                    go.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 20, spawnPoint.transform.position.z - 5);
                }
                else
                {
                    go.transform.position = spawnPoint.transform.position;
                }
                 * */


                go.transform.position = spawnPoint.transform.position;
                return go;
            case 2: //HEAVY UNIT
                go = (GameObject)Instantiate(prefabs[type]);
                go.GetComponent<UnitScript>().Initialize(3, 1.0f, 1.0f, type, owner, 1f); //CHANGE VALUES FOR BALANCING

                /*
                if (owner == 1)
                {
                    go.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 20, spawnPoint.transform.position.z - 5);
                }
                else
                {

                    go.transform.position = spawnPoint.transform.position;
                }
                 * */


                go.transform.position = spawnPoint.transform.position;
                return go;
            case 3: //JUMPER UNIT
                go = (GameObject)Instantiate(prefabs[type]);
                go.GetComponent<UnitScript>().Initialize(3, 1.0f, 1.0f, type, owner, 1f); //CHANGE VALUES FOR BALANCING

                /*
                if (owner == 1)
                {
                    go.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 20, spawnPoint.transform.position.z - 5);
                }
                else
                {

                    go.transform.position = spawnPoint.transform.position;
                }
                 * */


                go.transform.position = spawnPoint.transform.position;
                return go;
            case 4: //SPY UNIT
                go = (GameObject)Instantiate(prefabs[type]);
                go.GetComponent<UnitScript>().Initialize(3, 1.0f, 1.0f, type, owner, 1f); //CHANGE VALUES FOR BALANCING
                go.transform.position = spawnPoint.transform.position;
                return go;
        }
        return null;
    }
}
