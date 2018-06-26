using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	private PlayerMoveJoystick playerMove;


	void Start()
	{
		playerMove = GameObject.Find("Player").GetComponent<PlayerMoveJoystick>();
	}

	public void OnPointerDown(PointerEventData data)
	{
		if (gameObject.name == "LEFT"){
			playerMove.SetMoveLeft(true);
		} else {
			playerMove.SetMoveLeft(false);
		}
	}

	public void OnPointerUp(PointerEventData data)
	{
		playerMove.StopMoving();
	}
}
