using UnityEngine;
using System.Collections;

public class PathSelection : MonoBehaviour {

    public GameObject loop;
    public int path;

	// Use this for initialization
	void Start () {
        loop = GameObject.Find("GameLoop");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("Path selected: " + path);
        loop.GetComponent<GameLoop>().playerPath = path;
        Destroy(GameObject.Find("path_1"));
        Destroy(GameObject.Find("path_2"));
    }
}
