using UnityEngine;
using System.Collections;

public class PauseButtonScript : MonoBehaviour {

    private GameObject pauseMenu;
    private GameObject tempPauseMenu;

    private GameObject resumeButton;
    private GameObject tempResumeButton;
    private GameObject quitButton;
    private GameObject tempQuitButton;

    private bool PauseMenuIsShowing;

    //public GameLoop gameLoop;

	// Use this for initialization
	void Start () {
        PauseMenuIsShowing = false;
       // gameLoop = GetComponent<GameLoop>();
        pauseMenu = (GameObject) Resources.Load("PauseMenuPrefab");
        resumeButton = (GameObject) Resources.Load("PauseMenuResumePrefab");
        quitButton = (GameObject) Resources.Load("PauseMenuQuitPrefab");

	}
	
	// Update is called once per frame
	void Update () {
        if (PauseMenuIsShowing)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Close();
            }

            if (tempResumeButton.GetComponent<PauseMenuResumeScript>().resumeIsClicked)
            {
                Close();
            }
            else if (tempQuitButton.GetComponent<PauseMenuQuitScript>().quitIsClicked)
            {
                Application.LoadLevel("mainmenu");
            }
        }
	}

    private void Close()
    {
        transform.rotation = Quaternion.Euler(90, 180, 0);
        Destroy(tempPauseMenu);
        Destroy(tempResumeButton);
        Destroy(tempQuitButton);
        PauseMenuIsShowing = false;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (tempPauseMenu == false)
            {
                transform.rotation = Quaternion.Euler(-90, 360, 0);
                tempPauseMenu = (GameObject)Instantiate(pauseMenu);
                tempResumeButton = (GameObject)Instantiate(resumeButton);
                tempQuitButton = (GameObject)Instantiate(quitButton);
            }

            PauseMenuIsShowing = true;
        }
    }
}
