using UnityEngine;
using System.Collections;

public class transitionStory : MonoBehaviour {

	private float beginTime;
	private Texture transitionStill;
	
	void Start () {
		Time.timeScale = 1;
		AudioListener.pause = false;
		transitionStill = Resources.Load ("BlackScreen") as Texture; // change to transition art still when ready.
		beginTime = Time.time;
		//audio.Play (); start narration audio clip
	}
	
	void LateUpdate () {
		if ((Time.time - beginTime) >= 0.0f) { // change 0 to narration clip time
			Application.LoadLevel("Level2");
		}
	}
	
	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), transitionStill);
	}
}