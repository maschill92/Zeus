﻿using UnityEngine;
using System.Collections;

public class guiPrompt : MonoBehaviour {

	private int promptSecond;
	private float lastUpdate;

	private Texture eImage;
	private Texture spaceImage;
	private Texture shiftImage;

	public enum Page {
		None, Interact, Jump, Sprint
	}
	
	private Page currentPage;

	void Start () {
		promptSecond = 0;
		lastUpdate = Time.time;
		eImage = Resources.Load ("EKey") as Texture;
		spaceImage = Resources.Load ("SpaceKey") as Texture;
		shiftImage = Resources.Load ("ShiftKey") as Texture;
		currentPage = Page.None;
	}

	void LateUpdate() {
		if (currentPage != Page.None) {
			if ((Time.time - lastUpdate) > 1.0f) { // update every second
				promptSecond++;
				lastUpdate = Time.time;
			}
			if (promptSecond >= 5) {
				promptSecond = 0;
				currentPage = Page.None;
			}
		}
		if (Input.GetKeyDown ("p")) {
			ActivateInteractPrompt ();
		}
	}

	void OnGUI() {
		switch (currentPage) {
			case Page.Interact:
				ShowInteract();
				break;
			case Page.Jump:
				ShowJump();
				break;
			case Page.Sprint:
				ShowSprint();
				break;
			default:
				currentPage = Page.None;
				break;
		}
	}

	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect(((Screen.width - width) / 2), (3 * ((Screen.height - height) / 4)), width, height));
	}

	public void Reset() {
		currentPage = Page.None;
	}

	public void ActivateInteractPrompt() { // call to display Interact prompt
		currentPage = Page.Interact;
	}

	public void ActivateJumpPrompt() { // call to display Jump prompt
		currentPage = Page.Jump;
	}

	public void ActivateSprintPrompt() { // call to display Sprint prompt
		currentPage = Page.Sprint;
	}

	void ShowInteract() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Press", GUILayout.Width (100), GUILayout.Height (75));
		GUILayout.Label (eImage, GUILayout.Width (100));
		GUILayout.Label ("to Interact with Objects", GUILayout.Width (350), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowJump() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Press", GUILayout.Width (100), GUILayout.Height (75));
		GUILayout.Label (spaceImage);
		GUILayout.Label ("to Jump", GUILayout.Width (125), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowSprint() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Hold", GUILayout.Width (75), GUILayout.Height (75));
		GUILayout.Label (shiftImage);
		GUILayout.Label ("to Sprint", GUILayout.Width (130), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}
}