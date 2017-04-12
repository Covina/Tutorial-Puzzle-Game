using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPuzzleGame : MonoBehaviour {

	[SerializeField] private LayoutPuzzleButtons layoutPuzzleButtons;

	// the Puzzle level selection panel
	[SerializeField] private GameObject puzzleLevelSelectPanel;

	// Animator to slide in/out the puzzle level selection panel
	[SerializeField] private Animator puzzleLevelSelectAnimator;

	// The five different GAME panels
	[SerializeField] private GameObject puzzleGamePanel1, puzzleGamePanel2, puzzleGamePanel3, puzzleGamePanel4, puzzleGamePanel5;

	// The five GAME animators
	[SerializeField] private Animator puzzleGameAnimator1, puzzleGameAnimator2, puzzleGameAnimator3, puzzleGameAnimator4, puzzleGameAnimator5;

	// Store which puzzle level we are currently on
	private int puzzleLevel;

	// store the string name of the selected Puzzle
	private string selectedPuzzle;


	// Load the puzzle level
	public void LoadPuzzle (int level, string puzzle)
	{

		// set the PUZZLE
		this.selectedPuzzle = puzzle;

		// set the LEVEL
		this.puzzleLevel = level;

		layoutPuzzleButtons.LayoutButtons(level, selectedPuzzle);

		// Load the chosen GAME panel
		switch (puzzleLevel) {

		case 0:
			StartCoroutine( LoadPuzzleGamePanel(puzzleGamePanel1, puzzleGameAnimator1) );
			break;

		case 1:
			StartCoroutine( LoadPuzzleGamePanel(puzzleGamePanel2, puzzleGameAnimator2) );
			break;

		case 2:
			StartCoroutine( LoadPuzzleGamePanel(puzzleGamePanel3, puzzleGameAnimator3) );
			break;

		case 3:
			StartCoroutine( LoadPuzzleGamePanel(puzzleGamePanel4, puzzleGameAnimator4) );
			break;

		case 4:
			StartCoroutine( LoadPuzzleGamePanel(puzzleGamePanel5, puzzleGameAnimator5) );
			break;

		}


	}

	// return to Level Select menu
	public void BackToPuzzleLevelSelectMenu ()
	{

		// Load the chosen LEVEL select menu
		switch (puzzleLevel) {

		case 0:
			StartCoroutine( LoadPuzzleLevelSelectMenu(puzzleGamePanel1, puzzleGameAnimator1) );
			break;

		case 1:
			StartCoroutine( LoadPuzzleLevelSelectMenu(puzzleGamePanel2, puzzleGameAnimator2) );
			break;

		case 2:
			StartCoroutine( LoadPuzzleLevelSelectMenu(puzzleGamePanel3, puzzleGameAnimator3) );
			break;

		case 3:
			StartCoroutine( LoadPuzzleLevelSelectMenu(puzzleGamePanel4, puzzleGameAnimator4) );
			break;

		case 4:
			StartCoroutine( LoadPuzzleLevelSelectMenu(puzzleGamePanel5, puzzleGameAnimator5) );
			break;

		}



	}

	// Load the LEVEL select menu
	IEnumerator LoadPuzzleLevelSelectMenu (GameObject puzzleGamePanel, Animator puzzleGamePanelAnim)
	{
		// Activate the LEVEL panel
		puzzleLevelSelectPanel.SetActive(true);

		// slide out the GAME panel
		puzzleGamePanelAnim.Play("SlideOut");

		// slide in the LEVEL select
		puzzleLevelSelectAnimator.Play("SlideIn");

		// wait 
		yield return new WaitForSeconds(1f);

		// set the GAME panel to active
		puzzleGamePanel.SetActive(false);

	}

	// Load the actual GAME panel
	IEnumerator LoadPuzzleGamePanel (GameObject puzzleGamePanel, Animator puzzleGamePanelAnim)
	{
		// set the GAME panel to active
		puzzleGamePanel.SetActive(true);

		// slide in the GAME panel
		puzzleGamePanelAnim.Play("SlideIn");

		// slide out the LEVEL select
		puzzleLevelSelectAnimator.Play("SlideOut");

		// wait 
		yield return new WaitForSeconds(1f);

		// deactivate the LEVEL panel
		puzzleLevelSelectPanel.SetActive(false);


	}


}
