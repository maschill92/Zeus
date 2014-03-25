using UnityEngine;
using System.Collections;

public class guiScore : MonoBehaviour {

	private int totalScore = 0;
	private  string displayScore = "";


	void Start() {
		guiText.text = "Score:\t\t\t" + totalScore.ToString();
		guiText.transform.position = new Vector3 (0.85f, 0.965f, 0.0f);
		guiText.fontSize = 20;
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
		guiText.text = "Score:\t\t\t" + displayScore;
	}

	public void Increase(int value) {
		totalScore += value;
	}
	
	public void Reset() {
		totalScore = 0;
	}
}
