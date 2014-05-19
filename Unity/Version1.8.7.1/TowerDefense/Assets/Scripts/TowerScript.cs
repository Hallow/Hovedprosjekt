using UnityEngine;
using System.Collections;
using Parse;

public class TowerScript : MonoBehaviour
{

    public GameObject loop;

    public int owner;

    //TowerScript tower;
    RadiusScript radius;
    public GameObject projectilePrefab;

    public bool hasUpgraded = false;

    Vector3 pCurrentPos;
    Vector3 pNextPos;
    float elapsedTime;
    float distanceCovered;
    float speed;
    float journeyLength;

    float timeSinceLastShot;

    public int towerLevel;
    public int towerType;

    public GameObject factoryPrefab;

    //LIST MUST BE FORMATTED AS: TOP LEFT BUTTON, TOP CENTER, TOP RIGHT<<<IN INSPECTOR>>> MAX 3 BUTTONS, EXPANDABLE
    public GameObject[] buttonPrefabs;

    public GameObject playerOwner;

    //The price of the tower, set in initialization
    public int price;

    //MP Stuff
    public bool mp;
    public int parseId;

    // Use this for initialization
    void Start()
    {
        if (towerLevel > 0)
            radius = gameObject.GetComponentInChildren<RadiusScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (loop.GetComponent<GameLoop>().roundActive)
        {
            StartCoroutine("towerThread");
        }
    }

    public void Initialize(GameObject previousTower, bool hasUpgraded, int level)
    {
        Vector3 tempPos;
        tempPos.x = previousTower.transform.position.x;
        tempPos.y = previousTower.transform.position.y + 0.25f;
        tempPos.z = previousTower.transform.position.z - 0.2f;

        transform.position = tempPos;
        towerType = previousTower.GetComponent<TowerScript>().towerType;
        towerLevel = level;
        this.loop = previousTower.GetComponent<TowerScript>().loop;
        this.owner = previousTower.GetComponent<TowerScript>().owner;
        this.hasUpgraded = hasUpgraded;

        if(previousTower.GetComponent<TowerScript>().mp)
        {
            mp = true;
        }

        if (mp)
        {
            if(owner == 0)
            {
                playerOwner = loop.GetComponent<GameLoop>().player1;
            }
            else if (owner == 1)
            {
                playerOwner = loop.GetComponent<GameLoop>().player2;
            }
        }
        else
        {
            if (owner == 0)
            {
                playerOwner = loop.GetComponent<GameLoop>().player1;
            }

            else if (owner == 1)
            {
                playerOwner = loop.GetComponent<GameLoop>().aiPlayer;
            }
        }

        

        //Below switches are used for setting the price of the tower. Price is used in TowerFactory for the player to pay
        //for the tower.
        //TOWER PRICE BALANCING HERE.
        switch (towerType)
        {
            case 0:
                //Basic Towers
                switch (towerLevel)
                {
                    case 0:
                        //Empty slot, no price
                        break;
                    case 1:
                        price = 100;
                        break;
                    case 2:
                        price = 150;
                        break;
                    case 3:
                        price = 200;
                        break;
                    case 4:
                        price = 250;
                        break;
                    case 5:
                        price = 250;
                        break;
                }
                break;
            case 1:
                //AoE Towers
                switch (towerLevel)
                {
                    case 0:
                        //Empty slot, no price
                        break;
                    case 1:
                        price = 100;
                        break;
                    case 2:
                        price = 150;
                        break;
                    case 3:
                        price = 200;
                        break;
                    case 4:
                        price = 250;
                        break;
                    case 5:
                        price = 250;
                        break;
                }
                break;
            case 2:
                //Slowing Towers
                switch (towerLevel)
                {
                    case 0:
                        //Empty slot, no price
                        break;
                    case 1:
                        price = 100;
                        break;
                    case 2:
                        price = 150;
                        break;
                    case 3:
                        price = 200;
                        break;
                    case 4:
                        price = 250;
                        break;
                    case 5:
                        price = 250;
                        break;
                }
                break;
        }


    }

