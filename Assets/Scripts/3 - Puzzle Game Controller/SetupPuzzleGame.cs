using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupPuzzleGame : MonoBehaviour {

	// init the sprite array for all the sprites in each game
	private Sprite[] candyPuzzleSprites, transportPuzzleSprites, fruitPuzzleSprites;

	// hold the sprite objects for the selected LEVEL
	private List<Sprite> gamePuzzles = new List<Sprite>();

	// list of all the buttons
	private List<Button> puzzleButtons = new List<Button>();

	// list for all the animators
	private List<Animator> puzzleButtonAnimators = new List<Animator>();
	
	private int level;
	private string selectedPuzzle;

	private int looper;

	void Awake ()
	{

		// Load all the sprite objects directly from the Sprite file in the folder

		// Populate all Candy Game sprites
		candyPuzzleSprites = Resources.LoadAll<Sprite>("Game Assets/Candy");

		// Populate all Transportation game sprites
		transportPuzzleSprites = Resources.LoadAll<Sprite>("Game Assets/Transport");

		// Populate all Fruit Game sprites
		fruitPuzzleSprites = Resources.LoadAll<Sprite>("Game Assets/Fruits");

	}


	void PrepareGameSprites ()
	{

		// clear out any possible leftover puzzle pieces.
		gamePuzzles.Clear ();
		gamePuzzles = new List<Sprite> ();

		int index = 0;


		// Depending on which level selected, set the total number of memory cards
		switch (level) {

		case 0:
			looper = 6;
			break;

		case 1:
			looper = 12;
			break;

		case 2:
			looper = 18;
			break;

		case 3:
			looper = 24;
			break;

		case 4:
			looper = 30;
			break;

		} // end switch


		switch (selectedPuzzle) {

		case "Candy Puzzle":

			for (int i = 0; i < looper; i++) {

				// Ensure we repeat the images twice since its a memory game.
				if (index == (looper / 2)) {

					// we've rached the halfway mark, reset to loop through sprites a second time.
					index = 0;
				}

				// Load up the sprites
				gamePuzzles.Add( candyPuzzleSprites[index] );
				index++;

			}


			break;

		case "Transport Puzzle":

			for (int i = 0; i < looper; i++) {

				// Ensure we repeat the images twice since its a memory game.
				if (index == (looper / 2)) {

					// we've rached the halfway mark, reset to loop through sprites a second time.
					index = 0;
				}

				// Load up the sprites
				gamePuzzles.Add( transportPuzzleSprites[index] );
				index++;

			}

			break;

		case "Fruit Puzzle":

			for (int i = 0; i < looper; i++) {

				// Ensure we repeat the images twice since its a memory game.
				if (index == (looper / 2)) {

					// we've rached the halfway mark, reset to loop through sprites a second time.
					index = 0;
				}

				// Load up the sprites
				gamePuzzles.Add( fruitPuzzleSprites[index] );
				index++;


			}
			break;


		} // end switch


//		Shuffle(gamePuzzles);


	}


	// Shuffling function
	void Shuffle (List<Sprite> list)
	{
		for (int i = 0; i < list.Count; i++) {

			// store current item
			Sprite tmp = list[i];

			// roll random
			int rnd = Random.Range(i, list.Count);

			// assign current index to random item
			list[i] = list[rnd];

			// place original item in the random index position
			list[rnd] = tmp;

		}

	}


	public void SetLevelandPuzzle (int level, string selectedPuzzle)
	{
		this.level = level;
		this.selectedPuzzle = selectedPuzzle;

		PrepareGameSprites();

	}

	public void SetPuzzleButtonsAndAnimators(List<Button> puzzButtons, List<Animator> puzzButtonsAnims)
	{

		this.puzzleButtons = puzzButtons;
		this.puzzleButtonAnimators = puzzButtonsAnims;


	}

}
