using UnityEngine;
using System.Collections;
using System.Threading;

// Made from reference: http://www.youtube.com/watch?v=kSVjRgjZTVc

public class AnimationScript : MonoBehaviour {

	public float FPS;
	public float secondsToWait;
	public bool loop;
	public Texture[] frames;

	private int currentFrame;

	// Use this for initialization
	void Start () {
		FPS = 25.0f;
		currentFrame = 0;
		secondsToWait = 1 / FPS;
		StartCoroutine (Animate ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator Animate() {

		bool stop = false;

		if (currentFrame >= frames.Length) {
			if (loop == false) {
				stop = true;
			} else {
				currentFrame = 0;
			}
		}

		yield return new WaitForSeconds(secondsToWait);
		renderer.material.mainTexture = frames [currentFrame];
		currentFrame++;

		if (stop == false)
			StartCoroutine(Animate ());
	}
}
