using UnityEngine;
using System.Collections;

public class MultiplayerButtonScript : MonoBehaviour {

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
        Application.LoadLevel("nogo_scene");
    }

    public void Click()
    {
        gameObject.renderer.material.mainTexture = clickedTexture;
    }
}
