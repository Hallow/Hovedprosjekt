using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RadiusScript : MonoBehaviour {
	
	public List<GameObject> killList;

	// Use this for initialization
	void Start () {
		killList = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("COLLISION");
        if(other.gameObject.GetComponent<UnitScript>().owner != transform.parent.gameObject.GetComponent<TowerScript>().owner)
        {
            killList.Add(other.gameObject);
        }
	}

	void OnTriggerExit(Collider other)
	{
		//Debug.Log ("COLLISION EXIT");
        if (other.gameObject.GetComponent<UnitScript>().owner != transform.parent.gameObject.GetComponent<TowerScript>().owner)
        {
            killList.Remove(other.gameObject);
        }
	}


	

}
