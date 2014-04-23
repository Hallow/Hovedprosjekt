using UnityEngine;
using System.Collections;

public class WoodlandLevelButtonScript : MonoBehaviour {

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
        Click();
        //Thread.Sleep(500);
        //Application.LoadLevel("game_scene");

        switch (level)
        {
            case 1:
                Application.LoadLevel("tutorial_inwork");
                break;
            case 2:
                Application.LoadLevel("game_scene");
                break;
            case 3:
                Application.LoadLevel("stage1_inwork");
                break;
            case 4:
                Application.LoadLevel("stage3_inwork");
                break;
            case 5:
                Application.LoadLevel("stage2_inwork");
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
