using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitListScript : MonoBehaviour {

    private float hScrollBarValue;

    public Vector2 scrollPosition = Vector2.zero;

    public Texture2D viking_1;
    public Texture2D viking_2;

    public List<Texture2D> list;

    void OnGUI()
    {
        //list.Add(viking_1);
        //list.Add(viking_2);

        //hScrollBarValue = GUI.HorizontalScrollbar(new Rect(100, 500, 100, 30), hScrollBarValue, 1.0f, 0.0f, 10.0f);

        scrollPosition = GUI.BeginScrollView(new Rect(Screen.width / 2, Screen.height - 60, Screen.width / 1, Screen.height / 3), scrollPosition, new Rect(0,0, Screen.width / 1, Screen.height / 3), false, false);

        //GUILayout.ExpandWidth(true);


        GUI.DrawTexture(new Rect(0, 0, 70, 70), viking_1);

        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // dragging
            scrollPosition.x += Input.GetTouch(0).deltaPosition.x;
            //GUILayout.ExpandWidth(true);
        }

        GUI.EndScrollView();

        //GUI.DrawTexture(new Rect(0,0, 70, 70), viking_1);
        /*
        for (int i = 0; i < list.Count; i++)
        {
            int pos = 70;
            GUI.DrawTexture(new Rect(0, 0, pos, 70), list[i]);
            pos *= pos;
        }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // dragging
                scrollPosition.x += Input.GetTouch(0).deltaPosition.x;
                GUILayout.ExpandWidth(true);
            }

        GUI.EndScrollView();
         * */
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
