using UnityEngine;
using System.Collections;

public class endingStory : MonoBehaviour {

	private float beginTime;
	private Texture endStill;

	void Start () {
		Time.timeScale = 1;
		AudioListener.pause = false;
		endStill = Resources.Load ("BlackScreen") as Texture;; // change to end art still when ready.
		beginTime = Time.time;
		//audio.Play (); start narration audio clip
	}
	
	void LateUpdate () {
		if ((Time.time - beginTime) >= 0.0f) { // change 0 to narration clip time
			Application.LoadLevel("MainMenu");
		}
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), endStill);
	}
}