using UnityEngine;
using System.Collections;

public class puzzleLever : Interactable {

	public LeverPuzzle master;
	public int INDEX;
	private bool isOn = false;
	public Material offMat;
	public Material onMat;
	
	public override void Interact(Transform interactor)
	{
		if(!isOn)
		{
			Activate();
		}
	}

	public void Activate()
	{		
		isOn = true;
		renderer.material = onMat;
		// ANIMATE NOW
		master.LeverActivated(INDEX);
	}

	public void Deactivate()
	{
		isOn = false;
		// ANIMATE NOW
		renderer.material = offMat;
	}
}
