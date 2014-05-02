using UnityEngine;
using System.Collections;

public class SelectPath2Script : MonoBehaviour {

    public GameObject player;

    private static int path = 2;

    public int unitIndex { get; set; }

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Players/Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            player.GetComponent<PlayerScript>().unitList[unitIndex].GetComponent<UnitScript>().Path = path;
        }
    }
}
