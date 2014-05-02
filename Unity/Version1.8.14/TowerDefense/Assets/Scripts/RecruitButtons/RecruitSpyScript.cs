using UnityEngine;
using System.Collections;

public class RecruitSpyScript : MonoBehaviour {

    public int index;

	// Use this for initialization
	void Start () {

        index = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        index++;
    }
}
