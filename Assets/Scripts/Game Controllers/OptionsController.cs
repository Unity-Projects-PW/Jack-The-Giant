using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{

	[SerializeField]
	private GameObject easySign, mediumSign, hardSign;

	// Use this for initialization
	void Start()
	{
		SetTheDiffculty ();
	}

	void SetInitialDiffculty(string difficulty)
	{
		switch (difficulty)
		{
		case "easy":
			mediumSign.SetActive (false);
			hardSign.SetActive (false);
			break;
		case "medium":
			easySign.SetActive (false);
			hardSign.SetActive (false);
			break;
		case "hard":
			easySign.SetActive (false);
			mediumSign.SetActive (false);
			break;
		}
	}


	void SetTheDiffculty()
	{
		if( GamePreferences.GetEasyDifficultyState () == 1 )
		{
			SetInitialDiffculty ("easy");
		}
		if( GamePreferences.GetMediumDifficultyState () == 1 )
		{
			SetInitialDiffculty ("medium");
		}
		if( GamePreferences.GetHardDifficultyState () == 1 )
		{
			SetInitialDiffculty ("hard");
		}
	}

	public void EasyDiffculty()
	{
		GamePreferences.SetEasyDifficultyState (1);
		GamePreferences.SetMediumDifficultyState (0);
		GamePreferences.SetHardDifficultyState (0);
		easySign.SetActive (true);
		mediumSign.SetActive (false);
		hardSign.SetActive (false);
	}

	public void MediumDiffculty()
	{
		GamePreferences.SetEasyDifficultyState (0);
		GamePreferences.SetMediumDifficultyState (1);
		GamePreferences.SetHardDifficultyState (0);
		easySign.SetActive (false);
		mediumSign.SetActive (true);
		hardSign.SetActive (false);
	}

	public void HardDiffculty()
	{
		GamePreferences.SetEasyDifficultyState (0);
		GamePreferences.SetMediumDifficultyState (0);
		GamePreferences.SetHardDifficultyState (1);
		easySign.SetActive (false);
		mediumSign.SetActive (false);
		hardSign.SetActive (true);
	}
		
}
