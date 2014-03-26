using UnityEngine;
using System.Collections;

public class guiHealth : MonoBehaviour {

	public int currentHealth = 3;
	private string displayHealth = "";

	void Start() {
		displayHealth = "x " + currentHealth;
		guiText.text = displayHealth;
		guiText.transform.position = new Vector3(.07f, 0.95f, 0.0f);
		guiText.fontSize = 16;
	}

	public void Set(int value) {
		currentHealth = value;
	}

	public void Increase() {
		currentHealth += 1;
		displayHealth = "x " + currentHealth;
		guiText.text = displayHealth;
	}

	public void Decrease() {
		currentHealth -= 1;
		displayHealth = "x " + currentHealth;
		guiText.text = displayHealth;
	}
		
	public void Reset() {
		currentHealth = 3;
		displayHealth = "x " + currentHealth;
		guiText.text = displayHealth;
	}
}
