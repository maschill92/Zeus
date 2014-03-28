using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	public float fallTime = 2.0f;

	void OnTriggerEnter()
	{
		print ("I'm starting to fall!");
		StartCoroutine("Fall");
	}
	IEnumerator Fall()
	{
		yield return new WaitForSeconds(fallTime);
		rigidbody.isKinematic = false;
		rigidbody.useGravity = true;
	}
}
