using UnityEngine;
using System.Collections;

public class SnowButtonScript : MonoBehaviour {

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
        Application.LoadLevel("snowland_scene");
    }

    public void Click()
    {
        gameObject.renderer.material.mainTexture = clickedTexture;
    }
}
