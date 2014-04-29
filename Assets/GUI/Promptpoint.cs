using UnityEngine;
using System.Collections;

public class Promptpoint : MonoBehaviour {

	public string promptType = "";
	private bool shownInteract = false;
	private bool shownSprint = false;
	private bool shownJump = false;
	private bool shownKey = false;
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			if (promptType.Equals ("Interact") && shownInteract == false) {
				shownInteract = true;
				FindObjectOfType<guiPrompt>().ActivateInteractPrompt ();
			}
			if (promptType.Equals ("Sprint") && shownSprint == false) {
				shownSprint = true;
				FindObjectOfType<guiPrompt>().ActivateSprintPrompt();
			}
			if (promptType.Equals ("Jump") && shownJump == false) {
				shownJump = true;
				FindObjectOfType<guiPrompt>().ActivateJumpPrompt();
			}
			if (promptType.Equals ("Key") && shownKey == false) {
				shownKey = true;
				FindObjectOfType<guiPrompt>().ActivateKeyPrompt();
			}
		}
	}
}