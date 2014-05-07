using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

	public int level;
	private string[] fileContents; // score, time1, time2, health
	private string timeBonus = "";
	private string healthBonus = "";
	private string addTotals = "";
	private Texture blackScreen;

	void Start () {
		Time.timeScale = 1;
		Screen.showCursor = true;
		blackScreen = Resources.Load ("BlackScreen") as Texture;
		fileContents = new string[4];
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
		BeginPage (600, 300);
		GUILayout.BeginHorizontal ();
		GUILayout.BeginVertical ();
		GUILayout.Label ("Level 1 Time:", GUILayout.Width (250));
		if (level == 2) {
			GUILayout.Label ("Level 2 Time:", GUILayout.Width (250));
		}
		GUILayout.Label ("Current Score:", GUILayout.Width (250));
		GUILayout.Label ("Time Bonus:", GUILayout.Width (250));
		GUILayout.Label ("Health Bonus:", GUILayout.Width (250));
		GUILayout.Label ("Total Score:", GUILayout.Width (250));
		GUILayout.EndVertical ();
		GUILayout.BeginVertical ();
		GUILayout.Label (fileContents[1]);
		if (level == 2) {
			GUILayout.Label (fileContents[2]);
		}
		GUILayout.Label (fileContents[0]);
		GUILayout.Label (timeBonus);
		GUILayout.Label (healthBonus);
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

	string ScoreFormat(int s) {
		if (s == 0) {
			return ("000000");
		}
		else if (s < 10) {
			return ("00000" + s);
		}
		else if (s < 100) {
			return ("0000" + s);
		}
		else if (s < 1000) {
			return ("000" + s);
		}
		else if (s < 10000) {
			return ("00" + s);
		}
		else if (s < 100000) {
			return ("0" + s);
		}
		else {
			return ("" + s);
		}
	}

	string CalculateBonus(int t) {
		int b = 300000;
		int h = (System.Convert.ToInt32 (fileContents[3]) - 1);
		b -= (10000 * t);
		if (b > 0) {
			timeBonus = ScoreFormat (b);
		}
		else {
			timeBonus = "000000";
		}
		h = (h * 25000);
		healthBonus = ScoreFormat (h);
		int newTotal = b + h + System.Convert.ToInt32 (fileContents[0]);
		return ScoreFormat (newTotal);
	}

	void FileOperations() {
		if (!System.IO.Directory.Exists ("C:\\SavedGames\\Hunt")) {
			return;
		}
		System.IO.FileInfo file = new System.IO.FileInfo ("C:\\SavedGames\\Hunt\\data.txt");
		System.IO.StreamReader reader = file.OpenText();
		string fileRead;
		string text;
		bool startRead;
		for (int i = 0; i < 4; i++) {
			startRead = false;
			text = "";
			fileRead = reader.ReadLine ();
			for (int j = 0; j < fileRead.Length; j++) {
				if (fileRead[j] == '=') {
					startRead = true;
				}
				else if (startRead == true) {
					text += ("" + fileRead[j]);
				}
			}
			fileContents[i] = "" + text;
		}
		reader.Close ();
		string minute = "";
		if (level == 1) {
			for (int i = 0; i < fileContents[1].Length; i++) {
				if (fileContents[1][i] == ':') {
					break;
				}
				minute += ("" + fileContents[1][i]);
			}
		}
		else if (level == 2) {
			for (int i = 0; i < fileContents[2].Length; i++) {
				if (fileContents[2][i] == ':') {
					break;
				}
				minute += ("" + fileContents[2][i]);
			}
		}
		addTotals = CalculateBonus (System.Convert.ToInt32 (minute));
		System.IO.File.WriteAllText ("C:\\SavedGames\\Hunt\\data.txt", "Score=" + addTotals + "\nFirstTime=" + fileContents[1] + "\nSecondTime=" + fileContents[2] + "\nHealth=" + fileContents[3]);
	}
}