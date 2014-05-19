using UnityEngine;
using System.Collections;


public class tutbokser : MonoBehaviour {


	float caseCounter = 0;

	GameObject turnoff;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log("TREFF");
	

		caseCounter += 1;

		if(caseCounter == 1)
		{
			renderer.material.mainTexture = Resources.Load("Tutorial/tekst2") as Texture;
		}

		if(caseCounter == 2)
		{
			renderer.material.mainTexture = Resources.Load("Tutorial/tekst3") as Texture;
		}

		if(caseCounter == 3)
		{
			renderer.material.mainTexture = Resources.Load("Tutorial/tekst4") as Texture;
		}

		if(caseCounter == 4)
		{
			renderer.enabled = false;
		}



	}
}
