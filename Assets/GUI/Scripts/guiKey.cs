using UnityEngine;
using System.Collections;

public class guiKey : MonoBehaviour {

	public int currentKeys;
	public string displayKeys;

	private Texture keyImage;

	void Start() {
		currentKeys = 0;
		displayKeys = "";
		keyImage = Resources.Load ("Key") as Texture;
	}

	void Update() {
		displayKeys = "x " + currentKeys;
	}

	void OnGUI () {
		GUI.skin.label.fontSize = 16;
		GUI.color = Color.white;
		GUI.Label (new Rect((Screen.width / 12), (Screen.height / 8), 64, 64), displayKeys);
		GUI.Label (new Rect ((Screen.width / 50), (Screen.height / 10), 64, 64), keyImage);
	}

	public void Increase() {
		currentKeys += 1;
	}

	public void Decrease(int value) {
		currentKeys -= value;
	}

	public void Set(int value) {
		currentKeys = value;
	}

	public void Reset() {
		currentKeys = 0;
	}	
}
