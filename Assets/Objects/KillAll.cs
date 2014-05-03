using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class KillAll : MonoBehaviour {
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.transform.root.GetComponent<Manager>().Kill ();
		}
		else
			Destroy (other.gameObject);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.transform.root.GetComponent<Manager>().Kill ();
		}
		else
			Destroy (other.gameObject);
	}
}
