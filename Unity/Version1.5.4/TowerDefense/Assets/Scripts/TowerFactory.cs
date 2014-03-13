using UnityEngine;
using System.Collections;

public class TowerFactory : MonoBehaviour {

	public GameObject[] type0Prefabs; //BASIC TOWERS
	public GameObject[] type1Prefabs; // AoE Towers
	public GameObject[] type2Prefabs; // Slowing Towers
	public GameObject[] type3Prefabs; // Buildings

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnTower(Vector3 towerPos, int type, int level, GameObject currentTower, bool maxUpgraded, int owner)
	{
		GameObject go;

		switch (type) 
		{
		case 0:
			switch(level)
			{
				case 1:
					go = (GameObject)Instantiate (type0Prefabs[0]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					break;
				case 2:
					go = (GameObject)Instantiate (type0Prefabs[1]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
				case 3:
					go = (GameObject)Instantiate (type0Prefabs[2]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
				case 4:
					go = (GameObject)Instantiate (type0Prefabs[3]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
				case 5:
					go = (GameObject)Instantiate (type0Prefabs[4]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
				case 6:
					go = (GameObject)Instantiate (type0Prefabs[5]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
			}
			break;
		case 1:
			switch(level)
			{
				case 1:
					go = (GameObject)Instantiate (type1Prefabs[0]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					break;
				case 2:
					go = (GameObject)Instantiate (type1Prefabs[1]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
				case 3:
					go = (GameObject)Instantiate (type1Prefabs[2]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
				case 4:
					go = (GameObject)Instantiate (type1Prefabs[3]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
				case 5:
					go = (GameObject)Instantiate (type1Prefabs[3]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
			}
			break;
		case 2:
			switch(level)
			{
				case 1:
					go = (GameObject)Instantiate (type2Prefabs[0]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					break;
				case 2:
					go = (GameObject)Instantiate (type2Prefabs[1]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
				case 3:
					go = (GameObject)Instantiate (type2Prefabs[2]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
				case 4:
					go = (GameObject)Instantiate (type2Prefabs[3]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
				case 5:
					go = (GameObject)Instantiate (type2Prefabs[4]);
					go.GetComponent<TowerScript>().towerType = type;
					go.GetComponent<TowerScript>().towerLevel = level;
                    go.GetComponent<TowerScript>().turnController = currentTower.GetComponent<TowerScript>().turnController;
                    go.GetComponent<TowerScript>().owner = owner;
					go.transform.position = towerPos;
					Destroy (currentTower);
					break;
			}
			break;
		case 3:
			switch(level)
			{
			case 1:
				go = (GameObject)Instantiate (type3Prefabs[0]);
				go.GetComponent<BuildingScript>().structureType = type;
				go.GetComponent<BuildingScript>().structureLevel = level;
				go.GetComponent<BuildingScript>().hasUpgraded = maxUpgraded;
                go.GetComponent<BuildingScript>().turnController = currentTower.GetComponent<BuildingScript>().turnController;
				go.transform.position = towerPos;
				break;
			case 2:
				go = (GameObject)Instantiate (type3Prefabs[1]);
				go.GetComponent<BuildingScript>().structureType = type;
				go.GetComponent<BuildingScript>().structureLevel = level;
                go.GetComponent<BuildingScript>().turnController = currentTower.GetComponent<BuildingScript>().turnController;
				go.transform.position = towerPos;
				go.GetComponent<BuildingScript>().hasUpgraded = maxUpgraded;
				//Destroy (currentTower);
				break;

			case 3:
				go = (GameObject)Instantiate (type3Prefabs[2]);
				go.GetComponent<BuildingScript>().structureType = type;
				go.GetComponent<BuildingScript>().structureLevel = level;
                go.GetComponent<BuildingScript>().turnController = currentTower.GetComponent<BuildingScript>().turnController;
				go.transform.position = towerPos;
				go.GetComponent<BuildingScript>().hasUpgraded = maxUpgraded;
				//Destroy (currentTower);
				break;

			case 4:
				go = (GameObject)Instantiate (type3Prefabs[3]);
				go.GetComponent<BuildingScript>().structureType = type;
				go.GetComponent<BuildingScript>().structureLevel = level;
                go.GetComponent<BuildingScript>().turnController = currentTower.GetComponent<BuildingScript>().turnController;
				go.transform.position = towerPos;
				go.GetComponent<BuildingScript>().hasUpgraded = maxUpgraded;
				//Destroy (currentTower);
				break;

			case 5:
				go = (GameObject)Instantiate (type3Prefabs[4]);
				go.GetComponent<BuildingScript>().structureType = type;
				go.GetComponent<BuildingScript>().structureLevel = level;
                go.GetComponent<BuildingScript>().turnController = currentTower.GetComponent<BuildingScript>().turnController;
				go.transform.position = towerPos;
				go.GetComponent<BuildingScript>().hasUpgraded = maxUpgraded;
				//Destroy (currentTower);
				break;

			case 6:
				go = (GameObject)Instantiate (type3Prefabs[5]);
				go.GetComponent<BuildingScript>().structureType = type;
				go.GetComponent<BuildingScript>().structureLevel = level;
                go.GetComponent<BuildingScript>().turnController = currentTower.GetComponent<BuildingScript>().turnController;
				go.transform.position = towerPos;
				go.GetComponent<BuildingScript>().hasUpgraded = maxUpgraded;
				//Destroy (currentTower);
				break;
			}

			break;
		}
	}
}
