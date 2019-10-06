using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WBN : MonoBehaviour {

	public GameObject PalyAgain;
	public GameObject Back;
	public Text YourScore;
	void Start () {
		YourScore.text = "Your Score : " + PlayerPrefs.GetInt ("YourScore").ToString ();
	}

	public void playAgain()
	{
		SceneManager.LoadScene ("GameScene");
	}
	public void backMene()
	{
		SceneManager.LoadScene ("menuScene");
	}
}
