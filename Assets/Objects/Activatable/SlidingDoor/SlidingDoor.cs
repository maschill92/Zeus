using UnityEngine;
using System.Collections;

public class SlidingDoor : Activatable {

	private Vector3 originalLoc;
	public float heightToRaise = 2f;
	public float slideSpeed = 2f;
	private Vector3 targetLocation;

	void Start()
	{
		originalLoc = this.transform.position;
		targetLocation = originalLoc;
	}

	public override void Activate ()
	{
		targetLocation.y = originalLoc.y + heightToRaise;
		audio.Play ();
	}

	public override void Deactivate ()
	{
		targetLocation.y = originalLoc.y;
		audio.Play ();
	}


	void Update()
	{
		// Move up
		if (this.transform.position.y < targetLocation.y)
		{
			float newY = this.transform.position.y + (slideSpeed * Time.deltaTime);
			if (newY > targetLocation.y)
			{
				this.transform.position = new Vector3(originalLoc.x, targetLocation.y, originalLoc.z);
			}
			else
			{
				this.transform.position = new Vector3(originalLoc.x, newY, originalLoc.z);
			}
			if (this.transform.position.y == targetLocation.y || this.transform.position.y == originalLoc.y)
			{
				audio.Stop ();
			}
		}

		// Move down
		else if (this.transform.position.y > targetLocation.y)
		{
			float newY = this.transform.position.y - (slideSpeed * Time.deltaTime);
			if (newY < targetLocation.y)
			{
				this.transform.position = new Vector3(originalLoc.x, targetLocation.y, originalLoc.z);
			}
			else
			{
				this.transform.position = new Vector3(originalLoc.x, newY, originalLoc.z);
			}
			if (audio.isPlaying == false) {
				audio.Play ();
			}
		}

	}

    public override void Reset() { }
}
