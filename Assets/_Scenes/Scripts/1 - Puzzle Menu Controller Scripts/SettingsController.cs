using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour {


	[SerializeField] private GameObject settingsPanel;

	[SerializeField] private Animator animator;



	public void OpenSettingsPanel()
	{
		// Activate the settings menu
		settingsPanel.SetActive(true);

		// play the fade-in animation
		animator.Play("Settings - Slide In");

	}

	public void CloseSettingsPanel()
	{
		StartCoroutine( CloseSettings() );
	}


	IEnumerator CloseSettings ()
	{
		// play the slide out animation
		animator.Play("Settings - Slide Out");

		// pause for a second to let the animation play
		yield return new WaitForSeconds(1.0f);

		// deactivate the panel
		settingsPanel.SetActive(false);


	}




}
