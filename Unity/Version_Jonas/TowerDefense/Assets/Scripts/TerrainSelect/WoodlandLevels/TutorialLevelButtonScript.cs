using UnityEngine;
using System.Collections;

public class TutorialLevelButtonScript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //Thread.Sleep(500);
        Application.LoadLevel("tutorial_inwork");
    }
}
