using UnityEngine;
using System.Collections;

// This script deals with interactions like back-button, menu button etc.

public class InteractionScript : MonoBehaviour {

    public GameObject unitButton;
    public GameObject towerButton;
    public GameObject buildingButton;

    public bool IsMenuOpened = false;

	// Use this for initialization
    void Start()
    {
        //unitButton = (GameObject)Instantiate(unitButton);
        //towerButton = (GameObject)Instantiate(towerButton);
        //buildingButton = (GameObject)Instantiate(buildingButton);
        //unitButton.renderer.enabled = false;
        //towerButton.renderer.enabled = false;
        //buildingButton.renderer.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator OnMouseDown()
    {
        yield return new WaitForSeconds(0.3f);

        if (!IsMenuOpened)
        {
            unitButton.renderer.enabled = true;
            towerButton.renderer.enabled = true;
            buildingButton.renderer.enabled = true;

            IsMenuOpened = true;
        }
        else
        {
            //Destroy(unitButton);
            //Destroy(towerButton);
            //Destroy(buildingButton);

            unitButton.renderer.enabled = false;
            towerButton.renderer.enabled = false;
            buildingButton.renderer.enabled = false;


            IsMenuOpened = false;
        }
    }
}
