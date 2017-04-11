using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour {

	[SerializeField]
	private LoadPuzzleGame loadPuzzleGame;

	[SerializeField]
	private GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;

	[SerializeField]
	private Animator selectPuzzleMenuAnimator, puzzleLevelSelectAnimator;


	private string selectedPuzzle;


	public void BackToPuzzleSelectMenu() 
	{

		StartCoroutine ( ShowPuzzleSelectMenu() );

	}


	public void SelectPuzzleLevel ()
	{

		// convert the number-named GameObject into an integer
		int level = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

		// Load the appropriate puzzle LEVEL panel
		loadPuzzleGame.LoadPuzzle(level, selectedPuzzle);

	}




	// Move level select out, return to world menu
	IEnumerator ShowPuzzleSelectMenu ()
	{

		// activate the main menu panel
		selectPuzzleMenuPanel.SetActive(true);

		// slide out the level select panel
		puzzleLevelSelectAnimator.Play("SlideOut");

		// delay
		yield return new WaitForSeconds(1f);

		// slide in the main menu
		selectPuzzleMenuAnimator.Play("SlideIn");

		// deactivate level select panel
		puzzleLevelSelectPanel.SetActive(false);
	}

	// Set the Selected Puzzle
	public void SetSelectedPuzzle(string a)
	{
		this.selectedPuzzle = a;
		Debug.Log("The selected PUZZLE is [" + a + "]");
	}
}
