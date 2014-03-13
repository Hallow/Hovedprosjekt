using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

    //Set in Inspector, monitors whether the player has ended the turn
    public GameObject turnController;

	public GameObject buttonFactory;
	public GameObject[] buttonPrefabs;

    public int Health { get; set; }
    public bool IsAlive { get; set; }

	public bool hasUpgraded = false;

	public int structureLevel;
	public int structureType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
    public void Hurt(float damage)
    {
        Health -= (int)damage;

        if (Health <= 0)
        {
            this.IsAlive = false;
            Destroy(gameObject);
        }
    }

	//Called when a building is clicked. This includes the empty slot.
	void OnMouseDown()
	{
		//Since buildings do not level up, the buttons are only spawned if the level is 0, meaning it is just a base.
		if(!hasUpgraded && !turnController.GetComponent<TurnScript>().playerReady)
		{
			GameObject bFactory = (GameObject) Instantiate(buttonFactory);
			bFactory.GetComponent<ButtonFactory>().currentStructure = gameObject;
			bFactory.GetComponent<ButtonFactory>().spawnButtons(structureLevel, structureType, buttonPrefabs);
		} 
		
	}
}
