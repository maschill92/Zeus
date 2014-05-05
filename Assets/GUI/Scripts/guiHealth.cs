using UnityEngine;
using System.Collections;

public class guiHealth : MonoBehaviour {

	private int currentHealth;
	private string displayHealth;

	private Texture healthImage;
	
	void Start() {
		LoadHealth ();
		displayHealth = "";
		healthImage = Resources.Load ("Heart") as Texture;
	}

	void Update() {
		displayHealth = ("" + currentHealth);
	}

	void OnGUI () {
		GUI.skin.label.fontSize = 16;
		GUI.color = Color.white;
		DrawOutline (new Rect ((Screen.width / 12), (Screen.height / 20), 64, 64), ("x " + displayHealth));
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
	
	public void Decrease() {
		currentHealth--;
	}

	public void Set(int value) {
		currentHealth = value;
	}
	
	public string Get() {
		return displayHealth;
	}

	void LoadHealth() {
		if (!System.IO.Directory.Exists ("C:\\SavedGames\\Hunt")) {
			return;
		}
		System.IO.FileInfo file = new System.IO.FileInfo ("C:\\SavedGames\\Hunt\\data.txt");
		System.IO.StreamReader reader = file.OpenText ();
		string text = reader.ReadLine ();
		text = reader.ReadLine ();
		text = reader.ReadLine ();
		text = reader.ReadLine (); // read fourth line
		string health = "";
		bool startRead = false;
		for (int i = 0; i < text.Length; i++) {
			if (text [i] == '=') { // start reading data
				startRead = true;
			}
			else if (startRead == true) {
				health += ("" + text [i]);
			}
		}
		reader.Close ();
		Set (System.Convert.ToInt32 (health));
	}
}