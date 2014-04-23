using UnityEngine;
using System.Collections;

public class RecruitHeavyScript : MonoBehaviour {

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
        //index++;
        if (Input.GetMouseButton(0))
            recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(2);

        Debug.Log("adding heavy viking....!");
    }
}
