﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;

public class RecruitmentScript : MonoBehaviour {

    public List<int> recruitmentBacklog;
    public bool backlogIsEmpty;

    public GameObject loop;

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
