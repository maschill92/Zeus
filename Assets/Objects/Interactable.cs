using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {
	public virtual void Interact(Transform interactor)
	{
		print (name + " has been interacted with!");
	}
}
