using UnityEngine;
using System.Collections;

public class guiHealth : MonoBehaviour {

	public int currentHealth = 3;
	public string displayHealth = "";

	void Start() {
		displayHealth = "x " + currentHealth;
		guiText.text = displayHealth;
		guiText.transform.position = new Vector3(.055f, 0.975f, 0.0f);
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