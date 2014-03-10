using UnityEngine;
using System.Collections;

public class guiScore : MonoBehaviour {

	public int totalScore = 0;
	
	void Start() {
		guiText.text = totalScore.ToString();
		guiText.transform.position = new Vector3 (0.95f, 0.975f, 0.0f);
	}
	
	void Increase() {
		totalScore += 1000;
		guiText.text = totalScore.ToString();
	}
	
	void Reset() {
		guiText.text = "000000";
	}
}