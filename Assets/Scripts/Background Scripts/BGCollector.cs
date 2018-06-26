using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Background") collider.gameObject.SetActive(false);
	}
}
