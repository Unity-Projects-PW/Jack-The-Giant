using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

	[HideInInspector]
	public int score, coinScore, lifeScore;

	void Awake()
	{
		MakeSingleton ();
	}


	void Start()
	{
		InitializeVariables();
	}

	void InitializeVariables()
	{
		if (!PlayerPrefs.HasKey("Game Initialized"))
		{
			GamePreferences.SetEasyDifficultyState(0);
			GamePreferences.SetEasyDifficultyHighscore(0);
			GamePreferences.SetEasyDifficultyCoinScore(0);

			GamePreferences.SetMediumDifficultyState(1);
			GamePreferences.SetMediumDifficultyHighscore(0);
			GamePreferences.SetMediumDifficultyCoinScore(0);

			GamePreferences.SetHardDifficultyState(0);
			GamePreferences.SetHardDifficultyHighscore(0);
			GamePreferences.SetHardDifficultyCoinScore(0);

			GamePreferences.SetMusicState(0);
		
			PlayerPrefs.SetInt("Game Initialized", 123);
		}
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		if( scene.name == "Gameplay")
		{
			if( gameRestartedAfterPlayerDied )
			{
				GameplayController.instance.SetScore (score);
				GameplayController.instance.SetCoinScore (coinScore);
				GameplayController.instance.SetLifeScore (lifeScore);

				PlayerScore.scoreCount = score;
				PlayerScore.coinCount = coinScore;
				PlayerScore.lifeCount = lifeScore;
			} else if( gameStartedFromMainMenu )
			{
				PlayerScore.scoreCount = 0;
				PlayerScore.coinCount = 0;
				PlayerScore.lifeCount = 2;

				GameplayController.instance.SetScore (0);
				GameplayController.instance.SetCoinScore (0);
				GameplayController.instance.SetLifeScore (2);
			}
		}
	}
		

	void MakeSingleton()
	{
		if( instance != null )
		{
			Destroy (gameObject);
		} else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void CheckGameStatus(int score, int coinScore, int lifeScore)
	{
		if(lifeScore < 0)
		{
			CheckForNewHighScores();

			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDied = false;

			GameplayController.instance.GameOverShowPanel(score, coinScore);
			// 
		} else {
			this.score = score;
			this.coinScore = coinScore;
			this.lifeScore = lifeScore;

			GameplayController.instance.SetScore(score);
			GameplayController.instance.SetCoinScore(coinScore);
			GameplayController.instance.SetLifeScore(lifeScore);

			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDied = true;

			GameplayController.instance.PlayerDiedRestartTheGame();
		}
	}

	void CheckForNewHighScores()
	{
		if (GamePreferences.GetEasyDifficultyState() == 1)
		{
			int highScore = GamePreferences.GetEasyDifficultyHighscore();
			int coin = GamePreferences.GetEasyDifficultyCoinScore();

			if (highScore < score)
			{
				GamePreferences.SetEasyDifficultyHighscore(score);
			}
			if (coin < coinScore)
			{
				GamePreferences.SetEasyDifficultyCoinScore(coinScore);
			}
		}

		if (GamePreferences.GetMediumDifficultyState() == 1)
		{
			int highScore = GamePreferences.GetMediumDifficultyHighscore();
			int coin = GamePreferences.GetMediumDifficultyCoinScore();

			if (highScore < score)
			{
				GamePreferences.SetMediumDifficultyHighscore(score);
			}
			if (coin < coinScore)
			{
				GamePreferences.SetMediumDifficultyCoinScore(coinScore);
			}
		}

		if (GamePreferences.GetHardDifficultyState() == 1)
		{
			int highScore = GamePreferences.GetHardDifficultyHighscore();
			int coin = GamePreferences.GetHardDifficultyCoinScore();

			if (highScore < score)
			{
				GamePreferences.SetHardDifficultyHighscore(score);
			}
			if (coin < coinScore)
			{
				GamePreferences.SetHardDifficultyCoinScore(coinScore);
			}
		}

	}
}

