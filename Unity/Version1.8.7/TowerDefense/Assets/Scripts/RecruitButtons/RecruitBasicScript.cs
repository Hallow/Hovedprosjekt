using UnityEngine;
using System.Collections;

public class RecruitBasicScript : MonoBehaviour {

    public int index;
    public GameObject recruitmentController;

	// Use this for initialization
	void Start () {

        index = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("MOUSE DOWN!");
        //index++;
        recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(0);
    }
}
