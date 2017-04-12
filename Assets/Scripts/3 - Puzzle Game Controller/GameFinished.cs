using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinished : MonoBehaviour {


	[SerializeField] private GameObject gameFinishedPanel;

	[SerializeField] private Animator gameFinishedAnim, star1Anim, star2Anim, star3Anim, textAnim;


	// Display the panel!
	public void ShowGameFinishedPanel (int stars)
	{
		StartCoroutine( ShowPanel(stars) );
	}

	// hide the panel
	public void HideGameFinishedPanel ()
	{
		if (gameFinishedPanel.activeInHierarchy) {

			StartCoroutine ( HidePanel() );

		}
	}


	IEnumerator ShowPanel (int stars)
	{

		// activate the panel
		gameFinishedPanel.SetActive (true);
		
		gameFinishedAnim.Play ("FadeIn");

		// pause
		yield return new WaitForSeconds (1.7f);


		// Depending on the stars, animate stars with interval delay;
		switch (stars) {

		case 1:
			star1Anim.Play ("FadeIn");
			yield return new WaitForSeconds (.25f);

			textAnim.Play ("FadeIn");

			break;

		case 2:
			star1Anim.Play ("FadeIn");
			yield return new WaitForSeconds (.25f);

			star2Anim.Play ("FadeIn");
			yield return new WaitForSeconds (.25f);

			textAnim.Play ("FadeIn");

			break;

		case 3:
			star1Anim.Play ("FadeIn");
			yield return new WaitForSeconds (.25f);

			star2Anim.Play ("FadeIn");
			yield return new WaitForSeconds (.25f);

			star3Anim.Play ("FadeIn");
			yield return new WaitForSeconds (.25f);

			textAnim.Play ("FadeIn");

			break;

		}


	}


	IEnumerator HidePanel ()
	{

		gameFinishedAnim.Play("FadeOut");

		star1Anim.Play("FadeOut");
		star2Anim.Play("FadeOut");
		star3Anim.Play("FadeOut");

		textAnim.Play("FadeOut");

		yield return new WaitForSeconds(1.5f);

		// deactivate the panel
		gameFinishedPanel.SetActive(false);



	}



}
