using UnityEngine;
using System.Collections;

public class PressureSwitch : MonoBehaviour 
{
	public Activatable[] thingsToActivate;
	public bool isOneTimeTrigger = false; 	// true means that the switch can be triggered on, then off, then on...
	private bool isTriggered = false; 		// is the switch currently triggered?

	private void Trigger()
	{
		if (!isTriggered)
		{
			for(int i = 0; i < thingsToActivate.Length; i++)
			{
				thingsToActivate[i].Activate();
			}
			
			// ANIMATE NOW
		}
		isTriggered = true;
	}

	private void UnTrigger()
	{
		// UnTrigger... great word.
		if (!isOneTimeTrigger)
		{
			for (int i = 0; i < thingsToActivate.Length; i++)
			{
				thingsToActivate[i].Deactivate();
			}
			isTriggered = false;
			// ANIMATE NOW
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
