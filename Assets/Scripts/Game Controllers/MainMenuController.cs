using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour {



	public Button musicButton;
	public Sprite[] musicIcons;

	// Use this for initialization
	void Start () {
		CheckIfMusicIsOnOrOff();
	}

	void CheckIfMusicIsOnOrOff() {
		if (GamePreferences.GetMusicState () == 0) {
			if (MusicController.instance != null) {
				MusicController.instance.PlayMusic (true);
			}
			musicButton.image.sprite = musicIcons[0];
		} else {
			musicButton.image.sprite = musicIcons[1];
		}
	}
	
	public void StartGame()
	{
		GameManager.instance.gameStartedFromMainMenu = true;
		SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
	}

	public void Options()
	{
		SceneManager.LoadScene("OptionsMenu", LoadSceneMode.Single);
	}

	public void Highscore()
	{
		SceneManager.LoadScene("HighScoreMenu", LoadSceneMode.Single);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void Music()
	{
		if (GamePreferences.GetMusicState() == 0)
		{
			
			musicButton.image.sprite = musicIcons[1];
			GamePreferences.SetMusicState(1);
			if (MusicController.instance != null)
			{
				MusicController.instance.PlayMusic(false);
			} 
		} else {
			
			musicButton.image.sprite = musicIcons [0];
			GamePreferences.SetMusicState(0);
			if (MusicController.instance != null)
			{
				MusicController.instance.PlayMusic(true);
			} 
		}

	}

	public void ReturnToStart()
	{
		SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
	}
}
