using UnityEngine;
using System.Collections;

public class Endpoint : MonoBehaviour {

	public int currentLevel = 0;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (currentLevel == 1) {
				Application.LoadLevel ("Transition");
			}
			else if (currentLevel == 2) {
				Application.LoadLevel ("Ending");
			}
		}
	}
}