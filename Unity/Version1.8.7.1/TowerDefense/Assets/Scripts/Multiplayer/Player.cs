using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public List<int> Towers;
    public List<int> Units;
    public List<int> Upgrades;

    public Player(string username)
    {

    }

	// Use this for initialization
	void Start () {
        Towers = new List<int>();
        Units = new List<int>();
        Upgrades = new List<int>();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
