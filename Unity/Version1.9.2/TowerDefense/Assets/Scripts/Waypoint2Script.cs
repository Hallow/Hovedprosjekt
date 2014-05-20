using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Linq;


public class Waypoint2Script : MonoBehaviour {

    //Derived from Unit Factory, which again derives it from the turn script
    public GameObject turnController;

    public GameObject loop;

    public List<GameObject> waypointList1;
    public List<GameObject> waypointList2;
    public List<GameObject> waypointList3;
    public GameObject waypointContainer;

    // This is the speed of the unit. Is set from the unit's script.
    public float UnitSpeed;

    public int Path { get; set; }

	public int posCounter;
	public Vector3 currentPos;
	public Vector3 nextPos;
	
	// This is the speed of the unit. Is set from the unit's script.
	public float speed;
	
	private float lastPosTime;
	public float journeyLength;
	
	public Vector3[] waypointVectors;
	
	//public UnitScript unit;
	
	public int type;
	
	// JUMPER VARIABLES
	private float raise = 0;	// Holding the current raise. Used to set the y-coordinate of unit.
	public float maxHeight = 0.2f;	// The maximum height for the unit to jump.
	public float moveJump = 0.02f;	// How much to jump for each frame.
	public float speedInc = 2.8f;	// For increasing the speed of the jumper.
	
	// Use this for initialization
	void Start () {

        loop = GameObject.Find("GameLoop");

        DetermineWaypoints();


        Path = 1;
        //Path = loop.GetComponent<GameLoop>().playerPath;
		
		//unit = gameObject.GetComponent<UnitScript> ();
		
		posCounter = 0;
        speed = gameObject.GetComponent<UnitScript>().GetSpeed();
        type = gameObject.GetComponent<UnitScript>().Type;
		
		journeyLength = Vector3.Distance (currentPos, nextPos);

        waypointList1 = extractWaypoints(waypointContainer);
        waypointList2 = waypointList1;
        waypointList3 = waypointList1;

        currentPos = waypointList1[posCounter].transform.position;
        nextPos = waypointList1[posCounter + 1].transform.position;

        if(gameObject.GetComponent<UnitScript>().owner == 1)
        {
            waypointList1.Reverse();
        }
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("Path: " + Path);

        if (loop.GetComponent<GameLoop>().gameOver)
        {
            StopCoroutine("unitMovement");
        }
        else
        {
            StartCoroutine("unitMovement");
        }
		
	}

    List<GameObject> extractWaypoints(GameObject waypointContainer)
    {
        List<GameObject> golist = new List<GameObject>();

        foreach(Transform child in waypointContainer.transform)
        {
            golist.Add(child.gameObject);
        }
        //golist.Sort(CompareListByName);

        golist.Sort(delegate(GameObject i1, GameObject i2)
            {
                 return i1.name.CompareTo(i2.name);
            }
        );

        return golist;
    }
	
	IEnumerator unitMovement()
	{
        // TODO: Walk the path according to the Path variable.

        if (type == 3)
        {	// Since the jumper moves different than the other units. It needs its own case.
            lastPosTime += Time.deltaTime * speedInc;	// Add last float to increase speed.
            float distanceCovered = lastPosTime * speed;

            if (raise < maxHeight)
            {
                raise += moveJump;
            }
            else
            {
                raise -= moveJump;
            }

            float fracJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(currentPos, nextPos, fracJourney);
            currentPos.y += raise / 2;
            transform.position = Vector3.Lerp(currentPos, nextPos, fracJourney);

            if (transform.position.Equals(nextPos))
            {
                posCounter++;
                lastPosTime = 0;

                if (gameObject.GetComponent<UnitScript>().owner == 1)
                {
                    currentPos = waypointList1[posCounter].transform.position;
                    nextPos = waypointList1[posCounter + 1].transform.position;
                    journeyLength = Vector3.Distance(currentPos, nextPos);
                }
                else
                {
                    switch (Path)
                    {
                        case 1:
                            currentPos = waypointList1[posCounter].transform.position;
                            nextPos = waypointList1[posCounter + 1].transform.position;
                            journeyLength = Vector3.Distance(currentPos, nextPos);
                            break;
                        case 2:
                            currentPos = waypointList2[posCounter].transform.position;
                            nextPos = waypointList2[posCounter + 1].transform.position;
                            journeyLength = Vector3.Distance(currentPos, nextPos);
                            break;
                        case 3:
                            currentPos = waypointList3[posCounter].transform.position;
                            nextPos = waypointList3[posCounter + 1].transform.position;
                            journeyLength = Vector3.Distance(currentPos, nextPos);
                            break;
                    }
                }
            }
        }
        else // Other units.
        {
            lastPosTime += Time.deltaTime;
            float distanceCovered = lastPosTime * speed;
            float fracJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(currentPos, nextPos, fracJourney);

            if (transform.position.Equals(nextPos))
            {
                posCounter++;
                lastPosTime = 0;

                switch (Path) {
                    case 1:
                        currentPos = waypointList1[posCounter].transform.position;
                        nextPos = waypointList1[posCounter + 1].transform.position;
                        journeyLength = Vector3.Distance(currentPos, nextPos);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
        }

        yield return null;
	}

    private static int CompareListByName(GameObject i1, GameObject i2)
    {
        return i1.name.CompareTo(i2.name);
    }

    // Sets the speed of the unit.
    public void SetUnitSpeed(float speed)
    {
        this.UnitSpeed = speed;
    }

    // Loads the correct waypoint container for the according level.
    public void DetermineWaypoints()
    {
        switch (Application.loadedLevel)
        {
            case 9: // Level 1 wood.
                waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer1");
                break;
            case 10: // Level 2 wood.
                waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer2");
                break;
            case 11: // Level 3 wood.
                Path = 2;
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer3");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer4");
                }
                break;
            case 12: // Level 4 wood.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer5");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer6");
                }
                break;
            case 13: // Level 5 wood.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer7");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer8");
                }
                break;
            case 14: // Level 6 wood.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer9");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer10");
                }
                break;
            case 15: // Level 1 snow.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer11");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer12");
                }
                break;
            case 16: // Level 2 snow.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer13");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer14");
                }
                break;
            case 17: // Level 3 snow.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer15");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer16");
                }
                break;
            case 18: // Level 4 snow.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer17");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer18");
                }
                break;
            case 19: // Level 5 snow.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer19");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer20");
                }
                break;
            case 20: // Level 1 hel.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer21");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer22");
                }
                break;
            case 21: // Level 2 hel.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer23");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer24");
                }
                break;
            case 22: // Level 3 hel.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer25");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer26");
                }
                break;
            case 23: // Level 4 hel.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer27");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer28");
                }
                break;
            case 24: // Level 5 hel.
                if (Path == 1)
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer29");
                }
                else
                {
                    waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer30");
                }
                break;
            case 25:
                waypointContainer = (GameObject)Resources.Load("WaypointContainers/WaypointContainer2");
                break;
        }
    }
 
	//Create a CoRoutine for all Unit Movement logic here and run it in Update.
}