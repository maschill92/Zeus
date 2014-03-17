using UnityEngine;
using System.Collections;

public class PressureSwitch : MonoBehaviour 
{
	public Activatable[] thingsToActivate;
	private bool isTriggered = false;

	public void Trigger()
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
}
