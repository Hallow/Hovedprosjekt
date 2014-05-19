using UnityEngine;
using System.Collections;

public class WinloseQuitButtonScript : MonoBehaviour {

    public bool quitIsClicked;

    // Use this for initialization
    void Start()
    {
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
            Application.LoadLevel(0);
            quitIsClicked = true;
        }
    }
}
