using UnityEngine;
using System.Collections;

public class TerrainInteractionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Application.loadedLevelName == "woodland_scene" || Application.loadedLevelName == "snowland_scene" || Application.loadedLevelName == "hel_scene" || Application.loadedLevelName == "asgard_scene")
                    Application.LoadLevel("terrain_select");
                else
                    Application.LoadLevel("mainmenu");
            }
	}
}
