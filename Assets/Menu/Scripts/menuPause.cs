﻿using UnityEngine;
using System.Collections;

public class menuPause : MonoBehaviour
{
	private float startTime = 0.1f;
	private float savedTimeScale;
	public string[] credits = { // change in future
		"A Game Created By:",
		"Ben Carpenter",
		"Randall Howatt",
		"Alex Lewis",
		"Michael Schilling"} ;

	private MouseLook playerCamera;
	private	MouseLook mainCamera;

	private Texture mouseImage;
	private Texture wImage;
	private Texture aImage;
	private Texture sImage;
	private Texture dImage;
	private Texture eImage;
	private Texture spaceImage;
	private Texture shiftImage;

	public enum Page {
		None, Main, Controls, Credits
	}
	
	private Page currentPage;

	void Start() {
		Time.timeScale = 1;
		playerCamera = GameObject.Find ("Player").GetComponent<MouseLook>();
		mainCamera = Camera.main.GetComponent<MouseLook>();
		GetComponent<HeadBob> ().enabled = true;
		mouseImage = Resources.Load ("MouseKey") as Texture;
		wImage = Resources.Load ("WKey") as Texture;
		aImage = Resources.Load ("AKey") as Texture;
		sImage = Resources.Load ("SKey") as Texture;
		dImage = Resources.Load ("DKey") as Texture;
		eImage = Resources.Load ("EKey") as Texture;
		spaceImage = Resources.Load ("SpaceKey") as Texture;
		shiftImage = Resources.Load ("ShiftKey") as Texture;
	}

	void LateUpdate () {
		if (Input.GetKeyDown("escape") || Input.GetKeyDown ("return")) {
			switch (currentPage) {
				case Page.None: 
					PauseGame(); 
					break;
				default: 
					currentPage = Page.Main;
					break;
			}
		}
	}

	bool IsBeginning() {
		return (Time.time < startTime);
	}

	void OnGUI () {
		if (IsGamePaused()) {
			GUI.color = Color.white;
			switch (currentPage) {
			case Page.Main: MainPauseMenu(); break;
			case Page.Controls: ShowControls (); break;
			case Page.Credits: ShowCredits(); break;
			}
		}   
	}

	void ShowCredits() {
		BeginPage(300,300);
		foreach(string credit in credits) {
			GUILayout.Label(credit);
		}
		EndPage();
	}
	
	void ShowBackButton() {
		if (GUI.Button(new Rect((Screen.width / 2), ((Screen.height / 2) + (Screen.height / 3)), 75, 20), "Back")) {
			currentPage = Page.Main;
		}
	}

	void ShowControls() {
		BeginPage (200, 600);
		GUILayout.BeginHorizontal ();
			GUILayout.Label (mouseImage);
			GUILayout.Label ("Camera");
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
			GUILayout.Label (wImage);
			GUILayout.Label ("Move Forward");
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
			GUILayout.Label (aImage);
			GUILayout.Label ("Move Left");
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
			GUILayout.Label (sImage);
			GUILayout.Label ("Move Backward");
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
			GUILayout.Label (dImage);
			GUILayout.Label ("Move Right");
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
			GUILayout.Label (eImage);
			GUILayout.Label ("Interact");
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
			GUILayout.Label (spaceImage);
			GUILayout.Label ("Jump");
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
			GUILayout.Label (shiftImage);
			GUILayout.Label ("Sprint");
		GUILayout.EndHorizontal ();
		EndPage ();
	}
		
	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
	}
	
	void EndPage() {
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			ShowBackButton();
		}
	}

	void MainPauseMenu() {
		BeginPage(200,200);
		if (GUILayout.Button ("Resume")) {
			UnPauseGame();
		}
		if (GUILayout.Button ("Controls")) {
			currentPage = Page.Controls;
		}
		if (GUILayout.Button ("Credits")) {
			currentPage = Page.Credits;
		}
		if (GUILayout.Button ("Exit to Main Menu")) {
			// call exit to main menu function
		}
		if (GUILayout.Button ("Exit to Desktop")) {
			// call exit to desktop function
		}
		EndPage();
	}

	void PauseGame() {
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
		AudioListener.pause = true;
		playerCamera.enabled = false;
		mainCamera.enabled = false;
		GetComponent<HeadBob> ().enabled = false;
		currentPage = Page.Main;
	}
	
	void UnPauseGame() {
		Time.timeScale = savedTimeScale;
		GetComponent<MouseLook>().enabled = true;
		AudioListener.pause = false;
		playerCamera.enabled = true;
		mainCamera.enabled = true;
		GetComponent<HeadBob> ().enabled = true;
		currentPage = Page.None;
	}
	
	bool IsGamePaused() {
		return (Time.timeScale == 0);
	}
	
	void OnApplicationPause(bool pause) {
		if (IsGamePaused()) {
			AudioListener.pause = true;
		}
	}
}