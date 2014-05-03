﻿using UnityEngine;
using System.Collections;

public class KeyedDoor : Interactable {

	public int requiredKeys = 3;
	private int keysLeft;

	void Start()
	{
		keysLeft = requiredKeys;
	}

	public override void Interact (Transform interactor)
	{
		print ("slidingDoor interact");
		guiKey keyGod = Camera.main.GetComponent<guiKey>();
		int keyCount = keyGod.currentKeys;
		if (keyCount < requiredKeys)
		{
			keyGod.Decrease(keyCount);
			keysLeft -= keyCount;
		}
		else
		{
			keyGod.Decrease(requiredKeys);
			keysLeft = 0;
			if (!audio.isPlaying)
			{
				audio.Play();
			}
		}

		if (keysLeft <= 0)
		{
			GetComponent<SlidingDoor>().Activate();
		}
	}
}
