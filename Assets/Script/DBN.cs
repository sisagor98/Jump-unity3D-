using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DBN : MonoBehaviour {

	public GameObject playAgain;
	public GameObject Back;
	public Text Score;
	private int score;
	void Start () {
//		score = PlayerPrefs.GetInt ("DeathScore");
//		Debug.Log (score);
		Score.text = "Your Score : " + PlayerPrefs.GetInt ("Death").ToString ();
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene ("GameScene");
	}
	public void backMene()
	{
		SceneManager.LoadScene ("menuScene");
	}
}
