using UnityEngine;
using System.Collections;

public class UnitMoveScript : MonoBehaviour {


    public GameObject waypointContainer;
    public int posCounter;
    public Vector3 currentPos;
    public Vector3 nextPos;
    private float lastPosTime;
    public float journeyLength;
    public float speedInc;
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lastPosTime += Time.deltaTime * speedInc;	// Add last float to increase speed.
        float distanceCovered = lastPosTime * speed;
        float fracJourney = distanceCovered / journeyLength;

        gameObject.transform.position = Vector3.Lerp(currentPos, nextPos, fracJourney);

        posCounter++;
        lastPosTime = 0;

        currentPos = gameObject.transform.position;
        nextPos = waypointContainer.transform.position;
        journeyLength = Vector3.Distance(currentPos, nextPos);
        if (transform.position.Equals(nextPos))
        {
        }
	}
}
