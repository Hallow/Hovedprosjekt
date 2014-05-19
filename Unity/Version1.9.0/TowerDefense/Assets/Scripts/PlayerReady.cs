using UnityEngine;
using System.Collections;

public class PlayerReady : MonoBehaviour {

    //Ready is used to check whether the player has pressed the "End turn" button
    public bool ready;
    public bool pathHaseBeenSelected;
    public GameObject loop;

    public GameObject dataLoader;

	// Use this for initialization
	void Start () {

        pathHaseBeenSelected = false;

        ready = false;

        loop = GameObject.Find("GameLoop");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (Application.loadedLevel != 9 || Application.loadedLevel != 10)
        {
            pathHaseBeenSelected = true;
        }

        pathHaseBeenSelected = true;

        if (pathHaseBeenSelected)
        {
            //The player has clicked "End Turn", so he is ready.
            ready = true;

            switch (Application.loadedLevel)
            {
                case 9:
                    dataLoader.GetComponent<ProgressScript>().progressList[0] = true;
                    break;
                case 10:
                    dataLoader.GetComponent<ProgressScript>().progressList[1] = true;
                    break;
                case 11:
                    dataLoader.GetComponent<ProgressScript>().progressList[2] = true;
                    break;
                case 12:
                    dataLoader.GetComponent<ProgressScript>().progressList[3] = true;
                    break;
                case 13:
                    dataLoader.GetComponent<ProgressScript>().progressList[4] = true;
                    break;
                case 14:
                    dataLoader.GetComponent<ProgressScript>().progressList[5] = true;
                    break;
            }

            //dataLoader.GetComponent<ProgressScript>().progressList[Application.loadedLevel - 9] = true;
            Debug.Log("Loaded level = " + Application.loadedLevel);
            Debug.Log(Application.loadedLevel - 9);
            dataLoader.GetComponent<ProgressScript>().SaveData();
            loop.GetComponent<GameLoop>().turnNumber++;
        }

    }
}
