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
		introStills = new Texture[5]; // change depending on number of stills
		for (int i = 0; i < 5; i++) { // change this as well based on number of stills
			//string loadTexture = ("IntroStill" + (i + 1)); // use this when stills from movie are ready
			string loadTexture = "BlackScreen"; // temporary until stills are ready, delete afterwards
			introStills[i] = Resources.Load (loadTexture) as Texture;
		}
		beginTime = Time.time;
		lastUpdate = Time.time;
		stillIndex = 0;
		//audioPlay(); start narration audio clip
	}
	
	void LateUpdate () {
		if ((Time.time - lastUpdate) >= 6.0f) { // change 6 to narration clip time divided by the number of stills
			stillIndex++;
			lastUpdate = Time.time;
		}
		if ((Time.time - beginTime) >= 0.0f) { // change 0 to total narration clip time
			Application.LoadLevel ("Level1");
		}
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), introStills[stillIndex]);
	}
}