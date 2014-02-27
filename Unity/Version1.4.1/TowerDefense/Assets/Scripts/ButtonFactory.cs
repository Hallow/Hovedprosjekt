using UnityEngine;
using System.Collections;

public class ButtonFactory : MonoBehaviour {
	
	public GameObject[] buttons;
	
	public bool OpenMenu = false;
	public bool IsATower = false;
	
	Vector3 StartPos;

	Vector3 TopCenter;	
	Vector3 TopLeft;
	Vector3 TopRight;

	Vector3 BottomCenter;
	Vector3 BottomLeft;
	Vector3 BottomRight;

	Vector3 CenterCenter;

	public GameObject backgroundPrefab;
	GameObject background;
	
	const float speed = 30.0f;
	const float backgroundSpeed = 50.0f;
	float startTime;

	public int currentStructureLevel;
	public int currentStructureType;
	public GameObject currentStructure;

	// Use this for initialization
	void Start () {
		background = (GameObject)Instantiate (backgroundPrefab);
		StartPos = new Vector3(currentStructure.transform.position.x, currentStructure.transform.position.y, 3);

		CenterCenter = new Vector3 (currentStructure.transform.position.x, currentStructure.transform.position.y, currentStructure.transform.position.z - 1f);

		TopCenter = new Vector3(currentStructure.transform.position.x, currentStructure.transform.position.y + 1.3f, currentStructure.transform.position.z - 1.1f);
		TopRight = new Vector3(currentStructure.transform.position.x + 3.1f, currentStructure.transform.position.y + 1.3f, currentStructure.transform.position.z - 1.1f);
		TopLeft = new Vector3(currentStructure.transform.position.x - 3.1f, currentStructure.transform.position.y + 1.3f, currentStructure.transform.position.z - 1.1f);
		BottomCenter = new Vector3 (currentStructure.transform.position.x, currentStructure.transform.position.y - 1.3f, currentStructure.transform.position.z - 1.1f);
		BottomRight = new Vector3 (currentStructure.transform.position.x + 3.1f, currentStructure.transform.position.y - 1.3f, currentStructure.transform.position.z - 1.1f);
		BottomLeft = new Vector3(currentStructure.transform.position.x -3.1f, currentStructure.transform.position.y - 1.3f, currentStructure.transform.position.z -1.1f);
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
				
				deleteButtons();
				
				StopCoroutine("MenuHandler");
				Destroy(gameObject);
			}
		}
	}

	public void spawnButtons(int cLevel, int cType, GameObject[] cPrefabs)
	{
		if (Input.GetMouseButtonDown(0)) {
			startTime = Time.time;
			
			if (!OpenMenu) {
				buttons = new GameObject[cPrefabs.Length];
				int pCount = 0;
				
				foreach(GameObject bPrefab in cPrefabs)
				{
					buttons[pCount] = (GameObject)Instantiate(bPrefab);

					buttons[pCount].GetComponent<ButtonScript>().setup(pCount, currentStructure, cType, cLevel, gameObject);
					//Debug.Log ("Buttons have been setup");

					pCount++;
				}
				
				OpenMenu = true;
			}
		}
	}
	
	public void Open() {
		float distanceCovered = (Time.time - startTime) * speed;

		float journeyLength;
		float fracJourney;

		float bDistanceCovered = (Time.time - startTime) * backgroundSpeed;
		journeyLength = Vector3.Distance(StartPos, CenterCenter);
		fracJourney = bDistanceCovered / journeyLength;
		
		background.transform.position = Vector3.Lerp(StartPos, CenterCenter, fracJourney);

		
		int buttonCounter = 0;
		
		foreach (GameObject b in buttons) 
		{
			switch(buttonCounter)
			{
				case 0:
					journeyLength = Vector3.Distance(StartPos, TopLeft);
					fracJourney = distanceCovered / journeyLength;

					b.transform.position = Vector3.Lerp (StartPos, TopCenter, fracJourney);
					b.transform.position = Vector3.Lerp (TopCenter, TopLeft, fracJourney);
					break;

				case 1:
					journeyLength = Vector3.Distance(StartPos, TopCenter);
					fracJourney = distanceCovered / journeyLength;

					b.transform.position = Vector3.Lerp (StartPos, TopCenter, fracJourney);
					break;

				case 2:
					journeyLength = Vector3.Distance(StartPos, TopRight);
					fracJourney = distanceCovered / journeyLength;

					b.transform.position = Vector3.Lerp (StartPos, TopCenter, fracJourney);
					b.transform.position = Vector3.Lerp(TopCenter, TopRight, fracJourney);
					break;

				case 3:
					journeyLength = Vector3.Distance(StartPos, BottomLeft);
					fracJourney = distanceCovered / journeyLength;

					b.transform.position = Vector3.Lerp(TopCenter, BottomCenter, fracJourney);
					b.transform.position = Vector3.Lerp(TopCenter, BottomLeft, fracJourney);
					break;

				case 4:
					journeyLength = Vector3.Distance(StartPos, BottomCenter);
					fracJourney = distanceCovered / journeyLength;

					b.transform.position = Vector3.Lerp(TopCenter, BottomCenter, fracJourney);
					break;

				case 5:
					journeyLength = Vector3.Distance(StartPos, BottomRight);
					fracJourney = distanceCovered / journeyLength;

					b.transform.position = Vector3.Lerp(TopCenter, BottomCenter, fracJourney);
					b.transform.position = Vector3.Lerp(TopCenter, BottomRight, fracJourney);
					break;					
			}


			
			buttonCounter++;
			
		}		
	}
	
	public void deleteButtons()
	{
		OpenMenu = false;
		foreach (GameObject b in buttons) 
		{
			if(b)
			{
				b.GetComponent<ButtonScript>().destroyTowerFactory();
				Destroy (b);
			}

		}
		Destroy (background);
	}
}
