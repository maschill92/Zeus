using UnityEngine;
using System.Collections;

public class Rock : Interactable {
	private bool isBeingCarried = false;
	private Transform carrier;
	private float distanceFromCarrier;

	public override void Interact (Transform interactor)
	{
		if (isBeingCarried)
		{
			isBeingCarried = false;
			carrier = null;
			distanceFromCarrier = 0.0f;
		}
		else
		{
			isBeingCarried = true;
			carrier = interactor;
			distanceFromCarrier = Vector3.Distance(this.transform.position, carrier.position);
		}
		print ("interact: " + distanceFromCarrier);
	}

	void Update()
	{
		if (isBeingCarried)
		{
			this.transform.localRotation = this.carrier.rotation;
			this.transform.position = carrier.position;
			this.transform.position = this.transform.position + this.transform.forward.normalized * distanceFromCarrier; 
				//Vector3.MoveTowards(carrier.position, carrier.forward.normalized * distanceFromCarrier, distanceFromCarrier);
		}
	}
}
