using UnityEngine;
using System.Collections;

public class BoulderRoll : Activatable {

	public Vector3 angularVelocity = new Vector3(500f, 0f, 0f);
	public Vector3 initialVelocity = new Vector3(10f, 0f, 0f);
	public float timeDelay = 3f;
	private bool isActivated = false;

	public override void Activate ()
	{
		StartCoroutine("Roll");
		//isActivated = true;
		//rigidbody.useGravity = true;
	}

	public override void Deactivate ()
	{
		// No deactivation necessary
	}

	void Update () {
		/*
		if (isActivated)
		{
			rigidbody.angularVelocity = this.angularVelocity;
		}
		*/
	}

	IEnumerator Roll()
	{
		rigidbody.angularVelocity = this.angularVelocity;
		yield return new WaitForSeconds(timeDelay);
		rigidbody.velocity = initialVelocity;
		rigidbody.useGravity = true;
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			print ("kill the player! the boulder crushed him!");
		}
	}
}
