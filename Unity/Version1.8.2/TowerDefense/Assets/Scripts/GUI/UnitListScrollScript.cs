using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitListScrollScript : MonoBehaviour
{

    public Vector2 scrollPosition = Vector2.zero;
    public Texture2D viking_1;
    public Texture2D viking_2;

    public GameObject loop;

    public List<int> recruitmentBacklog;

    // Units = 0, Towers = 1, Buildings = 2
    public int objectsToShow;

    public float offset = 10.0f;

    public List<Texture2D> list = new List<Texture2D>();

    // Use this for initialization
    void Start()
    {
        UpdateList();

        /*
        list.Add(viking_1);
        list.Add(viking_1);
        list.Add(viking_1);
        list.Add(viking_2);
        list.Add(viking_2);
        list.Add(viking_2);
        list.Add(viking_2);
        list.Add(viking_2);
        list.Add(viking_2);
        list.Add(viking_2);
        list.Add(viking_2);
         * */
    }

    void OnGUI()
    {

        GUI.Box(new Rect(Screen.width / 2 - 130, Screen.height / 2, 300, 100), "" + SystemInfo.deviceUniqueIdentifier);

        GUI.backgroundColor = new Color(0, 0, 0, 0);
        GUI.skin.label.fontSize = 30;
        GUI.Box(new Rect(10, 0, 80, 20), "" + loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().cash);
        // Works on Android (Samsung Galaxy S4).
        scrollPosition = GUI.BeginScrollView(new Rect(Screen.width - 800, Screen.height - 185, 500, 199), scrollPosition, new Rect(0, 0, 5000, 160));

        //for (int i = 0; i < list.Count; i++)
        //{
        //GUI.DrawTexture(new Rect(0 + (150 * i), 0, 150, 150), list[i]);
        //}

        //scrollPosition = GUI.BeginScrollView(new Rect(Screen.width / 2, Screen.height / 2, 200, 199), scrollPosition, new Rect(0, 0, 100, 80));
        if (list.Count != loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog.Count)
        {
            UpdateList();

            for (int i = 0; i < recruitmentBacklog.Count; i++)
            {

                GUI.DrawTexture(new Rect((80 * i), 0, 80, 80), list[i]);
            }
        }

        //GUI.DrawTexture(new Rect(0, 0, 60, 60), list[0]);




        GUI.EndScrollView();
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //if (scrollPosition.x > Vector2.zero.x)
                scrollPosition.x -= Input.GetTouch(0).deltaPosition.x;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateList()
    {
        recruitmentBacklog = loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog;

        for (int i = 0; i < recruitmentBacklog.Count; i++)
        {
            if (recruitmentBacklog[i] == 0)
            {
                list.Add(viking_1);
            }
            else if (recruitmentBacklog[i] == 1)
            {
                list.Add(viking_2);
            }
        }
    }
}
