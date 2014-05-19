using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using System.Threading.Tasks;
using System.Threading;

public class FriendInviteButtonScript : MonoBehaviour {

    // 0 for pending, 1 for play, 2 for invite
    public int state;

    public bool buttonIsPressed = false;


    public Texture2D playButtonUp;
    public Texture2D playButtonDown;
    public Texture2D inviteButtonUp;
    public Texture2D inviteButtonDown;
    public Texture2D pendingLabelTexture;
    public GameObject friendInteraction;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        friendInteraction.GetComponent<FriendInteraction>().checkInvites();

        switch (state)
        {
            case 0:
                gameObject.renderer.material.mainTexture = pendingLabelTexture;
                break;
            case 1:
                gameObject.renderer.material.mainTexture = playButtonUp;
                break;
            case 2:
                gameObject.renderer.material.mainTexture = inviteButtonUp;
                break;
        }
	}

    IEnumerator OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /*
            if (buttonIsPressed)
            {
                Release();
            }
            else
            {
                Press();
            }
             * */

            Press();
            yield return new WaitForSeconds(0.1f);
            Release();

            
            switch (state)
            {
                case 0:
                    gameObject.renderer.material.mainTexture = pendingLabelTexture;
                    break;
                case 1:
                    friendInteraction.GetComponent<FriendInteraction>().startMpGame();
                    break;
                case 2:
                    friendInteraction.GetComponent<FriendInteraction>().inviteToGame();
                    state = 0;
                    break;
            }
        }
    }

    private void Press()
    {
        switch (state)
        {
            case 1:
                gameObject.renderer.material.mainTexture = playButtonDown;
                break;
            case 2:
                gameObject.renderer.material.mainTexture = inviteButtonDown;
                break;
        }
        buttonIsPressed = true;
    }

    private void Release()
    {
        switch (state)
        {
            case 1:
                gameObject.renderer.material.mainTexture = playButtonUp;
                break;
            case 2:
                gameObject.renderer.material.mainTexture = inviteButtonUp;
                break;
        }
        buttonIsPressed = false;
    }

    private int GetState()
    {
        return 0;
    }
}
