using UnityEngine;
using System.Collections;

public class menuMain : MonoBehaviour {

	public string[] credits = { // change in future
		"A Game Created By:",
		"Ben Carpenter",
		"Randall Howatt",
		"Alex Lewis",
		"Michael Schilling"} ;

	private Texture mouseImage;
	private Texture wImage;
	private Texture aImage;
	private Texture sImage;
	private Texture dImage;
	private Texture eImage;
	private Texture spaceImage;
	private Texture shiftImage;
	private Texture blackScreen;

	public enum Page {
		Main, Credits, Controls
	}
	
	private Page currentPage;

	void Start () {
		mouseImage = Resources.Load ("MouseKey") as Texture;
		wImage = Resources.Load ("WKey") as Texture;
		aImage = Resources.Load ("AKey") as Texture;
		sImage = Resources.Load ("SKey") as Texture;
		dImage = Resources.Load ("DKey") as Texture;
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
		} 
	}

	void ShowCredits() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 12;
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

	void EndPage() {
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			ShowBackButton();
		}
	}

	void ShowControls() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 14;
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

	void MainMenu() {
		BeginPage(200,200);
		if (GUILayout.Button ("Start Game")) {
			// play intro movie
			Application.LoadLevel ("Level1"); 
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

	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
	}
}
