using UnityEngine;
using System.Collections;
using System.Threading;

public class SwipeInputScript : MonoBehaviour
{
    public float speed;
    public Vector2 touchStart;
    public Vector2 touchEnd;

    private float lastPosTime;
    private float journeyLength;

    private Vector3 destination;

    int posCounter;

    private Vector3 camPos1;
    private Vector3 camPos2;

    private bool InputHasEnded;

    void Start()
    {
        Thread.Sleep(1000);
        InputHasEnded = false;
        camPos1 = Camera.main.transform.position;
        //destination = new Vector3(0, Camera.main.transform.position.y + 500, 0.0f);
        speed = 0.1f;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            if (Camera.main.transform.position.y != -19.61339f || Camera.main.transform.position.y != 1.011715f)
                transform.Translate(0.0f, -touchDeltaPosition.y * speed, 0);

            if (Camera.main.transform.position.y <= 1.011715f)
            {
                transform.position = new Vector2(0, 1.011714f);

            }
            else if (Camera.main.transform.position.y >= -19.61339f)
            {
                transform.position = new Vector2(0, -19.6134f);
            }
        }
    }

}
