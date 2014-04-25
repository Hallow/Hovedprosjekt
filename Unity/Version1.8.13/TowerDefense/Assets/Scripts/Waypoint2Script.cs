using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Linq;


public class Waypoint2Script : MonoBehaviour {

    //Derived from Unit Factory, which again derives it from the turn script
    public GameObject turnController;

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
	public float speedInc = 2.8f;	// For increasing the speed of the jumper
	
	// Use this for initialization
	void Start () {

        if (Path == 0)
        {
            Path = 1;
        }
		
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

       StartCoroutine("unitMovement");
		
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
 
	//Create a CoRoutine for all Unit Movement logic here and run it in Update.
}