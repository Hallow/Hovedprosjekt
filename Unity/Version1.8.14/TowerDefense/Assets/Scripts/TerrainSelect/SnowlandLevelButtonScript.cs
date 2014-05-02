using UnityEngine;
using System.Collections;

public class SnowlandLevelButtonScript : MonoBehaviour {

    public int level;

    //public Texture2D clickedTexture;

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
        switch (level)
        {
            case 1:
                Application.LoadLevel("snow1");
                break;
            case 2:
                Application.LoadLevel("snow2");
                break;
            case 3:
                Application.LoadLevel("snow3");
                break;
            case 4:
                Application.LoadLevel("snow4");
                break;
            case 5:
                Application.LoadLevel("snow5");
                break;
        }
    }
}
