using UnityEngine;
using System.Collections;

public class guiTime : MonoBehaviour {

	private double currentTime = Time.time;

	void Start() {
		guiText.text = currentTime.ToString ();
		guiText.transform.position = new Vector3 (0.95f, 0.925f, 0.0f);
	}

	void Update() {
		currentTime = Mathf.Floor (Time.time);
		guiText.text = currentTime.ToString ();
	}
	
}