using UnityEngine;
using System.Collections;

public class Lever : Interactable {

	public Activatable[] thingsToActivate;
	private bool isTriggered = false;

	public override void Interact(Transform interactor)
	{
		print ("lever interact");
		Trigger ();
	}

	public void Trigger()
	{
		if (!isTriggered)
		{
			for(int i = 0; i < thingsToActivate.Length; i++)
			{
				thingsToActivate[i].Activate();
			}
			
			// ANIMATE NOW
		}
		isTriggered = true;
	}
}
