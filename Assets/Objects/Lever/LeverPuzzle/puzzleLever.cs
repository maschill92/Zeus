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
		master.LeverActivated(INDEX);
	}

	public void Deactivate()
	{
		isOn = false;
		renderer.material = offMat;
	}
}
