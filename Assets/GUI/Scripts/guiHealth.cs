using UnityEngine;
using System.Collections;

public class guiHealth : MonoBehaviour {

	private int currentHealth = 3;
	private string displayHealth = "";

	void Start() {
		displayHealth = "x " + currentHealth;
		guiText.text = displayHealth;
		guiText.transform.position = new Vector3(.07f, 0.95f, 0.0f);
		guiText.fontSize = 16;
	}

	void Increase() {
		currentHealth += 1;
		displayHealth = "x " + currentHealth;
		guiText.text = displayHealth;
	}

	void Decrease() {
		currentHealth -= 1;
		displayHealth = "x " + currentHealth;
		guiText.text = displayHealth;
	}
		
	void Reset() {
		currentHealth = 3;
		displayHealth = "x " + currentHealth;
		guiText.text = displayHealth;
	}
}