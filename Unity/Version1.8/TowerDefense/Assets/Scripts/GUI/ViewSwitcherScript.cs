using UnityEngine;
using System.Collections;
using System.Threading;

public class ViewSwitcherScript : MonoBehaviour {

    Vector3 mainCamOriginal;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Camera switch");
            switchCamera();
        }
    }

    void switchCamera()
    {
        var speed = 0.1f;

        Vector3 pos = Camera.main.transform.position;

        float progress = 0.0f;  //This value is used for LERP
        if (Camera.main.transform.position.y == 1.011715)
        {
            while (progress < 1.0f)
            {
                Camera.main.transform.position = Vector3.Lerp(pos, GameObject.Find("townview").camera.transform.position, progress);

                progress += speed;
            }
        }
        else if (Camera.main.transform.position.y == -19.66304)
        {
            while (progress < 1.0f)
            {
                Camera.main.transform.position = Vector3.Lerp(pos, mainCamOriginal, progress);

                progress += speed;
            }
        }

        //Set final transform
        Camera.main.transform.position = Camera.main.transform.position;
    }
}
