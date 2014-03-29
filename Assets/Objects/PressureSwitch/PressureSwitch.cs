using UnityEngine;
using System.Collections;

public class PressureSwitch : MonoBehaviour 
{
	public Activatable[] thingsToActivate;
	public bool isOneTimeTrigger = false; 	// true means that the switch can be triggered on, then off, then on...
	private bool isTriggered = false; 		// is the switch currently triggered?
	private short triggeringObjectCount;	// allows a player to walk on a switch while a rock is on it without 'UnTriggering'

	private Vector3 targetLocation;
	private Vector3 originalLoc;
	public float heightToLower = 0.05f;
	public float slideSpeed = 2f;

	private void Trigger()
	{
		triggeringObjectCount++;
		if (!isTriggered)
		{
			for(int i = 0; i < thingsToActivate.Length; i++)
			{
				thingsToActivate[i].Activate();
			}
			targetLocation.y = originalLoc.y - heightToLower;
		}
		isTriggered = true;
	}

	private void UnTrigger()
	{
		triggeringObjectCount--;
		// UnTrigger... great word.
		if (!isOneTimeTrigger && triggeringObjectCount <= 0)
		{
			for (int i = 0; i < thingsToActivate.Length; i++)
			{
				thingsToActivate[i].Deactivate();
			}
			isTriggered = false;
			targetLocation.y = originalLoc.y;
		}
	}

	void Start()
	{
		originalLoc = this.transform.position;
		targetLocation = originalLoc;
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
		}
	}

	void OnCollisionEnter(Collision other)
	{
		print ("collision enter with " + other.gameObject.name);
		Trigger();
	}

	void OnTriggerEnter(Collider other)
	{
		print ("trigger enter with " + other.gameObject.name);
		Trigger();
	}

	void OnCollisionExit(Collision other)
	{
		print ("collision exit with " + other.gameObject.name);
		UnTrigger();
	}

	void OnTriggerExit(Collider other)
	{
		print ("trigger exit with " + other.gameObject.name);
		UnTrigger();
	}
}
