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
        //index++;

        if (Input.GetMouseButton(0))
            recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(0);

        Camera.main.GetComponent<UnitListScrollScript>().UpdateList();

        Debug.Log("Adding basic viking___!!");
    }
}
