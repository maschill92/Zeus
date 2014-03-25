using UnityEngine;
using System.Collections;

public class Key : Interactable {

	private guiKey keyKeeper;

	// Use this for initialization
	void Start () {
		keyKeeper = GameObject.FindObjectOfType<guiKey>();
	}

	public override void Interact (Transform interactor)
	{
		keyKeeper.Increase();
		GameObject.Destroy(this.gameObject);
	}
}
