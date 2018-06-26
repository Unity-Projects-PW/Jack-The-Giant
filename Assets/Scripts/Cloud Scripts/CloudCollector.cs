using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Cloud" || collider.tag == "Deadly")
		{
			collider.gameObject.SetActive(false);
		}
	}
}
