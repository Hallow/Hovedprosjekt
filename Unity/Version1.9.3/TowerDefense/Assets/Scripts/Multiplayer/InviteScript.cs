using UnityEngine;
using System.Collections;
using Parse;

public class InviteScript : MonoBehaviour {

    public GameObject parentFriend;

    //BUTTON STATES:
    //0 = NO GAME, INVITE
    //1 = HAS GAME, WAITING FOR ACCEPT/PENDING
    //2 = HAS GAME, CAN ACCEPT INVITE
    //3 = GAME IN PROGRESS, PLAY
    public int state;
    public bool transformCheck;

    public ParseObject resultSet;

    //Materials
    public Material inviteMaterial;
    public Material pendingMaterial;
    public Material playMaterial;
    public Material acceptMaterial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transformCheck)
        {
            changeRender(state);
            
        }
	
	}

    void OnMouseDown()
    {
        Debug.Log("Registered Click. State is: " + state);
        switch (state)
        {
            
            case 0:
                //INVITE TO GAME
                parentFriend.GetComponent<FriendInteraction>().inviteToGame();
                state = 1;
                transformCheck = true;
                //Change state and set transform
            break;
            case 1:
                //NOTHING REALLY, INFORM PLAYER ITS PENDING
            break;
            case 2:
                parentFriend.GetComponent<FriendInteraction>().acceptInvite();
                state = 3;
                transformCheck = true;
                //HAS GAME, CAN ACCEPT INVITE
                //Change state and set transform
            break;
            case 3:
                parentFriend.GetComponent<FriendInteraction>().startMpGame(parentFriend.GetComponent<FriendInteraction>().result);
                //ENTER GAME
                //Change state and set transform 
            break;

        }
    }

    public void changeRender(int i)
    {
        switch (i)
        {
            case 0:
                renderer.material = inviteMaterial;
                transformCheck = false;
                break;
            case 1:
                renderer.material = pendingMaterial;
                transformCheck = false;
                break;
            case 2:
                renderer.material = acceptMaterial;
                transformCheck = false;
                break;
            case 3:
                renderer.material = playMaterial;
                transformCheck = false;
                break;
        }  
    }
}
