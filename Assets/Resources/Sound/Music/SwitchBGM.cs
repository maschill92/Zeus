﻿using UnityEngine;
using System.Collections;

public class SwitchBGM : MonoBehaviour {
	
	public AudioClip outsideClip;
	public AudioClip insideClip;
	private bool isColliding;
	private bool inside;
	public float fadeSpeed;
	private bool done;
	// Use this for initialization
	void Start () {
		isColliding = false;
	}

	void OnTriggerEnter(Collider c) {

		if (c.tag == "Player") {
			isColliding = true;
			inside = true;
			done = false;
		}
	}

	void OnTriggerExit(Collider c) {
		if (c.tag == "Player") {
			isColliding = true;
			inside = false;
			done = false;
		}
	}
	// Update is called once per frame
	void Update () {
		if (isColliding && audio.volume > .1) {
			audio.volume -= fadeSpeed * Time.deltaTime;
		}
		if (audio.volume < .1 && !done) {
			done = true;
			isColliding = false;
			audio.clip = inside ? insideClip : outsideClip;
			audio.Play();
			audio.loop  = true;
		}

		if (audio.volume <= .6 && !isColliding) {
			audio.volume += fadeSpeed * Time.deltaTime;
		}
	}
}
