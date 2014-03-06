using UnityEngine;
using System.Collections;

public class GameLoop : MonoBehaviour {

    public GameObject player1;
    GameObject player2;
    public GameObject player1Ready;
    GameObject player2Ready;
    public bool roundActive;

    int turnNumber;

	// Use this for initialization
	void Start () {
        roundActive = false;
        turnNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(player1Ready.GetComponent<PlayerReady>().ready && !roundActive)
        {
            //ADD TO IF: && player2Ready.GetComponent<Player2Ready>().ready
            player1.GetComponent<PlayerScript>().StartCoroutine("spawnUnits");
            //player2.GetComponent<PlayerScript>().StartCoroutine("spawnUnits");
            roundActive = true;

        }

        if(player1.GetComponent<PlayerScript>().unitList.Count >= 0 && roundActive)
        {
            //ADD TO IF: && player2.GetComponent<PlayerScript>().unitList.Count >= 0
            player1Ready.GetComponent<PlayerReady>().ready = false;
            //player2Ready.GetComponent<Player2Ready>().ready = false;
            roundActive = false;
            turnNumber++;
        }
	
	}
}
