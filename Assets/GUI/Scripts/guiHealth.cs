using UnityEngine;
using System.Collections;

public class guiHealth : MonoBehaviour {

	public int currentHealth;
	private string displayHealth;

	private Texture healthImage;
	
	void Start() {
		currentHealth = 3;
		displayHealth = "";
		healthImage = Resources.Load ("Heart") as Texture;
	}

	void Update() {
		displayHealth = "x " + currentHealth;
	}

	void OnGUI () {
		GUI.skin.label.fontSize = 16;
		GUI.color = Color.white;
		GUI.Label (new Rect((Screen.width / 12), (Screen.height / 20), 64, 64), displayHealth);
		GUI.Label (new Rect ((Screen.width / 50), (Screen.height / 50), 64, 64), healthImage);
	}

	public void Increase() {
		currentHealth += 1;
	}

	public void Decrease() {
		currentHealth -= 1;
	}

	public void Set(int value) {
		currentHealth = value;
	}
	
	public int Get() {
		return currentHealth;
	}
		
	public void Reset() {
		currentHealth = 3;
	}
}
