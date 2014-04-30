using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	public float fallTimeDelay = 2.0f;
	public float fallDistance = 1.0f;
	private float finalHeight;
	private Vector3 originalLoc;

	void Start()
	{
		originalLoc = this.transform.position;
		finalHeight = transform.position.y - fallDistance;
	}

	void OnTriggerEnter()
	{
		print ("I'm starting to fall!");
		StartCoroutine("Fall");
	}

	IEnumerator Fall()
	{
		AudioSource.PlayClipAtPoint (audio.clip, transform.position);
		yield return new WaitForSeconds(fallTimeDelay);
		rigidbody.isKinematic = false;
		rigidbody.useGravity = true;
		while(transform.position.y > finalHeight)
		{
			yield return null;
		}
		rigidbody.isKinematic = true;
		rigidbody.useGravity = false;
	}

	public void Reset()
	{
		this.transform.position = originalLoc;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = false;
	}
}
