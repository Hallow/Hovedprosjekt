using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
	
	public GameObject target;	// The targeted enemy.
	
	public Vector3 currentPos;
	public Vector3 nextPos;
	
	public float speed;
	public float lastPosTime;
	public float journeyLength;
	
	public UnitScript unit;
	
	private string tempType;
	public int damage;
	// Use this for initialization
	void Start () {
		damage = 1;
		currentPos = transform.position;
		speed = 10.0f;
		
		transform.LookAt (target.transform.position);	// Makes the projectile pointing in the direction of the target
		// REMEMBER: fix the size of gameObject.
		//nextPos = target.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		lastPosTime += Time.deltaTime;
		if (target != null) 
		{
			nextPos = target.transform.position;
			journeyLength = Vector3.Distance (currentPos, nextPos);
			float distanceCovered = lastPosTime * speed;
			
			float fracJourney = distanceCovered / journeyLength;
			
			transform.position = Vector3.Lerp (currentPos, nextPos, fracJourney);
		} else {
			
			Destroy(gameObject);
		}
	}
	
	
	void OnCollisionEnter(Collision collision)
	{
		// When the projectile hits the target.
		if (collision.gameObject == target) 
		{
			//Destroy (collision.gameObject);
			
			//Destroy (gameObject);
			EvaluateAndHurtTarget(collision);
			Destroy (gameObject);
		}

	}
	
	// Gets the target and hurt it with damage.
	private void EvaluateAndHurtTarget(Collision collision) {

        

		if (target) 
		{
			
			unit = target.GetComponent<UnitScript>();	// Loads the UnitScript of the target.
			unit.Hurt(damage);	// Hurts the target/unit.
			
			//Debug.Log(tempType);
		}
		
	}
}
