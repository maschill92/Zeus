using UnityEngine;
using System.Collections;

public class LightsOnLever : Interactable {

	public Torch myTorch;
	public Material offMat;
	public Material onMat;

	public override void Interact(Transform interactor)
	{
		Toggle();
	}

	public void Toggle()
	{
		if(myTorch.Active)
		{
			myTorch.Deactivate();
		}
		else
		{
			myTorch.Activate();
		}
		audio.Play ();
	}
}