    IEnumerator towerThread()
    {

        timeSinceLastShot += Time.deltaTime;
        if (towerLevel > 0 && radius.killList.Count > 0 && timeSinceLastShot > 1)
        {
            if (radius.killList[0])
            {
                GameObject toKill = radius.killList[0];

                timeSinceLastShot = 0;

                GameObject projectile = (GameObject)Instantiate(projectilePrefab, transform.position, new Quaternion(0, 0, 0, 0));
                projectile.GetComponent<ProjectileScript>().target = toKill;
            }
            else
            {
                radius.killList.Remove(radius.killList[0]);

                GameObject toKill = radius.killList[0];

                timeSinceLastShot = 0;

                GameObject projectile = (GameObject)Instantiate(projectilePrefab, transform.position, new Quaternion(0, 0, 0, 0));
                projectile.GetComponent<ProjectileScript>().target = toKill;
            }

        }

        if (!loop.GetComponent<GameLoop>().roundActive)
        {
            //StopCoroutine("towerThread");
            yield return null;
        }


    }

    //Create CoRoutine for all TOWER LOGIC here, run coroutine in update when checked

    void fireProjectile(GameObject target)
    {

        GameObject go = (GameObject)Instantiate(projectilePrefab, transform.position, new Quaternion(0, 0, 0, 0));
        pCurrentPos = transform.position;
        pNextPos = target.transform.position;
        speed = 1.0f;

        journeyLength = Vector3.Distance(pCurrentPos, pNextPos);
        elapsedTime += Time.deltaTime;
        distanceCovered = elapsedTime * speed;
        float fracJourney = distanceCovered / journeyLength;

        go.transform.position = Vector3.Lerp(pCurrentPos, pNextPos, fracJourney);
    }


    void OnMouseDown()
    {
        if(mp)
        {
            if (!loop.GetComponent<GameLoop>().roundActive && playerOwner.GetComponent<PlayerScript>().username == (string)ParseUser.CurrentUser["username"])
            {
                if (towerLevel == 1 || towerLevel == 2)
                {
                    GameObject bFactory = (GameObject)Instantiate(factoryPrefab);
                    bFactory.GetComponent<ButtonFactory>().currentStructure = gameObject;
                    bFactory.GetComponent<ButtonFactory>().spawnButtons(towerLevel, towerType, buttonPrefabs);
                }
                else if (towerLevel == 0 && !hasUpgraded)
                {
                    GameObject bFactory = (GameObject)Instantiate(factoryPrefab);
                    bFactory.GetComponent<ButtonFactory>().currentStructure = gameObject;
                    bFactory.GetComponent<ButtonFactory>().spawnButtons(towerLevel, towerType, buttonPrefabs);
                    //hasUpgraded = true;
                    //TODO: Move the above line somewhere where it doesnt trigger on click
                }
                else
                {
                    return;
                }
            }
        }
        else
        {
            if (!loop.GetComponent<GameLoop>().roundActive && owner == 0)
            {
                if (towerLevel == 1 || towerLevel == 2)
                {
                    GameObject bFactory = (GameObject)Instantiate(factoryPrefab);
                    bFactory.GetComponent<ButtonFactory>().currentStructure = gameObject;
                    bFactory.GetComponent<ButtonFactory>().spawnButtons(towerLevel, towerType, buttonPrefabs);
                }
                else if (towerLevel == 0 && !hasUpgraded)
                {
                    GameObject bFactory = (GameObject)Instantiate(factoryPrefab);
                    bFactory.GetComponent<ButtonFactory>().currentStructure = gameObject;
                    bFactory.GetComponent<ButtonFactory>().spawnButtons(towerLevel, towerType, buttonPrefabs);
                    //hasUpgraded = true;
                    //TODO: Move the above line somewhere where it doesnt trigger on click
                }
                else
                {
                    return;
                }
            }
        }
        
    }

    void aiUpgrade()
    {

    }
}
