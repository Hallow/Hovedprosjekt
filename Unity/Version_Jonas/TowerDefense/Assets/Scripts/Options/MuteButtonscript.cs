using UnityEngine;
using System.Collections;

public class MuteButtonscript : MonoBehaviour {

    private GameObject mute;
    private GameObject tempMute;

	// Use this for initialization
	void Start () {
        mute = (GameObject)Resources.Load("sound_disabled");

        if (AudioListener.pause == true)
        {
            Mute();
        }
        else
        {
            UnMute();
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (AudioListener.pause == true)
            {
                UnMute();
            }
            else
            {
                Mute();
            }
        }
    }

    void Mute()
    {
        tempMute = (GameObject)Instantiate(mute);
        AudioListener.pause = true;
        AudioListener.volume = 0;
    }

    void UnMute()
    {
        Destroy(tempMute);
        AudioListener.pause = false;
        AudioListener.volume = 10;
    }
}
