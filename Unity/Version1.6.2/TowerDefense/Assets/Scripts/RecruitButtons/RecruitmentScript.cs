using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecruitmentScript : MonoBehaviour {

    public List<int> recruitmentBacklog;
    public bool backlogIsEmpty;

	// Use this for initialization
	void Start () {
        recruitmentBacklog = new List<int>();
	}
	
	// Update is called once per frame
	void Update () {
        if(recruitmentBacklog.Count <= 0)
        {
            backlogIsEmpty = true;
        }
        else
        {
            backlogIsEmpty = false;
        }
	
	}
}
