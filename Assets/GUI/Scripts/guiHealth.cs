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
		DrawOutline (new Rect ((Screen.width / 12), (Screen.height / 20), 64, 64), displayHealth);
		GUI.Label (new Rect ((Screen.width / 50), (Screen.height / 50), 64, 64), healthImage);
	}

	void DrawOutline(Rect position, string text) {
		GUI.color = Color.black;
		position.x--;
		GUI.Label(position, text);
		position.x += 2;
		GUI.Label(position, text);
		position.x--;
		position.y--;
		GUI.Label(position, text);
		position.y += 2;
		GUI.Label(position, text);
		GUI.color = Color.white;
		position.y--;
		GUI.Label(position, text); // regular text
	}

	public void Increase() {
		currentHealth++;
	}

	public void Decrease() {
		currentHealth--;
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