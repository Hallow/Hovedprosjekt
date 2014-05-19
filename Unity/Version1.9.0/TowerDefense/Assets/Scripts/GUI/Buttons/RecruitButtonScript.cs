using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecruitButtonScript : MonoBehaviour {
    
    public bool OpenMenu = false;

    public GameObject viking1;
    public GameObject viking2;

    private GameObject viking_1;
    private GameObject viking_2;

    private bool ButtonsVisible = false;

    public GameObject recruitmentController;

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

            if (recruitmentController.GetComponent<RecruitmentScript>().loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().hasBarracks)
            {
                viking_2 = (GameObject)Instantiate(viking2);
                viking_2.GetComponent<RecruitHeavyScript>().recruitmentController = recruitmentController;
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
