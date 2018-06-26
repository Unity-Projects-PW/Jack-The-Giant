using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 8f, maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anim;

	void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//PlayerMoveKeyboard(); // WYŁĄCZ JEŚLI MA DZIAŁAĆ ANIMACJA NA ANDROIDZIE.
	}

	void PlayerMoveKeyboard()
	{
		float forceX = 0f;
		float vel = Mathf.Abs(myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");  // x = -1 / 0 / 1    A = -1 D = 1 Nothing = 0
		if (h > 0)
		{
			if (vel < maxVelocity) forceX = speed;

			Vector3 temp = transform.localScale;
			temp.x = 1.3f;
			transform.localScale = temp;

			anim.SetBool("Walk", true);
		} 
		else if (h < 0)
		{
			if (vel < maxVelocity) forceX = -speed;

			Vector3 temp = transform.localScale;
			temp.x = -1.3f;
			transform.localScale = temp;

			anim.SetBool("Walk", true);
		}
		else
		{
			anim.SetBool("Walk", false);
		}

		myBody.AddForce(new Vector2(forceX, 0));
	}
}
