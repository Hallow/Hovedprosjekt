using UnityEngine;
using System.Collections;

public class MuteButtonscript : MonoBehaviour {

    private GameObject mute;
    private GameObject tempMute;

    private bool isMuted;

	// Use this for initialization
	void Start () {
        mute = (GameObject)Resources.Load("sound_disabled");

        if (PlayerPrefs.GetInt("muted") == 0)
        {
            isMuted = false;
            UnMute();
        }
        else
        {
            isMuted = true;
            Mute();
        }

        isMuted = true;

        /*
        if (AudioListener.pause == true)
        {
            Mute();
        }
        else
        {
            UnMute();
        }
         * */
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isMuted)
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

        isMuted = true;

        PlayerPrefs.SetInt("mute", 1);
    }

    void UnMute()
    {
        Destroy(tempMute);
        AudioListener.pause = false;
        AudioListener.volume = 10;

        isMuted = false;

        PlayerPrefs.SetInt("mute", 0);
    }
}
