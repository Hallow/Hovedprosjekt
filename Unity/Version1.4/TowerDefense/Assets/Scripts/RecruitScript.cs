using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecruitScript : MonoBehaviour {

	//The type of the unit to be recruited.
	//0 = Basic, 1 = Scout, 2 = Heavy, 3 = Jumper, 4 = Spy
	public int unitType;

	public GameObject unitFactory;
	public GameObject factoryPrefab; //SET IN INSPECTOR

    public GameObject turnController;

    public GameObject player; //SET IN INSPECTOR

    public GameObject startPos;

    public 

	// Use this for initialization
	void Start () {

		//TEMPORARY
		unitType = 0; //Basic
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
        if(!turnController.GetComponent<TurnScript>().playerReady)
        {
            unitFactory = (GameObject)Instantiate(factoryPrefab);
            unitFactory.GetComponent<UnitFactory>().spawnUnit(unitType, turnController, player.GetComponent<PlayerScript>().id, startPos);
        }
	}
}
