using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinColectSound : MonoBehaviour {

	public GameObject sound;


	void OnCollsionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Active");
			sound.SetActive (true);
		}
	}
}
