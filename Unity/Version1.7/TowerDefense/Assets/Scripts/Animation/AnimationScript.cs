using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

// Made from reference: http://www.youtube.com/watch?v=kSVjRgjZTVc

public class AnimationScript : MonoBehaviour
{
    public float FPS;
    public float secondsToWait;
    public bool loop;

    private float possibleX;
    private float possibleY;

    public List<Texture> downFrames;    // Lists of frames (downwards).
    public List<Texture> upFrames;  // Lists of frames (upwards).
    public List<Texture> leftFrames;    // Lists of frames (left).
    public List<Texture> rightFrames;   // Lists of frames (right).

    public List<Texture> currentFrames;

    private int currentFrame;

    private Waypoint2Script waypointScript;

    // Use this for initialization
    void Start()
    {
        FPS = 25.0f;
        currentFrame = 0;
        secondsToWait = 1 / FPS;
        StartCoroutine(Animate());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Animate()
    {
        waypointScript = gameObject.GetComponent<Waypoint2Script>();    // Loading the waypoint script.

        possibleX = waypointScript.nextPos.x - waypointScript.currentPos.x;     // Calculating distance from current X position to the next X position.
        if (possibleX < 0)      // Makes the length positive.
        {
            possibleX = possibleX * -1;
        }

        possibleY = waypointScript.nextPos.y - waypointScript.currentPos.y;     // Calculating distance from current X position to the next X position.
        if (possibleY < 0)      // Makes the length positive.
        {
            possibleY = possibleY * -1;
        }

        if (possibleX > possibleY)
        {
            if (waypointScript.currentPos.x > waypointScript.nextPos.x)
            {
                currentFrames = leftFrames;
            }
            else
            {
                currentFrames = rightFrames;
            }
        }
        else
        {
            if (waypointScript.currentPos.y > waypointScript.nextPos.y)
            {
                currentFrames = downFrames;
            }
            else
            {
                currentFrames = upFrames;
            }
        }


        bool stop = false;

        if (currentFrame >= currentFrames.Count)
        {
            if (loop == false)
            {
                stop = true;
            }
            else
            {
                currentFrame = 0;
            }
        }

        yield return new WaitForSeconds(secondsToWait);

        renderer.material.mainTexture = currentFrames[currentFrame];
        currentFrame++;


        if (stop == false)
            StartCoroutine(Animate());
    }
}
