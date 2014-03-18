using UnityEngine;
using System.Collections;

public class Lever : Interactable {

	public Activatable[] thingsToActivate;
	private bool isOn = false;
	public bool isOneTimeTrigger = false;

	public override void Interact(Transform interactor)
	{
		print ("lever interact");
		Toggle ();
	}

	public void Toggle()
	{
		if (!isOn)
		{
			for(int i = 0; i < thingsToActivate.Length; i++)
			{
				thingsToActivate[i].Activate();
			}
			isOn = true;
			// ANIMATE NOW
		}
		// only allow deactivation if the lever allows itself to be toggled indefinitely
		else if (!isOneTimeTrigger)
		{
			for (int i = 0; i < thingsToActivate.Length; i++)
			{
				thingsToActivate[i].Deactivate();
			}
			isOn = false;
			// ANIMATE NOW
		}
	}
}
