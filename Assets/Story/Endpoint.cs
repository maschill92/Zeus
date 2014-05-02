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
				Application.LoadLevel ("ScoreBoard1");
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
		string score = FindObjectOfType<guiScore> ().Get ();
		string time = FindObjectOfType<guiTime> ().Get ();
		string write = "";
		if (currentLevel == 1) {
			write = ("Score=" + score + "\nFirstTime=" + time + "\nSecondTime=00:00");
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
			reader.Close ();
			write = ("Score=" + score + "\nFirstTime=" + fTime + "\nSecondTime=" + time);
		}
		System.IO.File.WriteAllText ("C:\\SavedGames\\Hunt\\data.txt", write);
	}
}