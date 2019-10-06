using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {

	public static LevelManager Instance{ set; get;}

	private int hitpoint = 3;
	private int score = 0;

	public Transform spawnPosition;
	public Transform playerTransform;

	public Text scoreText;
	public Text hitpointText;
	public void Awake()
	{
		Instance = this;
		scoreText.text = "Score: "+score.ToString ();
		hitpointText.text = "HitPoint: "+hitpoint.ToString ();
	}

	private void Update()
	{
		if (playerTransform.position.y < -10) 
		{
			playerTransform.position = spawnPosition.position;
			hitpoint--;
			hitpointText.text = "HitPoint: "+hitpoint.ToString ();
			if(hitpoint<=0)
			{
				Death ();
			}
		}
	}

	public void Win()
	{
		PlayerPrefs.SetInt ("YourScore", score);
		SceneManager.LoadScene ("win");
	}
	public void Death()
	{
		PlayerPrefs.SetInt ("Death", score);
		SceneManager.LoadScene ("DeathScene");
	}
	public void collector()
	{
		score++;
		scoreText.text = "Score: "+score.ToString ();
	}
}
