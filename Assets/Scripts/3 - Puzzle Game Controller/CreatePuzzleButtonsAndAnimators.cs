using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePuzzleButtonsAndAnimators : MonoBehaviour {

	// The puzzle button object prefab
	[SerializeField] private Button puzzleButton;

	// How many buttons will the game have
	private int puzzleGame1 = 6;
	private int puzzleGame2 = 12;
	private int puzzleGame3 = 18;
	private int puzzleGame4 = 24;
	private int puzzleGame5 = 30;

	// List for the level Buttons
	private List<Button> level1Buttons = new List<Button>();
	private List<Button> level2Buttons = new List<Button>();
	private List<Button> level3Buttons = new List<Button>();
	private List<Button> level4Buttons = new List<Button>();
	private List<Button> level5Buttons = new List<Button>();

	// List for the level Animators
	private List<Animator> level1Animators = new List<Animator>();
	private List<Animator> level2Animators = new List<Animator>();
	private List<Animator> level3Animators = new List<Animator>();
	private List<Animator> level4Animators = new List<Animator>();
	private List<Animator> level5Animators = new List<Animator>();




	void Awake ()
	{
		// create the buttons
		CreateButtons();

		// Then create the animators;  BUTTONS MUST BE FIRST
		GetAnimators();

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Create and populate the Button Lists
	private void CreateButtons ()
	{

		// Game 1
		for (int i = 0; i < puzzleGame1; i++) {

			// Instantiate the prefab button
			Button btn = Instantiate(puzzleButton);

			// Rename the new GameObject button
			btn.gameObject.name = i.ToString();

			// Add it to the List
			level1Buttons.Add(btn);

		}

		// Game 2
		for (int i = 0; i < puzzleGame2; i++) {

			// Instantiate the prefab button
			Button btn = Instantiate(puzzleButton);

			// Rename the new GameObject button
			btn.gameObject.name = i.ToString();

			// Add it to the List
			level2Buttons.Add(btn);

		}

		// Game 3
		for (int i = 0; i < puzzleGame3; i++) {

			// Instantiate the prefab button
			Button btn = Instantiate(puzzleButton);

			// Rename the new GameObject button
			btn.gameObject.name = i.ToString();

			// Add it to the List
			level3Buttons.Add(btn);

		}

		// Game 4
		for (int i = 0; i < puzzleGame4; i++) {

			// Instantiate the prefab button
			Button btn = Instantiate(puzzleButton);

			// Rename the new GameObject button
			btn.gameObject.name = i.ToString();

			// Add it to the List
			level4Buttons.Add(btn);

		}

		// Game 5
		for (int i = 0; i < puzzleGame5; i++) {

			// Instantiate the prefab button
			Button btn = Instantiate(puzzleButton);

			// Rename the new GameObject button
			btn.gameObject.name = i.ToString();

			// Add it to the List
			level5Buttons.Add(btn);

		}

	}


	// Loop through buttons and pull the animator component
	private void GetAnimators ()
	{
		// Get the animator component off each prefab object
		for (int i = 0; i < level1Buttons.Count; i++) {
			// get the animator;
			level1Animators.Add( level1Buttons[i].gameObject.GetComponent<Animator>() );

			// Deactivate the buttons until we load the game panel
			level1Buttons[i].gameObject.SetActive(false);
		}

		// Get the animator component off each prefab object
		for (int i = 0; i < level2Buttons.Count; i++) {
			// get the animator;
			level2Animators.Add( level2Buttons[i].gameObject.GetComponent<Animator>() );

			// Deactivate the buttons until we load the game panel
			level2Buttons[i].gameObject.SetActive(false);
		}

		// Get the animator component off each prefab object
		for (int i = 0; i < level3Buttons.Count; i++) {
			// get the animator;
			level3Animators.Add( level3Buttons[i].gameObject.GetComponent<Animator>() );

			// Deactivate the buttons until we load the game panel
			level3Buttons[i].gameObject.SetActive(false);
		}

		// Get the animator component off each prefab object
		for (int i = 0; i < level4Buttons.Count; i++) {
			// get the animator;
			level4Animators.Add( level4Buttons[i].gameObject.GetComponent<Animator>() );

			// Deactivate the buttons until we load the game panel
			level4Buttons[i].gameObject.SetActive(false);
		}

		// Get the animator component off each prefab object
		for (int i = 0; i < level5Buttons.Count; i++) {
			// get the animator;
			level5Animators.Add( level5Buttons[i].gameObject.GetComponent<Animator>() );

			// Deactivate the buttons until we load the game panel
			level5Buttons[i].gameObject.SetActive(false);
		}



	}



}
