using UnityEngine;
using System.Collections;

public class guiTime : MonoBehaviour {

	private float currentSecond = 0;
	private float currentMinute = 0;
	private float lastUpdate = 0;
	private string displayTime = "";

	void Start() {
		guiText.text = "Time:\t\t\t00:00";
		guiText.transform.position = new Vector3 (0.85f, 0.9f, 0.0f);
		guiText.fontSize = 20;
	}
	
	void Update() {
		if ((Time.time - lastUpdate) > 1f) { // update every second
			currentSecond += 1;
			lastUpdate = Time.time;
		}
		if (currentSecond == 60) {
			currentSecond = 0;
			currentMinute += 1;
		}
		if (currentMinute < 10 && currentSecond < 10) { // case 1: 0m:0s
			displayTime = "0" + currentMinute.ToString () + ":0" + currentSecond.ToString ();
		}
		else if (currentMinute < 10) { // case 2: 0m:ss
			displayTime = "0" + currentMinute.ToString () + ":" + currentSecond.ToString ();
		}
		else if (currentSecond < 10) { // case 3: mm:0s
			displayTime = "" + currentMinute.ToString () + ":0" + currentSecond.ToString ();
		}
		else { // case 4: mm:ss
			displayTime = "" + currentMinute.ToString () + ":" + currentSecond.ToString ();
		}
		guiText.text = "Time:\t\t\t" + displayTime;
	}
	
	void Reset() {
		currentMinute = 0;
		currentSecond = 0;
	}
}