using UnityEngine;
using System.Collections;

public class guiKey : MonoBehaviour {

	public int currentKeys = 0;
	public string displayKeys = "";
	
	void Start() {
		displayKeys = "x " + currentKeys;
		guiText.text = displayKeys;
		guiText.transform.position = new Vector3(.07f, 0.85f, 0.0f);
		guiText.fontSize = 16;
	}

	void Increase() {
		currentKeys += 1;
		displayKeys = "x " + currentKeys;
		guiText.text = displayKeys;
	}

	void Decrease() {
		currentKeys -= 1;
		displayKeys = "x " + currentKeys;
		guiText.text = displayKeys;
	}

	void Reset() {
		currentKeys = 3;
		displayKeys = "x " + currentKeys;
		guiText.text = displayKeys;
	}
	
}