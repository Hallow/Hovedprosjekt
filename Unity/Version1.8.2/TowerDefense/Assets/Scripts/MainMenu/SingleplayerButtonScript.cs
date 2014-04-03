using UnityEngine;
using System.Collections;
using System.Threading;

public class SingleplayerButtonScript : MonoBehaviour {

    public Texture2D clickedTexture;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Click();
        //Thread.Sleep(500);
        Application.LoadLevel("game_scene");
    }

    public void Click()
    {
        gameObject.renderer.material.mainTexture = clickedTexture;
    }
}
