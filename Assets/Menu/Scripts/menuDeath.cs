using UnityEngine;
using System.Collections;

public class menuDeath : MonoBehaviour {
	
	private bool isDead;
	
	public enum Page {
		None, Main
	}
	
	private Page currentPage;
	
	void Start () {
		isDead = false;
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
		GUI.color = Color.white;
		if (isDead) {
			switch (currentPage) {
			case Page.Main: DeathMenu(); break;
			}
		}   
	}
	
	public void killPlayer() { // call to display Death Menu
		isDead = true;
	}
	
	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
	}
	
	private void DeathMenu() {
		BeginPage(200,200);
		GUI.skin.label.fontSize = 28;
		int trysRemaining = GetComponent<guiHealth> ().Get ();
		string restartText;
		if (trysRemaining != 1)
			restartText = ("Restart (" + trysRemaining.ToString() + " lives remaining)");
		else
			restartText = ("Restart (" + trysRemaining.ToString() + " life remaining)");
		GUILayout.Label ("You Have Died\n");
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
		GetComponent<menuPause> ().enabled = false;
		currentPage = Page.Main;
	}
	
	void EndDeath() {
		isDead = false;
		AudioListener.pause = false;
		GetComponent<menuPause> ().enabled = true;
		GetComponent<menuPause> ().UnPauseGame (false);
		currentPage = Page.None;
	}
}