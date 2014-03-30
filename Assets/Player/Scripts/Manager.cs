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
			if(Input.GetButtonDown("Interact"))
			{
				hitInfo.transform.gameObject.GetComponent<Interactable>().Interact(this.playerCamera.GetComponentInChildren<Rigidbody>().transform);
			}
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.tag.Equals("CollisionKill"))
		{
			print ("kill me! I collided with a collisionKill object");
			//Kill()
		}
	}
}
