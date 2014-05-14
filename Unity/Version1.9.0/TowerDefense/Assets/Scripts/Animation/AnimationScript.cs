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

    public List<Texture> playerDownFrames;
    public List<Texture> playerUpFrames;
    public List<Texture> playerLeftFrames;
    public List<Texture> playerRightFrames;

    public List<Texture> playerDownAttackFrames;
    public List<Texture> playerUpAttackFrames;
    public List<Texture> playerLeftAttackFrames;
    public List<Texture> playerRightAttackFrames;

    public List<Texture> player2DownFrames;
    public List<Texture> player2UpFrames;
    public List<Texture> player2LeftFrames;
    public List<Texture> player2RightFrames;

    public List<Texture> player2DownAttackFrames;
    public List<Texture> player2UpAttackFrames;
    public List<Texture> player2LeftAttackFrames;
    public List<Texture> player2RightAttackFrames;

    public List<Texture> currentFrames;

    private int currentFrame;

    private Waypoint2Script waypointScript;

    // Use this for initialization
    void Start()
    {
        FPS = 25.0f;

        if (gameObject.GetComponent<UnitScript>().Type == 1)
        {
            FPS = 10;
        }

        currentFrame = 0;
        StartCoroutine(Animate());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Animate()
    {

        secondsToWait = 1 / FPS;
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
                if (gameObject.GetComponent<UnitScript>().owner == 0)
                {
                    currentFrames = playerLeftFrames;
                }
                else
                {
                    currentFrames = player2LeftFrames;
                }
                //currentFrames = leftFrames;
            }
            else
            {
                if (gameObject.GetComponent<UnitScript>().owner == 0)
                {
                    currentFrames = playerRightFrames;
                }
                else
                {
                    currentFrames = player2RightFrames;
                }
                //currentFrames = rightFrames;
            }
        }
        else
        {
            if (waypointScript.currentPos.y > waypointScript.nextPos.y)
            {
                if (gameObject.GetComponent<UnitScript>().owner == 0)
                {
                    currentFrames = playerDownFrames;
                }
                else
                {
                    currentFrames = player2DownFrames;
                }
                //currentFrames = downFrames;
            }
            else
            {
                if (gameObject.GetComponent<UnitScript>().owner == 0)
                {
                    currentFrames = playerUpFrames;
                }
                else
                {
                    currentFrames = player2UpFrames;
                }
                //currentFrames = upFrames;
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
