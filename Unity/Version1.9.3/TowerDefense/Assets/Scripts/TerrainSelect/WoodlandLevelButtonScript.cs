using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WoodlandLevelButtonScript : MonoBehaviour
{

    public int level;

    public bool isClickable;
    
    //public Texture2D clickedTexture;

    // Use this for initialization
    void Start()
    {
        isClickable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //Application.LoadLevel("stage3_inwork");
        isClickable = true;

        Debug.Log("Level " + level + " was clicked.");
        if (isClickable)
        {
            switch (level)
            {
                case 1:
                    Application.LoadLevel("game_scene");
                    break;
                case 2:
                    Application.LoadLevel("stage1_inwork");
                    break;
                case 3:
                    Application.LoadLevel("stage2_inwork");
                    break;
                case 4:
                    Application.LoadLevel("stage3_inwork");
                    break;
                case 5:
                    Application.LoadLevel("stage4_inwork");
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
            }

            Click();
        }
    }

    public void Click()
    {
        //gameObject.renderer.material.mainTexture = clickedTexture;
    }
}
