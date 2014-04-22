using UnityEngine;
using System.Collections;
using System;

public class FriendListScrollScript : MonoBehaviour
{

    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit_position.y = Input.mousePosition.y;
            camera_position.y = transform.position.y;
        }
        if (Input.GetMouseButton(0))
        {
            current_position.y = Input.mousePosition.y;


            LeftMouseDrag();
        }
    }

    void LeftMouseDrag()
    {
        // From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
        // with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
        //current_position.z = hit_position.z = camera_position.y;

        // Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
        // anyways.  

        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

        // Invert direction to that terrain appears to move with the mouse.
        direction = direction * -1;

        Vector3 position = camera_position + direction;

        //transform.position = position;

        transform.position = new Vector3(Mathf.Clamp(0,0,0), Mathf.Clamp(position.y, -50f, 1.011715f), Mathf.Clamp(0,0,0));
    }
}
