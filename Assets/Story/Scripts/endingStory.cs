﻿using UnityEngine;
using System.Collections;

public class endingStory : MonoBehaviour {

	private float beginTime;
	private Texture endStill;

	void Start () {
		Time.timeScale = 1;
		AudioListener.pause = false;
		endStill = Resources.Load ("EndingStill") as Texture;;
		beginTime = Time.time;
		audio.Play ();
	}
	
	void LateUpdate () {
		if ((Time.time - beginTime) >= 12.0f) {
			Application.LoadLevel("ScoreBoard2");
		}
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), endStill);
	}
}