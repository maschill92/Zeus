using UnityEngine;
using System.Collections;

public class BoulderRoll : Activatable {

	public Vector3 angularVelocity = new Vector3(500f, 0f, 0f);
	private bool isActivated = false;

	public override void Activate ()
	{
		isActivated = true;
		rigidbody.useGravity = true;
	}

	public override void Deactivate ()
	{
		// No deactivation necessary
	}

	void Update () {
		if (isActivated)
		{
			rigidbody.angularVelocity = this.angularVelocity;
		}
	}
}
