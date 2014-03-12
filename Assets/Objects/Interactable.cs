using UnityEngine;
using System.Collections;

public abstract class Interactable : MonoBehaviour {
	public virtual void Interact(Transform interactor)
	{
		print (name + " has been interacted with!");
	}
}
