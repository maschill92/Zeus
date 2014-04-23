using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DeathOnContact : MonoBehaviour {
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Manager>().Kill();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Manager>().Kill();
        }
    }
}
