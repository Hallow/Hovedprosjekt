using UnityEngine;
using System.Collections;

public class BaseCollisionScript : MonoBehaviour {

    public int owner;

    public GameObject player;
    public GameObject aiPlayer;
    public GameObject loop;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        int collisionOwner = collision.gameObject.GetComponent<UnitScript>().owner;
        Debug.Log("CollisionOwner = " + collisionOwner);

        if (collisionOwner == owner) {


        }
        else
        {
            if (collisionOwner == 0)
            {
                aiPlayer.GetComponent<PlayerScript>().health--;
                GameObject.Destroy(collision.gameObject);
            }
            else
            {
                player.GetComponent<PlayerScript>().health--;
                GameObject.Destroy(collision.gameObject);
            }
        }
    }
}
