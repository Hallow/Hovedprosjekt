/*using UnityEngine;
using System.Collections;
using System.Collections;
using System.Threading;

public class SlotMenu : MonoBehaviour {

	public bool IsATower = false;
	private bool OpenMenu = false;

	private Vector3 StartPos1;
	private Vector3 StartPos2;
	private Vector3 EndPos1;

	Vector3 Button1End;
	Vector3 Button3End;

	const float speed = 30.0f;
	
	public GameObject BasicTowerButton;
	public GameObject _BasicTowerButton;
	public GameObject AOETowerButton;
	public GameObject _AOETowerButton;
	public GameObject SlowingTowerButton;
	public GameObject _SlowingTowerButton;

	float startTime;
	
	// Use this for initialization
	void Start () {
		StartPos1 = new Vector3(this.transform.position.x, this.transform.position.y, 3);
		EndPos1 = new Vector3(this.transform.position.x, this.transform.position.y + 0.25f, this.transform.position.z - 0.2f);
		Button1End = new Vector3(this.transform.position.x + 1.1f, this.transform.position.y + 0.25f, this.transform.position.z - 0.2f);
		Button3End = new Vector3(this.transform.position.x - 1.1f, this.transform.position.y + 0.25f, this.transform.position.z - 0.2f);
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

				if (BasicTowerButton != null && AOETowerButton != null && SlowingTowerButton != null) {
					Destroy(_BasicTowerButton);
					Destroy(_AOETowerButton);
					Destroy(_SlowingTowerButton);
					StopCoroutine("MenuHandler");
				}

			}
		}
	}

	void OnMouseDown() {
		if (Input.GetMouseButtonDown(0)) {
			startTime = Time.time;
			print ("MouseClick");

			if (!IsATower && !OpenMenu) {
				this._BasicTowerButton = BasicTowerButton;
				this._BasicTowerButton = (GameObject)Instantiate (BasicTowerButton);
				_BasicTowerButton.GetComponent<ButtonScript>().parentSlot = gameObject;
				this._AOETowerButton = AOETowerButton;
				this._AOETowerButton = (GameObject)Instantiate (AOETowerButton);
				_AOETowerButton.GetComponent<ButtonScript>().parentSlot = gameObject;
				this._SlowingTowerButton = SlowingTowerButton;
				this._SlowingTowerButton = (GameObject)Instantiate (SlowingTowerButton);
				_SlowingTowerButton.GetComponent<ButtonScript>().parentSlot = gameObject;
				
				OpenMenu = true;
			}
		}
	}

	public void Open() {
		float distanceCovered = (Time.time - startTime) * speed;
		float journeyLength = Vector3.Distance(StartPos1, Button3End);
		float fracJourney = distanceCovered / journeyLength;
		
		_BasicTowerButton.transform.position = Vector3.Lerp(StartPos1, EndPos1, fracJourney);
		_AOETowerButton.transform.position = Vector3.Lerp(StartPos1, EndPos1, fracJourney);
		_SlowingTowerButton.transform.position = Vector3.Lerp(StartPos1, EndPos1, fracJourney);

		_BasicTowerButton.transform.position = Vector3.Lerp (EndPos1, Button1End, fracJourney);
		_SlowingTowerButton.transform.position = Vector3.Lerp (EndPos1, Button3End, fracJourney);
	
	}
}
*/