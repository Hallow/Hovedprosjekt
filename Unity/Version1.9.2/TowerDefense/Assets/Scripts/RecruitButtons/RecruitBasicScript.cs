using UnityEngine;
using System.Collections;
using Parse;

public class RecruitBasicScript : MonoBehaviour {

    public int index;
    public GameObject recruitmentController;

    //MP stuff
    public GameObject loop;
    public GameObject recruitmentController2;
    public bool mp;

	// Use this for initialization
	void Start () {

        index = 0;

        mp = loop.GetComponent<GameLoop>().mp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        //index++;

        if (mp)
        {
            if (ParseUser.CurrentUser["username"].ToString().Equals(loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().username))
            {
                Debug.Log("111111111");
                recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(0);
            }
            else if (ParseUser.CurrentUser["username"].ToString().Equals(loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().username))
            {
                Debug.Log("22222222222");
                recruitmentController2.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(0);
            }
        }
        else
        {
            recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Add(0);

            Camera.main.GetComponent<UnitListScrollScript>().recruitmentBacklog.Add(0);
        }

        Debug.Log("Adding basic viking___!!");
    }
}
