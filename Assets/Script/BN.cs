using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BN : MonoBehaviour {
	public GameObject Play;
	public GameObject exit;
	public GameObject help;
	public GameObject credits;
	public GameObject scrolbar;
	public GameObject Name;
	public GameObject scrolbar1;
		
	public void play1()
	{		
		SceneManager.LoadScene ("GameScene");

	}
	public void Exit()
	{
		Application.Quit ();
	}
	public void Credits()
	{
		Play.SetActive (false);
		help.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		Name.SetActive (false);
		scrolbar.SetActive (true);
	}
	public void BacK()
	{
		Play.SetActive (true);
		help.SetActive (true);
		credits.SetActive (true);
		exit.SetActive (true);
		Name.SetActive (true);
		scrolbar.SetActive (false);
	}
	public void Help()
	{
		Play.SetActive (false);
		help.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		Name.SetActive (false);
		scrolbar1.SetActive (true);
	}
	public void BacK1()
	{
		Play.SetActive (true);
		help.SetActive (true);
		credits.SetActive (true);
		exit.SetActive (true);
		Name.SetActive (true);
		scrolbar1.SetActive (false);
	}
}
