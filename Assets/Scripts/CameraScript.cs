using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private float speed = 1f;
	private float acceleration = 0.2f;
	private float maxSpeed = 3.2f;

	private float easySpeed = 3.2f;
	private float mediumSpeed = 3.7f;
	private float hardSpeed = 4.2f;

	[HideInInspector]
	public bool moveCamera;

	void Start()
	{
		if( GamePreferences.GetEasyDifficultyState () == 1 )
		{
			maxSpeed = easySpeed;
		}
		if( GamePreferences.GetMediumDifficultyState () == 1 )
		{
			maxSpeed = mediumSpeed;
		}
		if( GamePreferences.GetHardDifficultyState () == 1 )
		{
			maxSpeed = hardSpeed;
		}

		moveCamera = true;
	}

	void Update()
	{
		if (moveCamera){
			MoveCamera();
		}
	}

	void MoveCamera()
	{
		Vector3 temp = transform.position;

		//float oldY = temp.y;
		float newY = temp.y - (speed * Time.deltaTime);

		//temp.y = Mathf.Clamp (temp.y, oldY, newY);  //tego nie czaje, działa bez tej lini tak samo chyba hmmm
		temp.y = newY;
		//print (temp.y);

		transform.position = temp;

		speed += acceleration * Time.deltaTime;

		if (speed > maxSpeed) speed = maxSpeed;
			//print ("Max speed reached");
	}
}
