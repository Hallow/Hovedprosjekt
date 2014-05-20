using UnityEngine;
using System.Collections;

public class WinloseQuitButtonScript : MonoBehaviour {

    public bool quitIsClicked;
    public GameObject loop;

    // Use this for initialization
    void Start()
    {
        loop = GameObject.Find("GameLoop");
        quitIsClicked = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;

            if (loop.GetComponent<GameLoop>().mp)
            {
                Application.LoadLevel(4);
            }
            else
            {
                Application.LoadLevel(0);
            }
            quitIsClicked = true;
        }
    }
}
