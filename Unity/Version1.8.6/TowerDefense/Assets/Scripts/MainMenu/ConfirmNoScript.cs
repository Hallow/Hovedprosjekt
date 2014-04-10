using UnityEngine;
using System.Collections;

public class ConfirmNoScript : MonoBehaviour {

    public GameObject interaction;

	// Use this for initialization
	void Start () {
        interaction = (GameObject)Resources.Load("QuitConfirmMenuPrefab");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Camera.main.GetComponent<MainMenuInteractionScript1>().Close();
        }
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera.main.GetComponent<MainMenuInteractionScript1>().Close();
        }
    }
}
