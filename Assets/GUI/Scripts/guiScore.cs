using UnityEngine;
using System.Collections;

public class guiScore : MonoBehaviour {

	public int totalScore;
	private string displayScore;

	private AudioClip scoreLow;
	private AudioClip scoreMedium;
	private AudioClip scoreHigh;

	void Start() {
		totalScore = 0;
		displayScore = "";
		scoreLow = (AudioClip)Resources.Load ("Sound/Score/scoreLow");
		scoreMedium = (AudioClip)Resources.Load ("Sound/Score/scoreMedium");
		scoreHigh = (AudioClip)Resources.Load ("Sounds/Score/scoreHigh");
	}

	void Update() {
		if (totalScore == 0) {
			displayScore = "000000";
		}
		else if (totalScore < 10) {
			displayScore = "00000" + totalScore;
		}
		else if (totalScore < 100) {
			displayScore = "00" + totalScore;
		}
		else if (totalScore < 1000) {
			displayScore = "000" + totalScore;
		}
		else if (totalScore < 10000) {
			displayScore = "00" + totalScore;
		}
		else if (totalScore < 100000) {
			displayScore = "0" + totalScore;
		}
		else {
			displayScore = "" + totalScore;
		}
		displayScore = "Score:\t\t" + displayScore;
	}

	void OnGUI () {
		GUI.skin.label.fontSize = 20;
		GUI.color = Color.white;
		DrawOutline (new Rect ((Screen.width - (Screen.width / 6)), (Screen.height / 20), 200, 64), displayScore);
	}

	void DrawOutline(Rect position, string text) {
		GUI.color = Color.black;
		position.x--;
		GUI.Label(position, text);
		position.x += 2;
		GUI.Label(position, text);
		position.x--;
		position.y--;
		GUI.Label(position, text);
		position.y += 2;
		GUI.Label(position, text);
		GUI.color = Color.white;
		position.y--;
		GUI.Label(position, text); // regular text
	}

	public void Increase(int value) {
		totalScore += value;
		if (value >= 10000)
			audio.PlayOneShot (scoreHigh);
		else if (value >= 5000)
			audio.PlayOneShot (scoreMedium);
		else
			audio.PlayOneShot (scoreLow);
	}

	public void Set(int value) {
		totalScore = value;
	}

	public int Get() {
		return totalScore;
	}
	
	public void Reset() {
		totalScore = 0;
	}
}
