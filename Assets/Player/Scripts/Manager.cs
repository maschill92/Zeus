using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
	private Camera playerCamera;
	public float interactDistance = 1.25f;
	public LayerMask layerMask;
    public Checkpoint lastCheckpoint;

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
    
    public void Reset()
    {
        transform.position = lastCheckpoint.transform.position;
    }

    public void Kill()
    {
        FindObjectOfType<menuDeath>().killPlayer();
    }
}
