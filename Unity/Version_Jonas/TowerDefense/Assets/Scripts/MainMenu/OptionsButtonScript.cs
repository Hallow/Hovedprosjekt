using UnityEngine;
using System.Collections;

public class OptionsButtonScript : MonoBehaviour {

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
        Application.LoadLevel("options_scene");
    }

    public void Click()
    {
        gameObject.renderer.material.mainTexture = clickedTexture;
    }
}
