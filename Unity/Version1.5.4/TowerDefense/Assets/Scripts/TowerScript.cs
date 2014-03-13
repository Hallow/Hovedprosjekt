using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {

	//Set in Inspector, monitors whether the player has ended the turn
	public GameObject turnController;

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

	// Use this for initialization
	void Start () {
		if(towerLevel > 0)
			radius = gameObject.GetComponentInChildren<RadiusScript> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if(turnController.GetComponent<TurnScript>().allReady)
		{
			StartCoroutine("towerThread");
		}
	}

	IEnumerator towerThread()
	{
		if (!turnController.GetComponent<TurnScript> ().allReady) 
		{
			StopCoroutine("towerThread");
		}

		timeSinceLastShot += Time.deltaTime;
		if (towerLevel > 0 && radius.killList.Count > 0 && timeSinceLastShot > 1) 
		{
			if(radius.killList[0])
			{
				GameObject toKill = radius.killList[0];
				
				timeSinceLastShot = 0;
				
				GameObject projectile = (GameObject) Instantiate(projectilePrefab, transform.position, new Quaternion(0,0,0,0));
				projectile.GetComponent<ProjectileScript>().target = toKill;
			} else {
				radius.killList.Remove (radius.killList[0]);
				
				GameObject toKill = radius.killList[0];
				
				timeSinceLastShot = 0;
				
				GameObject projectile = (GameObject) Instantiate(projectilePrefab, transform.position, new Quaternion(0,0,0,0));
				projectile.GetComponent<ProjectileScript>().target = toKill;
			}
			
		}

		yield return null;
	}

	//Create CoRoutine for all TOWER LOGIC here, run coroutine in update when checked

	void fireProjectile(GameObject target)
	{

		GameObject go = (GameObject)Instantiate (projectilePrefab, transform.position, new Quaternion(0,0,0,0));
		pCurrentPos = transform.position;
		pNextPos = target.transform.position;
		speed = 1.0f;

		journeyLength = Vector3.Distance (pCurrentPos, pNextPos);
		elapsedTime += Time.deltaTime;
		distanceCovered = elapsedTime * speed;
		float fracJourney = distanceCovered / journeyLength;

		go.transform.position = Vector3.Lerp (pCurrentPos, pNextPos, fracJourney);
	}


	void OnMouseDown()
	{
        if (!turnController.GetComponent<TurnScript>().allReady && owner == 0)
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
                hasUpgraded = true;
            }
            else
            {
                return;
            }
        }
	}

    void aiUpgrade()
    {

    }
}
