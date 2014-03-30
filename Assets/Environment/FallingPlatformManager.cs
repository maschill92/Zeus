using UnityEngine;
using System.Collections;

public class FallingPlatformManager : MonoBehaviour {

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.M))
		{
			Reset ();
		}
	}

	public void Reset()
	{
		FallingPlatform[] allPlatforms = GameObject.FindObjectsOfType<FallingPlatform>();
		for (int i = 0; i < allPlatforms.Length; i++)
		{
			allPlatforms[i].Reset();
		}
	}
}
