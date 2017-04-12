using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour {

	private GameFinished gameFinished;

	private List<Button> puzzleButtons = new List<Button>();

	private List<Animator> puzzleButtonsAnimators = new List<Animator>();

	private List<Sprite> gamePuzzleSprites = new List<Sprite>();

	private int level;
	private string selectedPuzzle;

	private Sprite puzzleBackgroundImage;

	private bool firstGuess, secondGuess;
	private int firstGuessIndex, secondGuessIndex;
	private string firstGuessImageName, secondGuessImageName;


	private int countTryGuesses;
	private int countCorrectGuesses;
	private int gameGuess;



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

			// increment total guesses
			countTryGuesses++;


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

			// Increment score
			CheckIfGameFinished ();

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


	public List<Animator> ResetGameplay ()
	{

		firstGuess = secondGuess = false;
		countTryGuesses = 0;
		countCorrectGuesses = 0;

		gameFinished.HideGameFinishedPanel();

		return puzzleButtonsAnimators;

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

	void CheckIfGameFinished ()
	{
		countCorrectGuesses++;

		// correct guesses matches the Game's pairs, game is over;  dislpay game finished panel
		if (countCorrectGuesses == gameGuess) {

			CheckHowManyGuesses();
			

		}

	}


	void CheckHowManyGuesses ()
	{
		int howManyGuesses = 0;

		switch (level) {

		case 0:
			howManyGuesses = 5;
			break;
		case 1:
			howManyGuesses = 10;
			break;
		case 2:
			howManyGuesses = 15;
			break;
		case 3:
			howManyGuesses = 20;
			break;
		case 4:
			howManyGuesses = 25;
			break;

		}


		// determine how many stars now, comparing guesses to thresholds
		if (countTryGuesses < howManyGuesses) {
			// three stars
			gameFinished.ShowGameFinishedPanel (3);
		} else if (countTryGuesses < (howManyGuesses + 5)) {
			gameFinished.ShowGameFinishedPanel (2);
		} else {
			gameFinished.ShowGameFinishedPanel(1);
		}



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

		// set minimum guesses required to beat level
		gameGuess = puzzleButtons.Count / 2;

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
