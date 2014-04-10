using UnityEngine;
using System.Collections;

public class ArrowDownButtonScript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Camera switch2");
            switchCamera();
        }
    }

    void switchCamera()
    {
        var speed = 0.1f;

        Vector3 pos = new Vector3(0, 1.011715f, -10f);

        float progress = 0.0f;  //This value is used for LERP

        while (progress < 1.0f)
        {
            Camera.main.transform.position = Vector3.Lerp(pos, new Vector3(0, -19.7f, -10f), speed * Time.deltaTime);

            progress += speed;
        }

        //Set final transform
        Camera.main.transform.position = new Vector3(0, -19.7f, -10f);
    }
}
