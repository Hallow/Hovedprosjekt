using UnityEngine;
using System.Collections;

public class TowerFactory : MonoBehaviour
{

    public GameObject[] type0Prefabs; //BASIC TOWERS
    public GameObject[] type1Prefabs; // AoE Towers
    public GameObject[] type2Prefabs; // Slowing Towers
    public GameObject[] type3Prefabs; // Buildings

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject spawnTower(Vector3 towerPos, int type, int level, GameObject currentTower, bool maxUpgraded, int owner)
    {
        GameObject go;

        //Switches on the type of the tower, and then again on the level. Each case (on the innermost level) instantiates the
        //tower that is to be constructed, then initializes it, which defines all the necesary attributes.
        //Lastly, a check is run to see if the player in question can afford the tower hes creating. If he can't, the tower
        //is destroyed again and if he can, the old tower is destroyed. If the current tower/structure is a building or an
        //empty slot, the current tower will not be destroyed regardless.

        //The cash check is done using the "deIncrementCash" method defined in the game loop.
        switch (type)
        {
            case 0:
                switch (level)
                {
                    case 1:
                        go = (GameObject)Instantiate(type0Prefabs[0]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        return go;
                    case 2:
                        go = (GameObject)Instantiate(type0Prefabs[1]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                    case 3:
                        go = (GameObject)Instantiate(type0Prefabs[2]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }

                        return go;
                    case 4:
                        go = (GameObject)Instantiate(type0Prefabs[3]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                    case 5:
                        go = (GameObject)Instantiate(type0Prefabs[4]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                    case 6:
                        go = (GameObject)Instantiate(type0Prefabs[5]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                }
                break;
            case 1:
                switch (level)
                {
                    case 1:
                        go = (GameObject)Instantiate(type1Prefabs[0]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        return go;
                    case 2:
                        go = (GameObject)Instantiate(type1Prefabs[1]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                    case 3:
                        go = (GameObject)Instantiate(type1Prefabs[2]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                    case 4:
                        go = (GameObject)Instantiate(type1Prefabs[3]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                    case 5:
                        go = (GameObject)Instantiate(type1Prefabs[3]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                }
                break;
            case 2:
                switch (level)
                {
                    case 1:
                        go = (GameObject)Instantiate(type2Prefabs[0]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        return go;
                    case 2:
                        go = (GameObject)Instantiate(type2Prefabs[1]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                    case 3:
                        go = (GameObject)Instantiate(type2Prefabs[2]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                    case 4:
                        go = (GameObject)Instantiate(type2Prefabs[3]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                    case 5:
                        go = (GameObject)Instantiate(type2Prefabs[4]);
                        go.GetComponent<TowerScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<TowerScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<TowerScript>().playerOwner, go.GetComponent<TowerScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<TowerScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        else
                        {
                            Destroy(currentTower);
                        }
                        return go;
                }
                break;
            case 3:
                switch (level)
                {
                    case 1: //Town Hall
                        go = (GameObject)Instantiate(type3Prefabs[0]);
                        go.GetComponent<BuildingScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<BuildingScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<BuildingScript>().playerOwner, go.GetComponent<BuildingScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this building.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<BuildingScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        return go;
                    case 2: //Barracks
                        go = (GameObject)Instantiate(type3Prefabs[1]);
                        go.GetComponent<BuildingScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<BuildingScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<BuildingScript>().playerOwner, go.GetComponent<BuildingScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this building.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<BuildingScript>().hasUpgraded = false;
                            Destroy(go);
                        }

                        //Destroy (currentTower);
                        return go;

                    case 3:
                        go = (GameObject)Instantiate(type3Prefabs[2]);
                        go.GetComponent<BuildingScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<BuildingScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<BuildingScript>().playerOwner, go.GetComponent<BuildingScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<BuildingScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        //Destroy (currentTower);
                        return go;

                    case 4:
                        go = (GameObject)Instantiate(type3Prefabs[3]);
                        go.GetComponent<BuildingScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<BuildingScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<BuildingScript>().playerOwner, go.GetComponent<BuildingScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<BuildingScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        //Destroy (currentTower);
                        return go;

                    case 5:
                        go = (GameObject)Instantiate(type3Prefabs[4]);
                        go.GetComponent<BuildingScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<BuildingScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<BuildingScript>().playerOwner, go.GetComponent<BuildingScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            currentTower.GetComponent<BuildingScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        //Destroy (currentTower);
                        return go;

                    case 6:
                        go = (GameObject)Instantiate(type3Prefabs[5]);
                        go.GetComponent<BuildingScript>().Initialize(currentTower, maxUpgraded, level);
                        if (!go.GetComponent<BuildingScript>().loop.GetComponent<GameLoop>().decrementCash(go.GetComponent<BuildingScript>().playerOwner, go.GetComponent<BuildingScript>().price))
                        {
                            //If this block triggers, the player has insufficient funds to purchase this tower.
                            Debug.Log("Cant afford this tower");
                            Debug.Log(currentTower.GetComponent<BuildingScript>().hasUpgraded);
                            currentTower.GetComponent<BuildingScript>().hasUpgraded = false;
                            Destroy(go);
                        }
                        //Destroy (currentTower);
                        return go;
                }

                break;
        }

        return null;
    }
}
