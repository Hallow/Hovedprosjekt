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
        //Checks if player1 has constructed the barracks, via the Recruitment Controller, then the GameLoop
        if(recruitmentController.GetComponent<RecruitmentScript>().loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().hasBarracks)
        {
            recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(2);
        }
        //index++;
        
    }
}
