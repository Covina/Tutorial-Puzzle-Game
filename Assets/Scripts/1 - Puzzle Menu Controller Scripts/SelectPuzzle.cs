using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPuzzle : MonoBehaviour {

	// store the selected level 1-5
	[SerializeField] private SelectLevel selectLevel;

	// 
	[SerializeField] private GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;

	// 
	[SerializeField] private Animator selectPuzzleMenuAnimator, puzzleLevelSelectAnimator;


	private string selectedPuzzle;


	public void SelectedPuzzle() 
	{
		// capture the name of the button that is clicked on
		selectedPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		// pass the name to set the selected Puzzle
		selectLevel.SetSelectedPuzzle(selectedPuzzle);

		StartCoroutine( ShowPuzzleLevelSelectMenu() );
		

	}

	// Move world out, bring in level menu
	IEnumerator ShowPuzzleLevelSelectMenu ()
	{
		// activate the panel
		puzzleLevelSelectPanel.SetActive(true);

		// slide out main menu
		selectPuzzleMenuAnimator.Play("SlideOut");

		// delay
		yield return new WaitForSeconds(1f);

		// slide in the level select
		puzzleLevelSelectAnimator.Play("SlideIn");

		// deactivate main menu panel
		selectPuzzleMenuPanel.SetActive(false);


	}



}
