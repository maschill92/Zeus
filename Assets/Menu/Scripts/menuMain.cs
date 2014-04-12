﻿using UnityEngine;
using System.Collections;

public class menuMain : MonoBehaviour {

	public string[] credits = { // change in future
		"University of North Dakota\n",
		"Instructor:",
		"\tDr. Ron Marsh\n",
		"Course:",
		"\tComputer Science 448\n",
		"A Game Created By:\n",
		"Ben Carpenter:",
		"\tLevel 2 Design",
		"\tObject Art/Animation",
		"\tMusic\n",
		"Randall Howatt:",
		"\tLevel 1 Design",
		"\tInterface/Menu Design",
		"\tSound Effects\n",
		"Alex Lewis:",
		"\tEnvironment Design",
		"\tObject Art/Animation\n",
		"Michael Schilling:",
		"\tCharacter Controls",
		"\tObject Programming",
		"\tPuzzle Programming"} ;

	private Texture mouseImage;
	private Texture wasdImage;
	private Texture eImage;
	private Texture spaceImage;
	private Texture shiftImage;
	private Texture blackScreen;

	Vector2 scrollPosition;

	public enum Page {
		Main, Levels, Credits, Controls
	}
	
	private Page currentPage;

	void Start () {
		mouseImage = Resources.Load ("MouseKey") as Texture;
		wasdImage = Resources.Load ("WASDKey") as Texture;
		eImage = Resources.Load ("EKey") as Texture;
		spaceImage = Resources.Load ("SpaceKey") as Texture;
		shiftImage = Resources.Load ("ShiftKey") as Texture;
		blackScreen = Resources.Load ("BlackScreen") as Texture;
	}

	void OnGUI () {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackScreen); // put art still in when ready
		switch (currentPage) {
			case Page.Main:
				MainMenu();
				break;
			case Page.Credits:
				ShowCredits();
				break;
			case Page.Controls:
				ShowControls();
				break;
			case Page.Levels:
				ShowLevels();
				break;
		} 
	}

	void ShowCredits() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 18;
		BeginPage(400,400);
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (400), GUILayout.Height (400));
		foreach(string credit in credits) {
			GUILayout.Label(credit);
		}
		GUILayout.EndScrollView ();
		EndPage();
	}

	void ShowBackButton() {
		if (GUI.Button(new Rect((Screen.width / 2) - 30, ((Screen.height / 2) + (Screen.height / 3)), 75, 20), "Back")) {
			currentPage = Page.Main;
		}
	}

	void ShowLevels() {
		BeginPage (200, 200);
		if (GUILayout.Button ("Level 1")) {
			// play intro movie
			Application.LoadLevel ("Level1"); 
		}
		if (GUILayout.Button("Level 2")) {
			// play transition
			Application.LoadLevel ("Level2");
		}
		EndPage ();
	}

	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect(((Screen.width - width) / 2), ((Screen.height - height) / 2), width, height));
	}

	void EndPage() {
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			ShowBackButton();
		}
	}

	void ShowControls() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 30;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (400, 400);
		GUILayout.BeginHorizontal ();
		GUILayout.BeginVertical ();
		GUILayout.Label (mouseImage);
		GUILayout.Label (wasdImage);
		GUILayout.Label (eImage);
		GUILayout.Label (spaceImage);
		GUILayout.Label (shiftImage);
		GUILayout.EndVertical ();
		GUILayout.BeginVertical ();
		GUILayout.Label ("Camera", GUILayout.Height (75));
		GUILayout.Label ("Movement", GUILayout.Height (75));
		GUILayout.Label ("Interact", GUILayout.Height (55));
		GUILayout.Label ("Jump", GUILayout.Height (75));
		GUILayout.Label ("Sprint", GUILayout.Height (75));
		GUILayout.EndVertical ();
		GUILayout.EndHorizontal ();
		EndPage ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
	}

	void MainMenu() {
		BeginPage(200,200);
		if (GUILayout.Button ("Start Game")) {
			// play intro movie
			Application.LoadLevel ("Level1"); 
		}
		if (GUILayout.Button ("Level Select")) {
			currentPage = Page.Levels;
		}
		if (GUILayout.Button ("Controls")) {
			currentPage = Page.Controls;
		}
		if (GUILayout.Button ("Credits")) {
			currentPage = Page.Credits;
		}
		if (GUILayout.Button ("Exit to Desktop")) {
			Application.Quit ();
		}
		EndPage();
	}
}
