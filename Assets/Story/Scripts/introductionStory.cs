using UnityEngine;
using System.Collections;

public class introductionStory : MonoBehaviour {

	private int stillIndex;
	private float lastUpdate;
	private float beginTime;

	private Texture[] introStills;
	
	void Start () {
		Time.timeScale = 1;
		AudioListener.pause = false;
		string loadTexture = "";
		introStills = new Texture[5]; // change depending on number of stills
		for (int i = 0; i < 5; i++) { // change this as well based on number of stills
			//string loadTexture = ("IntroStill" + (i + 1)); // use this when stills from movie are ready
			loadTexture = "BlackScreen"; // temporary until stills are ready, delete afterwards
			introStills[i] = Resources.Load (loadTexture) as Texture;
		}
		beginTime = Time.time;
		lastUpdate = Time.time;
		stillIndex = 0;
		audio.Play();
	}
	
	void LateUpdate () {
		if ((Time.time - beginTime) >= 30.0f) {
			Application.LoadLevel ("Level1");
		}
		if (((Time.time - lastUpdate) >= 6.0f) && (stillIndex != 5)) { // change 6 to narration clip time divided by the number of stills
			stillIndex++;
			lastUpdate = Time.time;
		}
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), introStills[stillIndex]);
	}
}