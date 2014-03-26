using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

    //Set in Inspector, monitors whether the player has ended the turn
    public GameObject loop;

	public GameObject buttonFactory;
	public GameObject[] buttonPrefabs;

    public int Health { get; set; }
    public bool IsAlive { get; set; }

	public bool hasUpgraded = false;

	public int structureLevel;
	public int structureType;

    public int owner;

    public GameObject playerOwner;

    public int price;

	// Use this for initialization
	void Start () {
	
	}

    public void Initialize(GameObject previousTower, bool hasUpgraded, int level)
    {
        Vector3 tempPos;
        tempPos.x = previousTower.transform.position.x;
        tempPos.y = previousTower.transform.position.y + 0.25f;
        tempPos.z = previousTower.transform.position.z - 0.2f;

        transform.position = tempPos;
        structureType = previousTower.GetComponent<BuildingScript>().structureType;
        structureLevel = level;
        this.loop = previousTower.GetComponent<BuildingScript>().loop;
        this.owner = previousTower.GetComponent<BuildingScript>().owner;
        this.hasUpgraded = hasUpgraded;

        //Sets a reference to the actual owners game object by looking at the owner int value. 
        //If in Single player, 0 is always human and 1 is AI.
        if(owner == 0)
        {
            playerOwner = loop.GetComponent<GameLoop>().player1;
        } 
        
        else if(owner == 1)
        {
            playerOwner = loop.GetComponent<GameLoop>().aiPlayer;
        }

        //Initialization logic for separate buildings, sets price
        //BUILDING PRICE BALANCING HERE
        switch (structureLevel)
        {
            case 0:
                //Empty slot
                break;
            case 1:
                //Town hall
                price = 0;
                loop.GetComponent<GameLoop>().incrementIncome(playerOwner, 150);

                //TODO: Needs a check on which player owns the building
                if(playerOwner.GetComponent<PlayerScript>())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        playerOwner.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(0);
                    }
                }

                

                //TODO: Check which owner to apply value to.
                loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().hasTownhall = true;

                break;
            case 2:
                //barracks
                price = 150;
                //Sets the value of the players "hasBarracks" boolean to true, allowing the player to recruit units.
                //TODO: Check which owner to apply value to.
                if(playerOwner.GetComponent<PlayerScript>())
                {
                    playerOwner.GetComponent<PlayerScript>().hasBarracks = true;
                }

                else if(playerOwner.GetComponent<AiScript>())
                {
                    //playerOwner.GetComponent<AiScript>().hasBarracks = true;
                }
                break;
            case 3:
                //Blacksmith
                price = 200;
                break;
            case 4:
                //Tavern
                //loop.GetComponent<GameLoop>().p
                price = 200;
                break;
            case 5:
                //NSA
                price = 200;
                break;
            case 6:
                //Market
                price = 200;
                break;
        }     
    }
	
	// Update is called once per frame
	void Update () {
        
        //Update logic for separate buildings
        switch(structureLevel)
        {
            case 0:
                //Empty slot
                break;
            case 1:
                //Town hall
                break;
            case 2:
                //barracks
                break;
            case 3:
                //Masonry
                break;
            case 4:
                //Tavern
                break;
            case 5:
                //NSA
                break;
            case 6:
                //Market
                break;
        }

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
		if(!hasUpgraded && !loop.GetComponent<GameLoop>().roundActive)
		{
			GameObject bFactory = (GameObject) Instantiate(buttonFactory);
			bFactory.GetComponent<ButtonFactory>().currentStructure = gameObject;
			bFactory.GetComponent<ButtonFactory>().spawnButtons(structureLevel, structureType, buttonPrefabs);
		} 
		
	}
}
