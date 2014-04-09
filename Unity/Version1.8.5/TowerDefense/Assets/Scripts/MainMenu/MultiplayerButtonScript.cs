using UnityEngine;
using System.Collections;
using Prime31;

public class MultiplayerButtonScript : MonoBehaviour {

    public Texture2D clickedTexture;

    public bool serverSession;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	
	}

    void OnMouseDown()
    {
        Click();

        FacebookCombo.init();



        FacebookLogIn();
    }

    public void Click()
    {
        gameObject.renderer.material.mainTexture = clickedTexture; // Changes the render so that the button looks like it is being clicked.
    }

    void FacebookLogIn()
    {
        //Facebook.instance.checkSessionValidityOnServer(isValid => { serverSession = isValid; });

        if (FacebookCombo.isSessionValid())
        {
            Debug.Log("session is valid!!!!!!");
            Application.LoadLevel("multiplayer_scene");
        }
        else
        {
            Debug.Log("session is not valid!!!!!!!!!!!!!!");
            var permissions = new string[] { "email" };
            FacebookCombo.loginWithReadPermissions(permissions);



            /*
            if (FacebookCombo.isSessionValid())
            {
                Debug.Log("LOGGED IN SUCCESSFULLY!!!!!!!!!!!!!!!");
                Application.LoadLevel("multiplayer_scene");
            }
            */


        }

    }
}
