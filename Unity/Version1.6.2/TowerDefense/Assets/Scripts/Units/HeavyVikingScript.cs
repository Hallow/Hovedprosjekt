using UnityEngine;
using System.Collections;

public class HeavyVikingScript : MonoBehaviour {

	public int Health { get; set; }
	public int Curse { get; set; }
	public float Speed { get; set; }
	public float Damage { get; set; }
	
	
	// Use this for initialization
	void Start () {
		this.Health = 1;
		this.Damage = 11.3f;
		this.Speed = 5.0f; // Is not used at the moment. Speed of unit is set in WayPointScript.
	}
	
	// Update is called once per frame
	void Update () {
		
		// Check curses.
		
		// Attack radius.
		
	}

	public int GetHealth() {
		return Health;
	}
	
	public float GetSpeed() {
		return Speed;
	}

	public void Attack() {
		
	}

	public void Hurt(float damage) {
		damage -= damage / 2.0f;
		this.Health -= (int) damage;
	}
}
