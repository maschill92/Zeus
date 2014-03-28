using UnityEngine;
using System.Collections;

public class guiTime : MonoBehaviour {

	private float currentSecond;
	private float currentMinute;
	private float lastUpdate;
	private string displayTime;

	void Start() {
		currentSecond = 0;
		currentMinute = 0;
		lastUpdate = 0;
		displayTime = "";
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
		displayTime = "Time:\t\t" + displayTime;
	}

	void OnGUI () {
		GUI.skin.label.fontSize = 20;
		GUI.color = Color.white;
		GUI.Label (new Rect ((Screen.width - (Screen.width / 6)), (Screen.height / 8), 200, 64), displayTime);
	}

	public void Set(int minute, int second) {
		currentMinute = minute;
		currentSecond = second;
	}
	
	public void Reset() {
		currentMinute = 0;
		currentSecond = 0;
	}
}
