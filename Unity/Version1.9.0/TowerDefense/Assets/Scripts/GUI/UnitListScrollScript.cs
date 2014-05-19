using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitListScrollScript : MonoBehaviour
{
    private static int RUNTIME_ENVIRONMENT;
    private static int ANDROID = 1;
    private static int EDITOR = 0;

    public Vector2 scrollPosition = Vector2.zero;
    public Texture2D viking_1;
    public Texture2D viking_2;

    private GameObject path1Button;
    private GameObject path2Button;
    private GameObject path3Button;

    private GameObject tempPath1Button;
    private GameObject tempPath2Button;
    private GameObject tempPath3Button;

    private bool pathChoicesShowing = false;

    public GameObject loop;

    public List<int> recruitmentBacklog;

    // Units = 0, Towers = 1, Buildings = 2
    public int objectsToShow;

    public float offset = 10.0f;

    public List<Texture2D> textureList = new List<Texture2D>();

    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        RUNTIME_ENVIRONMENT = 1;
#endif
#if UNITY_EDITOR
        RUNTIME_ENVIRONMENT = 0;
#endif

        recruitmentBacklog = new List<int>();

        path1Button = (GameObject)Resources.Load("LevelPaths/TestLevel/TestLevelPathChoose1");
        path2Button = (GameObject)Resources.Load("LevelPaths/TestLevel/TestLevelPathChoose2");
        path3Button = (GameObject)Resources.Load("LevelPaths/TestLevel/TestLevelPathChoose3");

        UpdateList();

        recruitmentBacklog = loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog;


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
        UpdateList();


        GUI.skin.label.fontSize = (int)(Screen.width * Screen.height) / 6000;

        GUI.backgroundColor = new Color(0, 0, 0, 0);
        GUI.Label(new Rect(10, 0, 100, 100), "" + loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().cash);
        GUI.Label(new Rect(100, 0, 100, 100), "" + loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().health + "/4");

        if (loop.GetComponent<GameLoop>().turnNumber > 0)
        GUI.Label(new Rect(150, 0, 140, 100), "Round " + loop.GetComponent<GameLoop>().turnNumber);

        if (RUNTIME_ENVIRONMENT == ANDROID)
            scrollPosition = GUI.BeginScrollView(new Rect(Screen.width - 800, Screen.height - 185, 500, 199), scrollPosition, new Rect(0, 0, 5000, 200));
        else if (RUNTIME_ENVIRONMENT == EDITOR)
            scrollPosition = GUI.BeginScrollView(new Rect(Screen.width - 180, Screen.height - 35, 150, 199), scrollPosition, new Rect(0, 0, 5000, 60));

        //scrollPosition = GUI.BeginScrollView(new Rect(50, 50, 50, 50), scrollPosition, new Rect(0, 0, 5000, 100));
        //scrollPosition = GUI.BeginScrollView(new Rect(100, 500, 200, 199), scrollPosition, new Rect(0, 0, 5000, 60));

        //for (int i = 0; i < list.Count; i++)
        //{
        //GUI.DrawTexture(new Rect(0 + (150 * i), 0, 150, 150), list[i]);
        //}

        //scrollPosition = GUI.BeginScrollView(new Rect(Screen.width / 2, Screen.height / 2, 200, 199), scrollPosition, new Rect(0, 0, 100, 80));
        if (textureList.Count != recruitmentBacklog.Count)
        {

            for (int i = 1; i < recruitmentBacklog.Count; i++)
            {

                //GUI.DrawTexture(new Rect((150 * i), 0, 150, 150), list[i]);

                if (RUNTIME_ENVIRONMENT == ANDROID)
                {
                    if (GUI.Button(new Rect((150 * i), 0, 150, 150), textureList[i - 1]))
                    {
                        /*
                        if (!pathChoicesShowing)
                        {
                            OpenPathChoices(i);
                            pathChoicesShowing = true;
                        }
                        else
                        {
                            ClosePathChoices();
                            pathChoicesShowing = false;
                        }
                         * */
                    }
                } else if (RUNTIME_ENVIRONMENT == EDITOR) {
                    if (GUI.Button(new Rect((40 * i), 0, 40, 40), textureList[i - 1]))
                    {
                        Debug.Log("Clicked unit " + i);
                        /*
                        if (!pathChoicesShowing)
                        {
                            OpenPathChoices(i);
                            tempPath1Button.GetComponent<SelectPath1Script>().unitIndex = i;
                            tempPath2Button.GetComponent<SelectPath2Script>().unitIndex = i;
                            tempPath3Button.GetComponent<SelectPath3Script>().unitIndex = i;
                            pathChoicesShowing = true;
                        }
                        else
                        {
                            ClosePathChoices();
                            pathChoicesShowing = false;
                        }
                         * */
                    }
                }
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

    private void OpenPathChoices(int index)
    {
        // TODO: Prefabs for each path should be presented for the user.
        // Maby do this as a coroutine.
        tempPath1Button = (GameObject)Instantiate(path1Button);
        tempPath2Button = (GameObject)Instantiate(path2Button);
        tempPath3Button = (GameObject)Instantiate(path3Button);

        tempPath1Button.transform.position = new Vector3(0.4102921f, -4.940019f, -0.5430961f);
        tempPath2Button.transform.position = new Vector3(tempPath1Button.transform.position.x - 1.1f, tempPath1Button.transform.position.y, tempPath1Button.transform.position.z);
        tempPath3Button.transform.position = new Vector3(tempPath1Button.transform.position.x + 1.1f, tempPath1Button.transform.position.y, tempPath1Button.transform.position.z);

        //loop.GetComponent<GameLoop>().player1.GetComponent<PlayerScript>().recruitmentController.GetComponent<RecruitmentScript>().recruitmentBacklog[0];
    }

    public void ClosePathChoices()
    {
        Destroy(tempPath1Button);
        Destroy(tempPath2Button);
        Destroy(tempPath3Button);
    }

    public void UpdateList()
    {
        for (int i = 0; i < recruitmentBacklog.Count; i++)
        {
            if (recruitmentBacklog[i] == 0)
            {
                textureList.Add(viking_1);
            }

            if (recruitmentBacklog[i] == 1)
            {
                //textureList.Add(viking_3);
            }

            if (recruitmentBacklog[i] == 2)
            {
                textureList.Add(viking_2);
            }
        }
    }
}
