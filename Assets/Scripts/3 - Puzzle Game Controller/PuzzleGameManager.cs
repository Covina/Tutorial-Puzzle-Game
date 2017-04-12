using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour {


	private List<Button> puzzleButtons = new List<Button>();

	private List<Animator> puzzleButtonsAnimators = new List<Animator>();

	private List<Sprite> gamePuzzleSprites = new List<Sprite>();

	private int level;
	private string selectedPuzzle;

	private Sprite puzzleBackgroundImage;

	private bool firstGuess, secondGuess;
	private int firstGuessIndex, secondGuessIndex;
	private string firstGuessImageName, secondGuessImageName;


	public void PickAPuzzle ()
	{

		if (!firstGuess) {
			firstGuess = true;

			firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			// get the name of the first guess
			firstGuessImageName = gamePuzzleSprites[firstGuessIndex].name;

			StartCoroutine( TurnPuzzleButtonUp (puzzleButtonsAnimators[firstGuessIndex], puzzleButtons[firstGuessIndex], gamePuzzleSprites[firstGuessIndex]) );

		} else if (!secondGuess) {
			secondGuess = true;

			secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			// get the name of the second guess
			secondGuessImageName = gamePuzzleSprites[secondGuessIndex].name;

			StartCoroutine( TurnPuzzleButtonUp (puzzleButtonsAnimators[secondGuessIndex], puzzleButtons[secondGuessIndex], gamePuzzleSprites[secondGuessIndex]) );
		

		}

		// check if the two guesses match
		StartCoroutine( CheckIfGuessesMatch (puzzleBackgroundImage) );

	}

	IEnumerator CheckIfGuessesMatch (Sprite bgimage)
	{
		yield return new WaitForSeconds (1.7f);

		if (firstGuessImageName == secondGuessImageName) {
			// correct guess

			puzzleButtonsAnimators [firstGuessIndex].Play ("FadeOut");
			puzzleButtonsAnimators [secondGuessIndex].Play ("FadeOut");

			// TODO - increment score
		} else {
			// incorrect guess

			// flip first one back
			StartCoroutine( TurnPuzzleButtonBack (puzzleButtonsAnimators[firstGuessIndex], puzzleButtons[firstGuessIndex], bgimage) );

			// flip second one back
			StartCoroutine( TurnPuzzleButtonBack (puzzleButtonsAnimators[secondGuessIndex], puzzleButtons[secondGuessIndex], bgimage) );

		}

		// wait some 
		yield return new WaitForSeconds(.7f);

		// reset our guess bools
		firstGuess = false;
		secondGuess = false;


	}



	IEnumerator TurnPuzzleButtonUp (Animator anim, Button btn, Sprite puzzleImage)
	{
		
		anim.Play("TurnUp");

		yield return new WaitForSeconds(0.5f);

		btn.image.sprite = puzzleImage;


	}

	IEnumerator TurnPuzzleButtonBack (Animator anim, Button btn, Sprite puzzleImage)
	{
		
		anim.Play("TurnBack");

		yield return new WaitForSeconds(0.5f);

		btn.image.sprite = puzzleImage;


	}


	void AddListeners ()
	{
		foreach (Button btn in puzzleButtons) {

			// remove any potential listers
			btn.onClick.RemoveAllListeners();

			// add the onclick event PickAPuzzle()
			btn.onClick.AddListener( () => PickAPuzzle() );

		}


	}

	public void SetUpButtonsAndAnimators (List<Button> buttons, List<Animator> animators)
	{
		this.puzzleButtons = buttons;
		this.puzzleButtonsAnimators = animators;

		puzzleBackgroundImage = puzzleButtons[0].image.sprite;

		AddListeners();
	}


	public void SetGamePuzzleSprites (List<Sprite> gamePuzzleSprites)
	{
		this.gamePuzzleSprites = gamePuzzleSprites;

	}

	public void SetLevel (int level)
	{
		this.level = level;
	}

	public void SetSelectedPuzzle (string selectedPuzzle)
	{
		this.selectedPuzzle = selectedPuzzle;

	}

}
