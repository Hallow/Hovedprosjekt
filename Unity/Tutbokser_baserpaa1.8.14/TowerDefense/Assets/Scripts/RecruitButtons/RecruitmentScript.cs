using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecruitmentScript : MonoBehaviour {

    public List<int> recruitmentBacklog;
    public List<int> pathBacklog;
    public bool backlogIsEmpty;

    public GameObject loop;

	// Use this for initialization
	void Start () {
        recruitmentBacklog = new List<int>();
        pathBacklog = new List<int>();
	}
	
	// Update is called once per frame
	void Update () {

        if (recruitmentBacklog.Count <= 0)
        {
            backlogIsEmpty = true;
        }
        else
        {
            backlogIsEmpty = false;
            
            for (int i = 0; i < recruitmentBacklog.Count; i++)
            {
                if (recruitmentBacklog[i] == null)
                {
                    pathBacklog.Remove(i);
                }
            }
        }
	}
}
