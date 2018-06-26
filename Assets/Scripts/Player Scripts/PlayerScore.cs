using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

	[SerializeField]
	private AudioClip coinClip, lifeClip;

	private CameraScript cameraScript;

	private Vector3 previousPosition;
	private bool countScore;

	public static int scoreCount;
	public static int coinCount;
	public static int lifeCount;

	void Awake()
	{
		cameraScript = Camera.main.GetComponent<CameraScript> ();
	}



	// Use this for initialization
	void Start()
	{
		previousPosition = transform.position;
		countScore = true;
	}
	
	// Update is called once per frame
	void Update()
	{
		CountScore();
	}

	void CountScore()
	{
		if( countScore )
		{
			if( transform.position.y < previousPosition.y )
			{
				scoreCount++;
			}
			previousPosition = transform.position;
			GameplayController.instance.SetScore(scoreCount);
		}
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if(collider.tag == "Coin")
		{
			coinCount++;
			scoreCount += 200;

			GameplayController.instance.SetCoinScore(coinCount);
			GameplayController.instance.SetScore(scoreCount);

			AudioSource.PlayClipAtPoint(coinClip, transform.position);
			collider.gameObject.SetActive(false);
		}

		if(collider.tag == "Life") 
		{
			lifeCount++;
			scoreCount += 300;

			GameplayController.instance.SetLifeScore(lifeCount);
			GameplayController.instance.SetScore(scoreCount);
			 
			AudioSource.PlayClipAtPoint(lifeClip, transform.position);
			collider.gameObject.SetActive(false);
		}

		if(collider.tag == "Bounds" || collider.tag == "Deadly")
		{
			cameraScript.moveCamera = false;
			countScore = false;


			transform.position = new Vector3(500,500,0); //throw somewhere player when died so he isnt in our scene
			lifeCount--;
			GameManager.instance.CheckGameStatus(scoreCount,coinCount,lifeCount);
		}
			
	}
}
