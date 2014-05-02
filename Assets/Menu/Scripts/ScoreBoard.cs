using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

	public int level;
	private string score;
	private string time1;
	private string time2;
	private string bonus;
	private string addTotals;
	private Texture blackScreen;

	void Start () {
		blackScreen = Resources.Load ("BlackScreen") as Texture;
		score = "";
		time1 = "";
		time2 = "";
		bonus = "";
		addTotals = "";
		FileOperations ();
	}
	
	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackScreen, ScaleMode.StretchToFill, true);
		DrawHeader (new Rect(((Screen.width - 1000) / 2), (Screen.height / 12), 1000, 400));
		DrawScore ();
	}

	void DrawHeader(Rect position) {
		string text = ("Level " + level + " Complete!");
		GUI.skin.label.fontSize = 64;
		GUIStyle centeredText = new GUIStyle ("label");
		centeredText.alignment = TextAnchor.UpperCenter;
		GUI.color = Color.black;
		position.x--;
		GUI.Label(position, text, centeredText);
		position.x += 2;
		GUI.Label(position, text, centeredText);
		position.x--;
		position.y--;
		GUI.Label(position, text, centeredText);
		position.y += 2;
		GUI.Label(position, text, centeredText);
		GUI.color = Color.white;
		position.y--;
		GUI.Label(position, text, centeredText); // regular text
	}

	void DrawScore() {
		GUI.skin.label.fontSize = 32;
		GUI.color = Color.white;
		BeginPage (500, 300);
		GUILayout.BeginHorizontal ();
		GUILayout.BeginVertical ();
		GUILayout.Label ("Total Time:", GUILayout.Width (300));
		GUILayout.Label ("Current Score:", GUILayout.Width (300));
		GUILayout.Label ("Time Bonus:", GUILayout.Width (300));
		GUILayout.Label ("Total Score:", GUILayout.Width (300));
		GUILayout.EndVertical ();
		GUILayout.BeginVertical ();
		if (level == 1) {
			GUILayout.Label (time1);
		}
		else if (level == 2) {
			GUILayout.Label (time2);
		}
		GUILayout.Label (score);
		GUILayout.Label (bonus);
		GUILayout.Label (addTotals);
		GUILayout.EndVertical ();
		GUILayout.EndHorizontal ();
		EndPage ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
	}

	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect(((Screen.width - width) / 2), ((Screen.height - height) / 2), width, height));
	}

	void EndPage() {
		GUILayout.EndArea();
		if (level == 1) {
			if (GUI.Button (new Rect ((Screen.width / 2) - 100, ((Screen.height / 2) + (Screen.height / 3)), 200, 50), "Start Level 2")) {
				Application.LoadLevel ("Transition");
			}
		}
		else if (level == 2) {
			if (GUI.Button (new Rect ((Screen.width / 2) - 100, ((Screen.height / 2) + (Screen.height / 3)), 200, 50), "Return to Main Menu")) {
				Application.LoadLevel ("MainMenu");
			}
		}
	}

	string TimeBonus(int t) {
		if (t < 10) {
			bonus = "100000";
		}
		else if (t < 13) {
			bonus = "075000";
		}
		else if (t < 15) {
			bonus = "050000";
		}
		else {
			bonus = "025000";
		}
		int newTotal = System.Convert.ToInt32(bonus) + System.Convert.ToInt32 (score);
		if (newTotal == 0) {
			return ("000000");
		}
		else if (newTotal < 10) {
			return ("00000" + newTotal);
		}
		else if (newTotal < 100) {
			return ("0000" + newTotal);
		}
		else if (newTotal < 1000) {
			return ("000" + newTotal);
		}
		else if (newTotal < 10000) {
			return ("00" + newTotal);
		}
		else if (newTotal < 100000) {
			return ("0" + newTotal);
		}
		else {
			return ("" + newTotal);
		}
	}

	void FileOperations() {
		if (!System.IO.Directory.Exists ("C:\\SavedGames\\Hunt")) {
			return;
		}
		System.IO.FileInfo file = new System.IO.FileInfo ("C:\\SavedGames\\Hunt\\data.txt");
		System.IO.StreamReader reader = file.OpenText();
		string text = reader.ReadLine (); // read first line
		bool startRead = false;
		for (int i = 0; i < text.Length; i++) {
			if (text[i] == '=') { // start reading data
				startRead = true;
			}
			else if (startRead == true) {
				score += ("" + text[i]);
			}
		}
		text = reader.ReadLine (); // read second line
		startRead = false;
		for (int i = 0; i < text.Length; i++) {
			if (text[i] == '=') {
				startRead = true;
			}
			else if (startRead == true) {
				time1 += ("" + text[i]);
			}
		}
		text = reader.ReadLine (); // read third line
		startRead = false;
		for (int i = 0; i < text.Length; i++) {
			if (text[i] == '=') {
				startRead = true;
			}
			else if (startRead == true) {
				time2 += ("" + text[i]);
			}
		}
		reader.Close ();

		string minute = "";
		if (level == 1) {
			for (int i = 0; i < time1.Length; i++) {
				if (time1[i] == ':') {
					break;
				}
				minute += ("" + time1[i]);
			}
		}
		else if (level == 2) {
			for (int i = 0; i < time2.Length; i++) {
				if (time2[i] == ':') {
					break;
				}
				minute += ("" + time2[i]);
			}
		}
		addTotals = TimeBonus (System.Convert.ToInt32 (minute));
		System.IO.File.WriteAllText ("C:\\SavedGames\\Hunt\\data.txt", "Score=" + addTotals + "\nFirstTime=" + time1 + "\nSecondTime=" + time2);
	}
}