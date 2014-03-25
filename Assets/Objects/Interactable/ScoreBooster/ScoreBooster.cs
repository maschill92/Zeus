using UnityEngine;
using System.Collections;

public class ScoreBooster : Interactable {

	private guiScore scoreKeeper;
	public int value = 100;

	void Start()
	{
		scoreKeeper = GameObject.FindObjectOfType<guiScore>();
	}

	public override void Interact (Transform interactor)
	{
		scoreKeeper.Increase(value);
		GameObject.Destroy(this.gameObject);
	}
}
