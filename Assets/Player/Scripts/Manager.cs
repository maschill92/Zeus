using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
	private Camera playerCamera;
	public float interactDistance = 1.25f;
	public LayerMask layerMask;
	void Start()
	{
		playerCamera = GetComponentInChildren<Camera>();
	}

	void Update()
	{
		RaycastHit hitInfo;
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactDistance, layerMask))
		{
			print ("hit something at " + hitInfo.distance);
		}
	}

	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 0.1f, 0.1f), "");
	}
}
