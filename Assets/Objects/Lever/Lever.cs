using UnityEngine;
using System.Collections;

public class Lever : Interactable {

	public Activatable[] thingsToActivate;
	public bool isOneTimeTrigger = false;
	private bool isOn = false;
	public Material offMat;
	public Material onMat;

	public override void Interact(Transform interactor)
	{
		Toggle ();
	}

	public virtual void Toggle()
	{
		if (!isOn)
		{
			for(int i = 0; i < thingsToActivate.Length; i++)
			{
				thingsToActivate[i].Activate();
			}
			isOn = true;
			renderer.material = new Material(onMat);
			audio.Play();
		}
		// only allow deactivation if the lever allows itself to be toggled indefinitely
		else if (!isOneTimeTrigger)
		{
			for (int i = 0; i < thingsToActivate.Length; i++)
			{
				thingsToActivate[i].Deactivate();
			}
			isOn = false;
			renderer.material = new Material(offMat);
			audio.Play();
		}
	}
}
