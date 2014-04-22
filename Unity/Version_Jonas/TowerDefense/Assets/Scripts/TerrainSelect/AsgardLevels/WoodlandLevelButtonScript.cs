using UnityEngine;
using System.Collections;

public class WoodlandLevelButtonScript : MonoBehaviour {

    public int level;

    public Texture2D clickedTexture;

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
        Click();
        //Thread.Sleep(500);
        //Application.LoadLevel("game_scene");

        switch (level)
        {
            case 1:
                Application.LoadLevel("game_scene");
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
        }
    }

    public void Click()
    {
        //gameObject.renderer.material.mainTexture = clickedTexture;
    }
}
