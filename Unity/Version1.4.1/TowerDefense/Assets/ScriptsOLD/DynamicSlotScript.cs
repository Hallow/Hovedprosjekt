using UnityEngine;
using System.Collections;

public class DynamicSlotScript : MonoBehaviour {

	//LIST MUST BE FORMATTED AS: TOP LEFT BUTTON, TOP CENTER, TOP RIGHT<<<IN INSPECTOR>>> MAX 3 BUTTONS, EXPANDABLE
	public GameObject[] buttonPrefabs;
	public GameObject[] buttons;

	public bool OpenMenu = false;
	public bool IsATower = false;

	Vector3 StartPos;
	Vector3 TopCenter;	
	Vector3 TopLeft;
	Vector3 TopRight;

	const float speed = 30.0f;
	float startTime;





	// Use this for initialization
	void Start () {
		StartPos = new Vector3(this.transform.position.x, this.transform.position.y, 3);

		TopCenter = new Vector3(this.transform.position.x, this.transform.position.y + 0.25f, this.transform.position.z - 0.2f);
		TopRight = new Vector3(this.transform.position.x + 1.1f, this.transform.position.y + 0.25f, this.transform.position.z - 0.2f);
		TopLeft = new Vector3(this.transform.position.x - 1.1f, this.transform.position.y + 0.25f, this.transform.position.z - 0.2f);

		buttons = new GameObject[buttonPrefabs.Length];
	
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("MenuHandler");
	}
	

	IEnumerator MenuHandler() {
		if (OpenMenu) {
			Open ();
			
			yield return new WaitForSeconds(0.6f);
			
			if (Input.GetMouseButton(0)) {
				OpenMenu = false;

				//bool nullCheck = true;

				deleteButtons();

				StopCoroutine("MenuHandler");
			}
		}
	}

	void OnMouseDown() {
		if (Input.GetMouseButtonDown(0)) {
			startTime = Time.time;
			
			if (!IsATower && !OpenMenu) {
				int pCount = 0;

				foreach(GameObject bPrefab in buttonPrefabs)
				{
					buttons[pCount] = (GameObject)Instantiate(bPrefab);
					buttons[pCount].GetComponent<ButtonScript>().buttonId = pCount;
					//buttons[pCount].GetComponent<ButtonScript>().parentSlot = gameObject;
					pCount++;
				}

				OpenMenu = true;
			}
		}
	}

	public void Open() {
		float distanceCovered = (Time.time - startTime) * speed;
		float journeyLength = Vector3.Distance(StartPos, TopRight);
		float fracJourney = distanceCovered / journeyLength;

		int buttonCounter = 0;

		foreach (GameObject b in buttons) 
		{
			b.transform.position = Vector3.Lerp (StartPos, TopCenter, fracJourney);

			if(buttonCounter == 0)
			{
				b.transform.position = Vector3.Lerp (TopCenter, TopLeft, fracJourney);
			}

			else if(buttonCounter == 2)
			{
				b.transform.position = Vector3.Lerp(TopCenter, TopRight, fracJourney);
			}

			buttonCounter++;

		}		
	}

	public void deleteButtons()
	{
		foreach (GameObject b in buttons) 
		{
			//Destroy (b.GetComponent<ButtonScript>().towerFactory);
			//b.GetComponent<ButtonScript>().destroyTowers();
			Destroy (b);
		}
	}
}
