using UnityEngine;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public int id;
    int cash;
    int income;

    public GameObject turnController; //SET IN INSPECTOR

    public List<GameObject> queuedUnits;



	// Use this for initialization
	void Start () {
        cash = 150;
        income = 150;
        id = 0;

        queuedUnits = new List<GameObject>();
	
	}
	
	// Update is called once per frame
	void Update () {

        foreach (GameObject u in queuedUnits)
        {
            if (!u)
            {
                queuedUnits.Remove(u);
            }
        }

        if (queuedUnits.Count <= 0)
        {
            //turnController.GetComponent<TurnScript>().playerReady = false;
        }
	
	}

}
