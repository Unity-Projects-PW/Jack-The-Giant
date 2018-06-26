using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameplayController : MonoBehaviour
{

	public static GameplayController instance;

	public Text coinText, lifeText, gameOverScoreText, gameOverCoinText;
	public Text scoreText;
	public Text timerText;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel;

	[SerializeField]
	private GameObject readyButton;

	// Use this for initialization
	void Awake()
	{
		MakeInstance ();
	}

	void Start()
	{
		Time.timeScale = 0f;
	}

	void MakeInstance()
	{
		if( instance == null )
		{
			instance = this;
		}
	}

	public void GameOverShowPanel (int finalScore, int finalCoinScore)
	{
		gameOverPanel.SetActive(true);
		gameOverScoreText.text = finalScore.ToString();
		gameOverCoinText.text = finalCoinScore.ToString();

		StartCoroutine(GameOverLoadMainMenu());
	}

	IEnumerator GameOverLoadMainMenu()
	{
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}

	public void PlayerDiedRestartTheGame()
	{
		StartCoroutine(PlayerDiedRestart());
	}

	IEnumerator PlayerDiedRestart()
	{
		timerText.text = "Respawn" + System.Environment.NewLine + System.Environment.NewLine + "in" + System.Environment.NewLine + System.Environment.NewLine + "3";
		timerText.gameObject.SetActive(true);
		yield return new WaitForSeconds (1f);
		timerText.text = "Respawn" + System.Environment.NewLine + System.Environment.NewLine + "in" + System.Environment.NewLine + System.Environment.NewLine + "2";
		yield return new WaitForSeconds (1f);
		timerText.text = "Respawn" + System.Environment.NewLine + System.Environment.NewLine + "in" + System.Environment.NewLine + System.Environment.NewLine + "1";
		yield return new WaitForSeconds (1f);

		timerText.gameObject.SetActive(false);
		SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
	}



	public void SetScore(int score)
	{
		scoreText.text = "" + score.ToString();
	}

	public void SetCoinScore(int score)
	{
		coinText.text = "x" + score.ToString();
	}

	public void SetLifeScore(int score)
	{
		lifeText.text = "x" + score.ToString();
	}

	public void PauseTheGame()
	{
		Time.timeScale = 0f;
		pausePanel.SetActive(true);
	}

	public void ResumeTheGame()
	{
		Time.timeScale = 1f;
		pausePanel.SetActive(false);
	}

	public void QuitTheGame()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}

	public void StartTheGame()
	{
		Time.timeScale = 1f;
		readyButton.gameObject.SetActive(false);
	}
}
