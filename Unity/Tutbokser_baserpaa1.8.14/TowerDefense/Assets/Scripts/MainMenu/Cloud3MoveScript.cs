using UnityEngine;
using System.Collections;

public class Cloud3MoveScript : MonoBehaviour {

    public GameObject point1;
    public GameObject point2;

    public Vector3 currentPos;
    public Vector3 nextPos;

    public float speed;

    private float lastPosTime;
    public float journeyLength;

    // Use this for initialization
    void Start()
    {

        //if (speed == null)
        speed = 2.6f;
        //gameObject.transform.position = new Vector3(9.117565f, 24.90881f, 8.548942f);
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, point1.transform.position, Time.deltaTime * speed);

        if (transform.position.y == point1.transform.position.y)
        {
            transform.position = point2.transform.position;
        }
    }
}
