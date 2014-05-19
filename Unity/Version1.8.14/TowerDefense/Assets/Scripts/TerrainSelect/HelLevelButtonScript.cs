using UnityEngine;
using System.Collections;

public class HelLevelButtonScript : MonoBehaviour {

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
                Application.LoadLevel("hel1");
                break;
            case 2:
                Application.LoadLevel("hel2");
                break;
            case 3:
                Application.LoadLevel("hel3");
                break;
            case 4:
                Application.LoadLevel("hel4");
                break;
            case 5:
                Application.LoadLevel("hel5");
                break;
        }
    }
}
