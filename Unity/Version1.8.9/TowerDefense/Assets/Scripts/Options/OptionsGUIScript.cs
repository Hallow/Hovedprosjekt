using UnityEngine;
using System.Collections;

public class OptionsGUIScript : MonoBehaviour {

    public GUISkin skin;

    public float hSliderValue = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.skin = skin;

    #if UNITY_ANDROID
            hSliderValue = GUI.HorizontalSlider(new Rect((Screen.width / 2) - 360, (Screen.height / 2) - 650, 450, 90), hSliderValue, 0.0f, 10.0f);
    #endif

    #if UNITY_EDITOR
            hSliderValue = GUI.HorizontalSlider(new Rect((Screen.width / 2), (Screen.height / 2), 450, 90), hSliderValue, 0.0f, 10.0f);
    #endif

            AudioListener.volume = hSliderValue / 10;

    }
}
