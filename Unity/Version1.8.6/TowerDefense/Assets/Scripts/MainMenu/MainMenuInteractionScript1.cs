using UnityEngine;
using System.Collections;

public class MainMenuInteractionScript1 : MonoBehaviour {

    public bool QuitConfirmShowing;

    public GameObject confirmMenu;
    public GameObject buttonYes;
    public GameObject buttonNo;

    private GameObject tempConfirmMenu;
    private GameObject tempButtonYes;
    private GameObject tempButtonNo;

	// Use this for initialization
	void Start () {
        QuitConfirmShowing = false;

        confirmMenu = (GameObject)Resources.Load("QuitConfirmMenuPrefab");
        buttonYes = (GameObject)Resources.Load("ConfirmYesPrefab");
        buttonNo = (GameObject)Resources.Load("ConfirmNoPrefab");
	}
	
	// Update is called once per frame
	void Update () {

        if (QuitConfirmShowing)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Close();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Open();
            }
        }
	}


    public void Open()
    {
        tempConfirmMenu = (GameObject)Instantiate(confirmMenu);
        tempButtonYes = (GameObject)Instantiate(buttonYes);
        tempButtonNo = (GameObject)Instantiate(buttonNo);
        QuitConfirmShowing = true;
    }

    public void Close()
    {
        Destroy(tempConfirmMenu);
        Destroy(tempButtonYes);
        Destroy(tempButtonNo);
        QuitConfirmShowing = false;
    }

}
