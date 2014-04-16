using UnityEngine;
using System.Collections;

public class menuDeath : MonoBehaviour {
	
	private bool isDead;

	private Texture blackScreen;

	public enum Page {
		None, Main
	}
	
	private Page currentPage;
	
	void Start () {
		isDead = false;
		blackScreen = Resources.Load ("BlackScreen") as Texture;
	}
	
	void LateUpdate () {
		if (isDead ||  Input.GetKeyDown ("l")) { // remove 'L' input when player killing is implemented
			switch(currentPage) {
			case Page.None:
				StartDeath();
				break;
			default:
				currentPage = Page.Main;
				break;
			}
		}
	}
	
	void OnGUI () {
		if (isDead) {
			switch (currentPage) {
			case Page.Main:
				GUI.color = new Color32(255, 255, 255, 175);
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackScreen, ScaleMode.StretchToFill, true);
				DeathMenu();
				break;
			}
		}   
	}
	
	public void killPlayer() { // call to display Death Menu
		isDead = true;
	}
	
	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect(((Screen.width - width) / 2), ((Screen.height - height) / 2), width, height));
	}
	
	private void DeathMenu() {
		BeginPage(200,200);
		GUI.skin.label.fontSize = 32;
		GUI.color = Color.white;
		int trysRemaining = GetComponent<guiHealth> ().Get ();
		string restartText;
		if (trysRemaining != 1)
			restartText = ("Restart (" + trysRemaining.ToString() + " lives remaining)");
		else
			restartText = ("Restart (" + trysRemaining.ToString() + " life remaining)");
		GUILayout.Label ("You Are Dead\n");
		if (trysRemaining > 0) { // only display if current lives are greater than zero
			if (GUILayout.Button (restartText)) {
				EndDeath ();
			}
		}
		if (GUILayout.Button ("Exit to Main Menu")) {
			Application.LoadLevel ("MainMenu");
		}
		if (GUILayout.Button ("Exit to Desktop")) {
			Application.Quit ();
		}
		GUILayout.EndArea();
	}
	
	void StartDeath() {
		isDead = true;
		AudioListener.pause = true;
		GetComponent<guiHealth> ().Decrease ();
		GetComponent<menuPause> ().PauseGame (false);
        GetComponent<menuPause>().enabled = false;
		currentPage = Page.Main;
	}
	
	void EndDeath() {
		isDead = false;
		AudioListener.pause = false;
		GetComponent<guiPrompt> ().Reset ();
		GetComponent<menuPause> ().enabled = true;
		GetComponent<menuPause> ().UnPauseGame (false);
		currentPage = Page.None;
		FindObjectOfType<Manager>().Reset();
	}
}