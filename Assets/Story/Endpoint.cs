using UnityEngine;
using System.Collections;

public class Endpoint : MonoBehaviour {

	public int currentLevel = 0;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			WriteScore ();
			if (currentLevel == 1) {
				Application.LoadLevel ("Transition");
			}
			else if (currentLevel == 2) {
				Application.LoadLevel ("Ending");
			}
		}
	}

	void WriteScore() {
		if (!System.IO.Directory.Exists ("C:\\SavedGames\\Hunt")) {
			return;
		}
		int score = FindObjectOfType<guiScore> ().Get ();
		int time = FindObjectOfType<guiTime> ().GetMinute ();
		string write = "";
		if (currentLevel == 1) {
			write = ("Score=" + score + "\nFirstTime=" + time + "\nSecondTime=0");
		}
		else if (currentLevel == 2) {
			System.IO.FileInfo file = new System.IO.FileInfo ("C:\\SavedGames\\Hunt\\data.txt");
			System.IO.StreamReader reader = file.OpenText ();
			string text = reader.ReadLine ();
			text = reader.ReadLine ();
			string fTime = "";
			bool startRead = false;
			for (int i = 0; i < text.Length; i++) {
				if (text [i] == '=') { // start reading data
					startRead = true;
				}
				else if (startRead == true) {
					fTime += ("" + text [i]);
				}
			}
			write = ("Score=" + score + "\nFirstTime=" + System.Convert.ToInt32 (fTime) + "\nSecondTime=" + time);
		}
		else { // current level does not exist
			return;
		}
		System.IO.File.WriteAllText ("C:\\SavedGames\\Hunt\\data.txt", write);
	}
}