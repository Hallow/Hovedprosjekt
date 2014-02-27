using UnityEngine;
using System.Collections;

public class BasicVikingScript : MonoBehaviour {

	public int Health { get; set; }
	public int Curse { get; set; }
	public float Speed { get; set; }
	public float Damage { get; set; }

	public bool dead = false;

	
	// Use this for initialization
	void Start () {
		Health = 3;
		Damage = 2.9f;
		this.Speed = 2.1f;	// Is not used at the moment. Speed of unit is set in WayPointScript.
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
		Health -= (int)damage;
		Debug.Log (Health);

		if(Health <= 0)
		{
			dead = true;
			Destroy (gameObject);
		}
	}

}
