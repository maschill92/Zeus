using UnityEngine;
using System.Collections;

public class guiScore : MonoBehaviour {

	public int totalScore;
	private  string displayScore;

	void Start() {
		totalScore = 0;
		displayScore = "";
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
		GUI.Label (new Rect ((Screen.width - (Screen.width / 6)), (Screen.height / 20), 200, 64), displayScore);
	}

	public void Increase(int value) {
		totalScore += value;
	}

	public void Set(int value) {
		totalScore = value;
	}
	
	public void Reset() {
		totalScore = 0;
	}
}
