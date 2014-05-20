using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;

public class RecruitButtonScript : MonoBehaviour {
    
    public bool OpenMenu = false;

    public GameObject viking1;
    public GameObject viking2;

    private GameObject viking_1;
    private GameObject viking_2;

    private bool ButtonsVisible = false;

    public GameObject recruitmentController;
    public GameObject recruitmentController2;
    public GameObject loop;

	// Use this for initialization
	void Start () {
        viking1 = (GameObject)Resources.Load("RecruitBasicUnit");
        viking2 = (GameObject)Resources.Load("RecruitHeavyUnit");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator OnMouseDown()
    {
        yield return new WaitForSeconds(0.1f);

        if (!ButtonsVisible)
        {
            transform.rotation = Quaternion.Euler(270, 0, 0);
            viking_1 = (GameObject)Instantiate(viking1);
            viking_1.GetComponent<RecruitBasicScript>().recruitmentController = recruitmentController;
            viking_1.GetComponent<RecruitBasicScript>().recruitmentController2 = recruitmentController2;
            viking_1.GetComponent<RecruitBasicScript>().loop = loop;

            if (loop.GetComponent<GameLoop>().mp)
            {
                if (ParseUser.CurrentUser["username"].ToString().Equals(loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().username))
                {
                    if (recruitmentController.GetComponent<RecruitmentScript>().loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().hasBarracks)
                    {
                        viking_2 = (GameObject)Instantiate(viking2);
                        viking_2.GetComponent<RecruitHeavyScript>().recruitmentController = recruitmentController;
                    }
                }
                else if (ParseUser.CurrentUser["username"].ToString().Equals(loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().username))
                {
                    if (recruitmentController2.GetComponent<RecruitmentScript>().loop.GetComponent<GameLoop>().player2.GetComponent<PlayerScript>().hasBarracks)
                    {
                        viking_2 = (GameObject)Instantiate(viking2);
                        viking_2.GetComponent<RecruitHeavyScript>().recruitmentController = recruitmentController2;
                    }
                }
            }
            else
            {
                if (recruitmentController.GetComponent<RecruitmentScript>().loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().hasBarracks)
                {
                    viking_2 = (GameObject)Instantiate(viking2);
                    viking_2.GetComponent<RecruitHeavyScript>().recruitmentController = recruitmentController;
                }
            }

            

            ButtonsVisible = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(90, 180, 0);
            Destroy(viking_1);
            Destroy(viking_2);

            ButtonsVisible = false;
        }
    }
}
