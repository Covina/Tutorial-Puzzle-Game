﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutPuzzleButtons : MonoBehaviour {


	public List<Button> level1Buttons, level2Buttons, level3Buttons, level4Buttons, level5Buttons;

	public List<Animator> level1Animator, level2Animator, level3Animator, level4Animator, level5Animator;

	[SerializeField] private Transform puzzleLevel1, puzzleLevel2, puzzleLevel3, puzzleLevel4, puzzleLevel5;

	[SerializeField] private Sprite[] puzzleButtonsBackSideImages;



	// hold which LEVEL is selected
	private int puzzleLevel;

	// hold which PUZZLE is selected
	private string selectedPuzzle;


	public void LayoutButtons (int level, string puzzle)
	{
		this.puzzleLevel = level;
		this.selectedPuzzle = puzzle;

		LayoutPuzzle();

	}


	public void LayoutPuzzle ()
	{
		switch (puzzleLevel) {

		// Activate the level chosen buttons 
		case 0:

			
			foreach (Button btn in level1Buttons) {

				if (!btn.gameObject.activeInHierarchy) {

					btn.gameObject.SetActive (true);
					btn.gameObject.transform.SetParent (puzzleLevel1, false);

					if (selectedPuzzle == "Candy Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[0];
					} else if (selectedPuzzle == "Transport Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[1];
					} else if (selectedPuzzle == "Fruit Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[2];
					}


				}

			}

			break;

		// Activate the level chosen buttons
		case 1:

			
			foreach (Button btn in level2Buttons) {

				if (!btn.gameObject.activeInHierarchy) {

					btn.gameObject.SetActive (true);
					btn.gameObject.transform.SetParent (puzzleLevel2, false);

					if (selectedPuzzle == "Candy Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[0];
					} else if (selectedPuzzle == "Transport Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[1];
					} else if (selectedPuzzle == "Fruit Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[2];
					}


				}

			}

			break;

		// Activate the level chosen buttons
		case 2:

			
			foreach (Button btn in level3Buttons) {

				if (!btn.gameObject.activeInHierarchy) {

					btn.gameObject.SetActive (true);
					btn.gameObject.transform.SetParent (puzzleLevel3, false);

					if (selectedPuzzle == "Candy Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[0];
					} else if (selectedPuzzle == "Transport Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[1];
					} else if (selectedPuzzle == "Fruit Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[2];
					}


				}

			}

			break;

		// Activate the level chosen buttons
		case 3:

			
			foreach (Button btn in level4Buttons) {

				if (!btn.gameObject.activeInHierarchy) {

					btn.gameObject.SetActive (true);
					btn.gameObject.transform.SetParent (puzzleLevel4, false);

					if (selectedPuzzle == "Candy Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[0];
					} else if (selectedPuzzle == "Transport Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[1];
					} else if (selectedPuzzle == "Fruit Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[2];
					}


				}

			}

			break;

		// Activate the level chosen buttons
		case 4:

			
			foreach (Button btn in level5Buttons) {

				if (!btn.gameObject.activeInHierarchy) {

					btn.gameObject.SetActive (true);
					btn.gameObject.transform.SetParent (puzzleLevel5, false);

					if (selectedPuzzle == "Candy Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[0];
					} else if (selectedPuzzle == "Transport Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[1];
					} else if (selectedPuzzle == "Fruit Puzzle") {
						btn.image.sprite = puzzleButtonsBackSideImages[2];
					}


				}

			}

			break;


		} // end switch

	}




}